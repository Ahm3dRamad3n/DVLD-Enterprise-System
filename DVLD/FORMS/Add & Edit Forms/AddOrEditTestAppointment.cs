using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DVLD_DTOs;
using System.Windows.Forms;
using DVLD_Business_Layer;
namespace Driving_License_Management
{
    public partial class AddOrEditTestAppointment : Form
    {
        // the form manages add or edit or Re-add test appointments
        public enum TestAppointmentMode
        {
            Add,
            Edit,
            ReTake
        }
        private TestAppointmentMode currentMode;
        int AppLID = -1;
        int TotalPaidFees = 0;
        int appointmentID = -1;
        TestInfo.enTestType CurrentTest;
        public AddOrEditTestAppointment(int appointmentId, TestInfo.enTestType CurrentTest, TestAppointmentMode mode)
        {
            InitializeComponent();
            currentMode = mode;
            this.appointmentID = appointmentId;
            this.CurrentTest = CurrentTest;
            DataRow dataRow = TestsBusinessLayer.GetTestInfoByAppointmentID(appointmentId);
            testInfo1.TestType = CurrentTest;
            testInfo1.LoadData(dataRow, CurrentTest);
            testInfo1.DisVisableTestID();
            if (mode == TestAppointmentMode.Edit)
            {
                groupBox1.Visible = false;
                btnClose.Location = new Point(185, 404);
                btnSave.Location = new Point(288, 404);
                this.Size = new Size(405, 491);
                TotalPaidFees = Convert.ToInt32(dataRow["PaidFees"]);
            }
            else
            {
                throw new ArgumentException("Invalid constructor for Add or ReTake mode. DataRow is required.");
            }
        }
        public AddOrEditTestAppointment(DataRow row, TestInfo.enTestType CurrentTest, TestAppointmentMode mode)
        {
            InitializeComponent();
            currentMode = mode;
            this.CurrentTest = CurrentTest;
            testInfo1.TestType = CurrentTest;
            testInfo1.DisVisableTestID();
            AppLID = Convert.ToInt32(row["AppLicenseID"]);
            if (mode == TestAppointmentMode.Add)
            {
                groupBox1.Enabled = false;
                RetakeTestFees.Text = "0";
                TotalFees.Text = row["PaidFees"].ToString();
            }
            else if (mode == TestAppointmentMode.ReTake)
            {
                int AppLID = Convert.ToInt32(row["AppLicenseID"]);
                int paidFees = Convert.ToInt32(row["PaidFees"]);
                int RetakeFees = ApplicationsBusinessLayer.GetAppFees(7); // Retake Test Fee Type ID is 7
                RetakeTestFees.Text = RetakeFees.ToString();
                TotalFees.Text = (paidFees + RetakeFees).ToString();
            }
            else {    
                throw new ArgumentException("Invalid constructor for Edit mode. Appointment ID is required.");
            }
            btnClose.Location = new Point(185, 452);
            btnSave.Location = new Point(288, 452);
            groupBox1.Location = new Point(3, 394);
            this.Size = new Size(405, 540);
            testInfo1.LoadData(row, CurrentTest);
            TotalPaidFees = Convert.ToInt32(TotalFees.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DateTime date = testInfo1.GetDate();
            if (currentMode == TestAppointmentMode.Edit)
            {
                bool IsSaved = TestsBusinessLayer.UpdateAppointmentDateByID(appointmentID, date);
                if (IsSaved)
                {
                    btnSave.Enabled = false;
                    DVLDProgram.Show("Success", "Test appointment updated successfully.", MessageBoxIcon.Information);
                }
                else
                {
                    DVLDProgram.Show("Error", "Failed to update test appointment.", MessageBoxIcon.Error);
                }
            }
            else // Add or ReTake
            {
                if (currentMode == TestAppointmentMode.ReTake)
                {
                    clsApplications applications = new clsApplications();
                    int appID = AppLicenseBusinessLayer.GetApplicationIdByALId(AppLID);
                    applications.ApplicationPersonID = ApplicationsBusinessLayer.FindByID(appID).ApplicationPersonID;
                    applications.ApplicationTypeID = 7; // Retake Test Application Type ID is 7
                    applications.ApplicationDate = DateTime.Now;
                    applications.LastStatusDate = DateTime.Now;
                    applications.CreatedByUserID = Program.CurrentUser.UserID;
                    applications.PaidFees = ApplicationsBusinessLayer.GetAppFees(7); // Retake Test Fee Type ID is 7
                    applications.ApplicationStatus = clsApplications.ApplicationStatusEnum.Completed;
                    bool NewAppID = ApplicationsBusinessLayer.AddNewApplication(applications);
                    if (!NewAppID)
                    {
                        DVLDProgram.Show("Error", "Failed to create retake test application.", MessageBoxIcon.Error);
                        return;
                    }
                }
                bool IsAdded = TestsBusinessLayer.AddTestAppointment((int)CurrentTest, AppLID, TotalPaidFees, date);
                if (IsAdded)
                {
                    btnSave.Enabled = false;
                    DVLDProgram.Show("Success", "Test appointment added successfully.", MessageBoxIcon.Information);
                }
                else
                {
                    DVLDProgram.Show("Error", "Failed to add test appointment.", MessageBoxIcon.Error);
                }
            }
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
