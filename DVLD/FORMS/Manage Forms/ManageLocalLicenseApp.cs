using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using DVLD_DTOs;
using System.Windows.Forms;
using DVLD_Business_Layer;

namespace Driving_License_Management
{
    public partial class ManageLocalLicenseApp : Form
    {
        private int userPermission = Program.CurrentUser.permissions;

        private enum pageMode
        {
            ManageApplications,
            ViewLicenses
        }
        private pageMode currentMode = pageMode.ManageApplications;

        DataTable dtLocalLicensesApp = new DataTable();
        public ManageLocalLicenseApp()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            _LoadLocalLicensesData();
        }

        private void _LoadLocalLicensesData()
        {
            if (currentMode == pageMode.ManageApplications)
            {
                dtLocalLicensesApp = AppLicenseBusinessLayer.LoadAll_LDLApplications();
                dataGridView1.DataSource = dtLocalLicensesApp;
                dataGridView1.Columns[1].Width = 198;
                dataGridView1.Columns[3].Width = 250;
                dataGridView1.Columns[4].Width = 150;
            }
            else
            {
                dtLocalLicensesApp = LocalDrivingLicensesBusinessLayer.LoadAll_LDL_History();
                dataGridView1.DataSource = dtLocalLicensesApp;
                dataGridView1.Columns[0].Width = 130;
                dataGridView1.Columns[1].Width = 130;
                dataGridView1.Columns[2].Width = 250;
                dataGridView1.Columns[3].Width = 129;
                dataGridView1.Columns[4].Width = 129;
                dataGridView1.Columns[5].Width = 100;
                dataGridView1.Columns[6].Width = 100;
            }

            RecordsNumber.Text = $"{dataGridView1.Rows.Count}";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int requiredPermission = (int)DVLDProgram.Permission.AddNewLocalLicenseApp;
            if ((userPermission & requiredPermission) != requiredPermission)
            {
                DVLDProgram.Show("Access Denied", "You do not have permission to access this feature.", MessageBoxIcon.Warning);
                return;
            }

            Form form = new AddOrEditApplication();
            form.ShowDialog();
            _LoadLocalLicensesData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter = comboBox1.SelectedItem.ToString();
            if (filter == "None")
            {
                textBox1.Visible = false;
                dataGridView1.DataSource = dtLocalLicensesApp;
                RecordsNumber.Text = $"{dataGridView1.Rows.Count}";
                return;
            }
            textBox1.Clear();
            textBox1.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filter = comboBox1.SelectedItem.ToString();
            string filterExpression = "";
            
            filterExpression = $"Convert({filter}, 'System.String') LIKE '{textBox1.Text}%'";
         
            DataView dv = new DataView(dtLocalLicensesApp);
            dv.RowFilter = filterExpression;
            dataGridView1.DataSource = dv;
            RecordsNumber.Text = $"{dataGridView1.Rows.Count}";
        }

        //private bool NotSelectedShowMessage()
        //{
        //    if (dataGridView1.SelectedRows.Count == 0)
        //    {
        //        DVLDProgram.Show("No Record Selected", "Please select a record first.", MessageBoxIcon.Warning);
        //        return true;
        //    }
        //    return false;
        //}

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (NotSelectedShowMessage())
            //    return;

