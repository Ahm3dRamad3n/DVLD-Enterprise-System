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
    public partial class IssueLocalDrivingLicense : Form
    {
        clsApplications applications = new clsApplications();
        int passedTests = -1;
        int classId = -1;
        string classname = string.Empty;
        public IssueLocalDrivingLicense(int ALId, int applicantId)
        {
            InitializeComponent();
            applications = ApplicationsBusinessLayer.FindByID(applicantId);
            appBasicInfo1.LoadData(applications);
            passedTests = TestsBusinessLayer.GetPassedCountBy_ALId(ALId);
            classId = LicenseClassesBusinessLayer.GetLicenseClassIDByALId(ALId);
            classname = LicenseClassesBusinessLayer.GetLicenseClassNameByID(classId);
            drivingLicenseAppInfo1.LoadData(ALId, classname, passedTests);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clsLocalLicense localLicense = new clsLocalLicense();
            localLicense.ApplicationID = applications.ApplicationID;
            bool DriverExists = DriversBusinessLayer.CheckDriverExistsByPersonID(applications.ApplicationPersonID);
            if (DriverExists)
            {
                localLicense.DriverID = DriversBusinessLayer.GetDriverIDByPersonID(applications.ApplicationPersonID);
            }
            else
            {
                int newDriverId = DriversBusinessLayer.AddNewDriver(applications.ApplicationPersonID, Program.CurrentUser.UserID);
                if (newDriverId == -1)
                {
                    DVLDProgram.Show("Error", "An error occurred while creating a new Driver record.", MessageBoxIcon.Error);
                    return;
                }
                localLicense.DriverID = newDriverId;
            }
            localLicense.IssueReasonID = 1; // 1 = First Time Issue
            localLicense.LicenseClassID = classId;
            localLicense.IssueDate = DateTime.Now;
            int expiryPeriod = LicenseClassesBusinessLayer.GetExpiryPeriodByClassID(classId);
            localLicense.ExpirationDate = DateTime.Now.AddYears(expiryPeriod);
            localLicense.Notes = txtNotes.Text;
            localLicense.PaidFees = LicenseClassesBusinessLayer.GetFeesByClassID(classId);
            localLicense.CreatedByUserID = Program.CurrentUser.UserID;
            
            applications.ApplicationStatus = clsApplications.ApplicationStatusEnum.Completed;
            bool updateStatus = ApplicationsBusinessLayer.UpdateApplicationStatusByID(applications.ApplicationID, applications.ApplicationStatus);
            if (!updateStatus)
            {
                DVLDProgram.Show("Error", "An error occurred while updating the application status.", MessageBoxIcon.Error);
                return;
            }
            appBasicInfo1.UpdateStatus(applications.ApplicationStatus);

            bool result = LocalDrivingLicensesBusinessLayer.IssueLocalDrivingLicense(localLicense);
            if (result)
            {
                btnSave.Enabled = false;
                DVLDProgram.Show("Success", "Local Driving License issued successfully, Your License ID is: " + localLicense.LicenseID.ToString(), MessageBoxIcon.Information);
            }
            else
            {
                DVLDProgram.Show("Error", "An error occurred while issuing the Local Driving License.", MessageBoxIcon.Error);
            }
        }
    }
}
