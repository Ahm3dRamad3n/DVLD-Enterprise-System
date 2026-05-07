using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DVLD_DTOs;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using DVLD_Business_Layer;

namespace Driving_License_Management
{
    public partial class ManageTestAppointments : Form
    {
        clsApplications applications = new clsApplications();
        TestInfo.enTestType CurrentTest;
        int passedTests = -1, AppLID = -1;
        string classname = string.Empty;

        public ManageTestAppointments(int ALId, int applicantId, TestInfo.enTestType CurrentTest)
        {
            InitializeComponent();
            AppLID = ALId;
            this.CurrentTest = CurrentTest;

            applications = ApplicationsBusinessLayer.FindByID(applicantId);
            appBasicInfo1.LoadData(applications);

            passedTests = TestsBusinessLayer.GetPassedCountBy_ALId(AppLID);
            int classId = LicenseClassesBusinessLayer.GetLicenseClassIDByALId(AppLID);
            classname = LicenseClassesBusinessLayer.GetLicenseClassNameByID(classId);
            drivingLicenseAppInfo1.LoadData(AppLID, classname, passedTests);

            switch (CurrentTest)
            {
                case TestInfo.enTestType.VisionTest:
                    InitializeVisionTestForm();
                    break;
                case TestInfo.enTestType.WrittenTest:
                    InitializeWrittenTestForm();
                    break;
                case TestInfo.enTestType.StreetTest:
                    InitializeStreetTestForm();
                    break;
                default:
                    DVLDProgram.Show("Error", "Invalid test number.", MessageBoxIcon.Error); this.Close();
                    break;
            }

            _LoadDataGridView();
            dataGridView1.Columns[0].Width = 140;
            dataGridView1.Columns[1].Width = 200;
            dataGridView1.Columns[2].Width = 140;
            dataGridView1.Columns[3].Width = 170;
            dataGridView1.Columns[4].Visible = false; 
        }

        private void InitializeVisionTestForm()
        {
            pictureBox1.Image = Properties.Resources.eye2;
            pictureBox2.Image = Properties.Resources.eye2;
            Title.Text = "Vision Test Appointments";
        }

        private void InitializeWrittenTestForm()
        {
            pictureBox1.Image = Properties.Resources.Written;
            pictureBox2.Image = Properties.Resources.Written;
            Title.Text = "Written Test Appointments";
        }
        private void InitializeStreetTestForm()
        {
            pictureBox1.Image = Properties.Resources.Street;
            pictureBox2.Image = Properties.Resources.Street;
            Title.Text = "Street Test Appointments";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (dataGridView1.CurrentRow.Cells["IsLocked"].Value.ToString() == "True") // locked
                {
                    editToolStripMenuItem.Enabled = false;
                    takeTestToolStripMenuItem.Enabled = false;
                }
                else // unlocked
                {
                    editToolStripMenuItem.Enabled = true;
                    takeTestToolStripMenuItem.Enabled = true;
                }
            }
        }

        private void _LoadDataGridView()
        {
            dataGridView1.DataSource = TestsBusinessLayer.LoadTestAppointmentsByALIdANDTestTypeId(AppLID, (int)CurrentTest);
            RecordsNumber.Text = dataGridView1.Rows.Count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (passedTests == (int)CurrentTest)
            {
                DVLDProgram.Show("Information", "The applicant has already passed the vision test.", MessageBoxIcon.Information);
                return;
            }

            bool HasAppointmentUnlocked = TestsBusinessLayer.HasTestAppointmentUnlocked(AppLID, (int)CurrentTest);
            if (HasAppointmentUnlocked)
            {
                DVLDProgram.Show("Information", "There is already an unlocked test appointment for this application.", MessageBoxIcon.Information);
                return;
            }

            DataTable NewTestInfo = new DataTable();
            NewTestInfo.Columns.Add("AppLicenseID", typeof(int));
            NewTestInfo.Columns.Add("FullName", typeof(string));
            NewTestInfo.Columns.Add("ClassName", typeof(string));
            NewTestInfo.Columns.Add("PaidFees", typeof(int));
            NewTestInfo.Rows.Add(AppLID, PersonBusinessLayer.GetFullNameByID(applications.ApplicationPersonID), classname, TestsBusinessLayer.GetTestTypeFeesByID((int)CurrentTest));
           
            AddOrEditTestAppointment form; 
            if (dataGridView1.Rows.Count == 0)
            {
                form = new AddOrEditTestAppointment(NewTestInfo.Rows[0], CurrentTest, AddOrEditTestAppointment.TestAppointmentMode.Add);
            }
            else
            {
                form = new AddOrEditTestAppointment(NewTestInfo.Rows[0], CurrentTest, AddOrEditTestAppointment.TestAppointmentMode.ReTake);
            }
            form.ShowDialog();
            _LoadDataGridView();

            
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.SelectedRows.Count == 0)
            //{
            //    DVLDProgram.Show("Information", "Please select a test appointment to edit.", MessageBoxIcon.Information);
            //    return;
            //}

            int TestAppointmentID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["AppointmentID"].Value);
            AddOrEditTestAppointment editForm = new AddOrEditTestAppointment(TestAppointmentID, CurrentTest, AddOrEditTestAppointment.TestAppointmentMode.Edit);
            editForm.ShowDialog();
            _LoadDataGridView();
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.SelectedRows.Count == 0)
            //{
            //    DVLDProgram.Show("Information", "Please select a test appointment to take the test.", MessageBoxIcon.Information);
            //    return;
            //}

            int TestAppointmentID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["AppointmentID"].Value);
            TakeTest takeTestForm = new TakeTest(TestAppointmentID, CurrentTest);
            takeTestForm.ShowDialog();
            _LoadDataGridView();

            passedTests = TestsBusinessLayer.GetPassedCountBy_ALId(AppLID);
            drivingLicenseAppInfo1.UpdatePassedTestCount(passedTests);
        }

    }
}