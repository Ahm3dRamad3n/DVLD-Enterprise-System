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
    public partial class ApplicationInfo : UserControl
    {
        public ApplicationInfo()
        {
            InitializeComponent();
        }
        public void LoadNewApplicationByLocalLID(int LocalLicenseID)
        {
            SetApplicationID(-1); // set null application
            SetInternationalLicenseID(-1); // set null international license
            SetApplicantDate(DateTime.Now);
            SetIssueDate(DateTime.Now);
            SetExpiryDate(DateTime.Now.AddYears(LicenseClassesBusinessLayer.GetExpiryPeriodByClassID(LocalDrivingLicensesBusinessLayer.GetClassIDByLicenseID(LocalLicenseID))));
            SetCreatedBy(Program.CurrentUser.UserName);
            SetLocalLicenseID(LocalLicenseID);
            int appFee = ApplicationsBusinessLayer.GetAppFees(6); // 6 = International License
            SetApplicationTypeFees(appFee);
        }
        public void LoadDataByInternationalLicenseID(int intLicenseID)
        {
            clsInternationalLicense intlLicense = InternationalLicensesBusinessLayer.FindByID(intLicenseID);
            if (intlLicense == null)
            {
                DVLDProgram.Show("Error", "Failed to load international license data.", MessageBoxIcon.Error);
                return;
            }
            SetApplicationID(intlLicense.ApplicationID);
            SetInternationalLicenseID(intlLicense.InternationalLicenseID);
            clsApplications application = ApplicationsBusinessLayer.FindByID(intlLicense.ApplicationID);
            if (application == null)
            {
                DVLDProgram.Show("Error", "Failed to load application data.", MessageBoxIcon.Error);
                return;
            }
            SetApplicantDate(application.ApplicationDate);
            SetIssueDate(intlLicense.IssueDate);
            SetExpiryDate(intlLicense.ExpirationDate);
            SetCreatedBy(UsersBusinessLayer.GetUserNameByID(intlLicense.CreatedByUserID));
            SetApplicationTypeFees(application.PaidFees);
        }

        public void SetApplicationID(int appID)
        {
            ApplicationID.Text = appID == -1 ? "[????]" : appID.ToString();
        }
        public void SetInternationalLicenseID(int intLicenseID)
        {
            IntLicenseID.Text = intLicenseID == -1 ? "[????]" : intLicenseID.ToString();
        }
        public int GetApplicationTypeFees()
        {
            int fees = -1;
            int.TryParse(Fees.Text, out fees);
            return fees;
        }
       
        private void SetApplicantDate(DateTime dateTime)
        {
            ApplicationDate.Text = dateTime.ToString("dd/MM/yyyy");
        }
        private void SetApplicationTypeFees(int appTypeFees)
        {
            Fees.Text = appTypeFees.ToString();
        }
        private void SetIssueDate(DateTime issueDate)
        {
            IssueDate.Text = issueDate.ToString("dd/MM/yyyy");
        }
        private void SetExpiryDate(DateTime expiryDate)
        {
            ExpirationDate.Text = expiryDate.ToString("dd/MM/yyyy");
        }
        private void SetLocalLicenseID(int localLicenseID)
        {
            LocalLicenseID.Text = localLicenseID.ToString();
        }
        private void SetCreatedBy(string createdBy)
        {
            CreatedBy.Text = createdBy;
        }
    }
}
