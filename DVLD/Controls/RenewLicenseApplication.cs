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
    public partial class RenewLicenseApplication : UserControl
    {
        public RenewLicenseApplication()
        {
            InitializeComponent();
        }
        public void LoadNewApplicationByLocalLID(int LocalLicenseID)
        {
            SetApplicationID(-1);
            SetRenewLicenseID(-1);
            SetApplicantDate(DateTime.Now);
            SetIssueDate(DateTime.Now);
            SetExpiryDate(DateTime.Now.AddYears(LicenseClassesBusinessLayer.GetExpiryPeriodByClassID(LocalDrivingLicensesBusinessLayer.GetClassIDByLicenseID(LocalLicenseID))));
            SetOldLicenseID(LocalLicenseID);
            SetCreatedBy(Program.CurrentUser.UserName);
            int appFee = ApplicationsBusinessLayer.GetAppFees(2); // 2 = Renew License
            SetApplicationFees(appFee);
            int licClassID = LocalDrivingLicensesBusinessLayer.FindByID(LocalLicenseID).LicenseClassID;
            SetLicenseFees(LicenseClassesBusinessLayer.GetFeesByClassID(licClassID));
            SetTotalFees(GetApplicationFees() + GetLicenseFees());
            SetNotes(string.Empty);
            EnableNotesEditing();
        }
        public void LoadDataByOldLicenseID(int OldLicenseID)
        {
            clsLocalLicense localLicense = LocalDrivingLicensesBusinessLayer.FindByID(OldLicenseID);
            if (localLicense == null)
            {
                DVLDProgram.Show("Error", "License not found.", MessageBoxIcon.Error);
                return;
            }
            SetApplicationID(localLicense.ApplicationID);
            SetOldLicenseID(OldLicenseID);
            SetApplicationID(localLicense.ApplicationID);
            SetApplicantDate(ApplicationsBusinessLayer.GetApplicationDateByAppID(localLicense.ApplicationID));
            int appFee = ApplicationsBusinessLayer.GetApplicationFeesByAppID(localLicense.ApplicationID);
            SetIssueDate(localLicense.IssueDate);
            SetExpiryDate(localLicense.ExpirationDate);
            SetCreatedBy(UsersBusinessLayer.GetUserNameByID(localLicense.CreatedByUserID));
            SetTotalFees(localLicense.PaidFees);
            SetApplicationFees(appFee);
            SetLicenseFees(GetTotalFees() - GetApplicationFees());
            SetNotes(localLicense.Notes);
            DisableNotesEditing();
        }

        public void SetRenewLicenseID(int LicenseID)
        {
            RenewLicenseID.Text = LicenseID == -1 ? "[????]" : LicenseID.ToString();
        }
        public void SetApplicationID(int appID)
        {
            ApplicationID.Text = appID == -1 ? "[????]" : appID.ToString();
        }
        public void DisableNotesEditing()
        {
            txtNotes.ReadOnly = true;
        }

        public int GetApplicationFees()
        {
            return int.TryParse(ApplicationFees.Text, out int appFees) ? appFees : -1;
        }
        public int GetTotalFees()
        {
            return int.TryParse(TotalFees.Text, out int totalFees) ? totalFees : -1;
        }
        public string GetNotes()
        {
            return txtNotes.Text;
        }

        private void EnableNotesEditing()
        {
            txtNotes.ReadOnly = false;
        }
        private void SetTotalFees(int totalFees)
        {
            TotalFees.Text = totalFees.ToString();
        }
        private void SetApplicantDate(DateTime dateTime)
        {
            ApplicationDate.Text = dateTime.ToString("dd/MM/yyyy");
        }
        private void SetApplicationFees(int appTypeFees)
        {
            ApplicationFees.Text = appTypeFees.ToString();
        }
        private void SetIssueDate(DateTime issueDate)
        {
            IssueDate.Text = issueDate.ToString("dd/MM/yyyy");
        }
        private void SetExpiryDate(DateTime expiryDate)
        {
            ExpirationDate.Text = expiryDate.ToString("dd/MM/yyyy");
        }
        private void SetOldLicenseID(int LicenseID)
        {
            OldLicenseID.Text = LicenseID.ToString();
        }
        private void SetCreatedBy(string createdBy)
        {
            CreatedBy.Text = createdBy;
        }
        private void SetLicenseFees(int licenseFees)
        {
            LicenseFees.Text = licenseFees.ToString();
        }
        private void SetNotes(string notes)
        {
            txtNotes.Text = notes;
        }

        private int GetLicenseFees()
        {
            return int.TryParse(LicenseFees.Text, out int licFees) ? licFees : -1;
        }
    }
}