            int AppLicenseID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["AppLicenseID"].Value);
            int applicationId = AppLicenseBusinessLayer.GetApplicationIdByALId(AppLicenseID);
            clsApplications application = ApplicationsBusinessLayer.FindByID(applicationId);
            if (application != null)
            {
                Form form = new ApplicationDetails(application);
                form.ShowDialog();
            }
            else
            {
                DVLDProgram.Show("Error", "Application record not found.", MessageBoxIcon.Error);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (NotSelectedShowMessage())
            //    return;

            int AppLicenseID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["AppLicenseID"].Value);
            int applicationId = AppLicenseBusinessLayer.GetApplicationIdByALId(AppLicenseID);
            clsApplications application = ApplicationsBusinessLayer.FindByID(applicationId);
            if (application != null)
            {
                Form form = new AddOrEditApplication(application, AppLicenseID);
                form.ShowDialog();
                _LoadLocalLicensesData();
            }
            else
            {
                DVLDProgram.Show("Error", "Application record not found.", MessageBoxIcon.Error);
            }
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (NotSelectedShowMessage())
            //    return;

            if (MessageBox.Show("Are you sure you want to delete this application?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int AppLicenseID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["AppLicenseID"].Value);
                int applicationId = AppLicenseBusinessLayer.GetApplicationIdByALId(AppLicenseID);
                bool success = ApplicationsBusinessLayer.DeleteApplicationAndLDL(applicationId, AppLicenseID);
                if (success)
                {
                    DVLDProgram.Show("Success", "Application and associated local driving license (if any) deleted successfully.", MessageBoxIcon.Information);
                    _LoadLocalLicensesData();
                }
                else
                {
                    DVLDProgram.Show("Error", "Failed to delete the application.", MessageBoxIcon.Error);
                }
            }
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (NotSelectedShowMessage())
            //    return;

            if (MessageBox.Show("Are you sure you want to cancel this application?", "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int AppLicenseID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["AppLicenseID"].Value);
                int applicationId = AppLicenseBusinessLayer.GetApplicationIdByALId(AppLicenseID);
                bool success = ApplicationsBusinessLayer.CancelApplication(applicationId);
                if (success)
                {
                    DVLDProgram.Show("Success", "Application cancelled successfully.", MessageBoxIcon.Information);
                    _LoadLocalLicensesData();
                }
                else
                {
                    DVLDProgram.Show("Error", "Failed to cancel the application.", MessageBoxIcon.Error);
                }
            }
        }

        private void sehdulToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (NotSelectedShowMessage())
            //    return;
        }

        private void issueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (NotSelectedShowMessage())
            //    return;

            int AppLicenseID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["AppLicenseID"].Value);
            int applicantId = AppLicenseBusinessLayer.GetApplicationIdByALId(AppLicenseID);
            Form form = new IssueLocalDrivingLicense(AppLicenseID, applicantId);
            form.ShowDialog();
            _LoadLocalLicensesData();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (NotSelectedShowMessage())
            //    return;

            int appLicenseID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["AppLicenseID"].Value);
            int applicationID = AppLicenseBusinessLayer.GetApplicationIdByALId(appLicenseID);
            int licenseID = LocalDrivingLicensesBusinessLayer.GetLicenseIDByApplicationID(applicationID);
            Form form = new LocalLicenseDetails(licenseID);
            form.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (NotSelectedShowMessage())
            //    return;

            string NationalNo = dataGridView1.CurrentRow.Cells["NationalNo"].Value.ToString();
            clsPerson person = PersonBusinessLayer.FindByNationalNo(NationalNo);
            if (person != null)
            {
                Form form = new PersonLicenseHistory(person);
                form.ShowDialog();
            }
            else
            {
                DVLDProgram.Show("Error", "Person record not found.", MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void sehduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _GoToTestAppointment(TestInfo.enTestType.VisionTest);
        }

        private void sehduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _GoToTestAppointment(TestInfo.enTestType.WrittenTest);
        }

        private void sehduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _GoToTestAppointment(TestInfo.enTestType.StreetTest);
        }

        private void _GoToTestAppointment(TestInfo.enTestType testType)
        {
            //if (NotSelectedShowMessage())
            //    return;

            int AppLicenseID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["AppLicenseID"].Value);
            int applicantId = AppLicenseBusinessLayer.GetApplicationIdByALId(AppLicenseID);
            Form form = new ManageTestAppointments(AppLicenseID, applicantId, testType);
            form.ShowDialog();
            _LoadLocalLicensesData();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (currentMode == pageMode.ViewLicenses)
                return;

            if (dataGridView1.SelectedRows.Count > 0)
            {
                string status = dataGridView1.CurrentRow.Cells["Status"].Value.ToString();
                if (status == "New")
                {
                    editToolStripMenuItem.Enabled = true;
                    deleteApplicationToolStripMenuItem.Enabled = true;
                    cancelApplicationToolStripMenuItem.Enabled = true;
                    sehdulToolStripMenuItem.Enabled = true;
                    issueToolStripMenuItem.Enabled = false;
                    int passedTests = Convert.ToInt32(dataGridView1.CurrentRow.Cells["PassedTestCount"].Value);
                    if (passedTests == 0)
                    {
                        sehduleVisionTestToolStripMenuItem.Enabled = true;
                        sehduleWrittenTestToolStripMenuItem.Enabled = false;
                        sehduleStreetTestToolStripMenuItem.Enabled = false;
                    }
                    else if (passedTests == 1)
                    {
                        sehduleVisionTestToolStripMenuItem.Enabled = false;
                        sehduleWrittenTestToolStripMenuItem.Enabled = true; ;
                        sehduleStreetTestToolStripMenuItem.Enabled = false;
                    }
                    else if (passedTests == 2)
                    {
                        sehduleVisionTestToolStripMenuItem.Enabled = false;
                        sehduleWrittenTestToolStripMenuItem.Enabled = false;
                        sehduleStreetTestToolStripMenuItem.Enabled = true;
                    }
                    else // passedTests == 3
                    {
                        sehdulToolStripMenuItem.Enabled = false;
                        issueToolStripMenuItem.Enabled = true;
                    }
                    showLicenseToolStripMenuItem.Enabled = false;
                }
                else if (status == "Cancelled")
                {
                    editToolStripMenuItem.Enabled = false;
                    deleteApplicationToolStripMenuItem.Enabled = true;
                    cancelApplicationToolStripMenuItem.Enabled = false;
                    sehdulToolStripMenuItem.Enabled = false;
                    issueToolStripMenuItem.Enabled = false;
                    showLicenseToolStripMenuItem.Enabled = false;
                }
                else // status == "Completed" 
                {
                    editToolStripMenuItem.Enabled = false;
                    deleteApplicationToolStripMenuItem.Enabled = false;
                    cancelApplicationToolStripMenuItem.Enabled = false;
                    sehdulToolStripMenuItem.Enabled = false;
                    issueToolStripMenuItem.Enabled = false;
                    showLicenseToolStripMenuItem.Enabled = true;
                }
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (currentMode == pageMode.ManageApplications)
            {
                _GoToPageViewLicenses();
            }
            else
            {
                _ReturnToPageManageApplication();
            }
        }
        private void _GoToPageViewLicenses()
        {
            currentMode = pageMode.ViewLicenses;
            button3.Text = "Manage Applications";
            button3.Image = Properties.Resources.applications;
            label1.Text = "Local Driving License History";
            pictureBox1.Image = Properties.Resources.LocalFullSize;
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new string[] { "None", "LicenseID", "ApplicationID", "ClassName", "IsActive", "PersonID" });
            comboBox1.SelectedIndex = 0;
            textBox1.Visible = false;
            _LoadLocalLicensesData();
            dataGridView1.ContextMenuStrip = contextMenuStrip2;
        }
        private void _ReturnToPageManageApplication()
        {
            currentMode = pageMode.ManageApplications;
            button3.Text = "View Licenses";
            button3.Image = Properties.Resources.local32;
            label1.Text = "Local Driving License Applications";
            pictureBox1.Image = Properties.Resources.unnamed__4__removebg_preview;
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new string[] { "None", "AppLicenseID", "NationalNo", "FullName", "Status" });
            comboBox1.SelectedIndex = 0;
            textBox1.Visible = false;
            _LoadLocalLicensesData();
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int licenseID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["LicenseID"].Value);
            Form form = new LocalLicenseDetails(licenseID);
            form.ShowDialog();
        }
    }
}
