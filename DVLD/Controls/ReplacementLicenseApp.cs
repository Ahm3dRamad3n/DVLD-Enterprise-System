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
    public partial class ReplacementLicenseApp : UserControl
    {
        // Replacement For Lost -> 3
        // Replacement For Damaged -> 4
        public enum ReplacementType
        {
            Lost = 3,
            Damaged = 4
        }
        public ReplacementLicenseApp()
        {
            InitializeComponent();
        }

        public void LoadNewApplicationByLocalLID(int LocalLicenseID)
        {
            SetApplicationID(-1);
            SetReplacementLicenseID(-1);
            SetApplicationDate(DateTime.Now);
            SetIssueDate(DateTime.Now);
            SetExpiryDate(DateTime.Now.AddYears(LicenseClassesBusinessLayer.GetExpiryPeriodByClassID(LocalDrivingLicensesBusinessLayer.GetClassIDByLicenseID(LocalLicenseID))));
            SetOldLicenseID(LocalLicenseID);
            SetCreatedBy(Program.CurrentUser.UserName);
            SetApplicationFees(ReplacementType.Lost);
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
            SetReplacementLicenseID(-1);
            SetApplicationID(localLicense.ApplicationID);
            SetOldLicenseID(OldLicenseID);
            SetApplicationDate(ApplicationsBusinessLayer.GetApplicationDateByAppID(localLicense.ApplicationID));
            SetApplicationFees(localLicense.PaidFees);
            SetIssueDate(localLicense.IssueDate);
            SetExpiryDate(localLicense.ExpirationDate);
            SetCreatedBy(UsersBusinessLayer.GetUserNameByID(localLicense.CreatedByUserID));
            SetNotes(localLicense.Notes);
            DisableNotesEditing();
        }

        public void SetApplicationID(int appID)
        {
            ApplicationID.Text = appID == -1 ? "[????]" : appID.ToString();
        }
        public void SetApplicationFees(ReplacementType replacementType)
        {
            int fees = ApplicationsBusinessLayer.GetAppFees((int)replacementType);
            Fees.Text = fees.ToString();
        }
        public void SetApplicationFees(int fees)
        {
            Fees.Text = fees.ToString();
        }
        public void SetReplacementLicenseID(int LicenseID)
        {
            ReplacedLicenseID.Text = LicenseID == -1 ? "[????]" : LicenseID.ToString();
        }
        public void DisableNotesEditing()
        {
            txtNotes.ReadOnly = true;
        }

        public int GetApplicationFees()
        {
            return int.TryParse(Fees.Text, out int appFees) ? appFees : -1;
        }
        public string GetNotes()
        {
            return txtNotes.Text;
        }

        private void EnableNotesEditing()
        {
            txtNotes.ReadOnly = false;
        }
        private void SetNotes(string notes)
        {
            txtNotes.Text = notes;
        }
        private void SetOldLicenseID(int LicenseID)
        {
            OldLicenseID.Text = LicenseID.ToString();
        }
        private void SetApplicationDate(DateTime appDate)
        {
            ApplicationDate.Text = appDate.ToString("dd/MM/yyyy");
        }
        private void SetCreatedBy(string createdBy)
        {
            CreatedBy.Text = createdBy;
        }
        private void SetIssueDate(DateTime issueDate)
        {
            IssueDate.Text = issueDate.ToString("dd/MM/yyyy");
        }
        private void SetExpiryDate(DateTime expiryDate)
        {
            ExpirationDate.Text = expiryDate.ToString("dd/MM/yyyy");
        }
    }
}
