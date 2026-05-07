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
    public partial class RenewLicenseApp : Form
    {
        private int LocalLicenseID = -1;
        private int RenewLicenseID = -1;
        public RenewLicenseApp()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                DVLDProgram.Show("Input Error", "Please enter a valid LicenseID.", MessageBoxIcon.Error);
                return;
            }

            LocalLicenseID = int.TryParse(textBox1.Text.Trim(), out LocalLicenseID) ? LocalLicenseID : -1;
            if (LocalLicenseID == -1)
            {
                DVLDProgram.Show("Input Error", "Please enter a valid LicenseID Fromat.", MessageBoxIcon.Error);
                return;
            }

            lD_LicenseInfo1.LoadData(LocalLicenseID);
            renewLicenseApplication1.LoadNewApplicationByLocalLID(LocalLicenseID);

            if (_IsLicenseNotExpired())
            {
                btnRenew.Enabled = false;
                linkLabel2.Enabled = true;
                RenewLicenseID = LocalLicenseID;
                renewLicenseApplication1.LoadDataByOldLicenseID(LocalLicenseID);
                DVLDProgram.Show("Information", "The Local License is not yet expired, Expiration date is: " + lD_LicenseInfo1.GetExpirationDate().ToShortDateString(), MessageBoxIcon.Information);
                return;
            }

            if (_IsLicenseAlreadyRenewed())
            {
                btnRenew.Enabled = false;
                linkLabel2.Enabled = false;
                RenewLicenseID = LocalLicenseID;
                renewLicenseApplication1.LoadDataByOldLicenseID(LocalLicenseID);
                DVLDProgram.Show("Information", "The Local License has already been renewed.", MessageBoxIcon.Information);
                return;
            }

            btnRenew.Enabled = true;
            linkLabel2.Enabled = false;
        }

        private bool _IsLicenseNotExpired()
        {
            DateTime expirationDate = lD_LicenseInfo1.GetExpirationDate();
            return DateTime.Now < expirationDate;
        }
        private bool _IsLicenseAlreadyRenewed()
        {
            bool IsActive = lD_LicenseInfo1.IsLicenseActive();
            return !IsActive;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           Form form = new LocalLicenseDetails(RenewLicenseID);
           form.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (LocalLicenseID == -1)
            {
                DVLDProgram.Show("Input Error", "Please load a valid LicenseID first.", MessageBoxIcon.Error);
                return;
            }

            string NattionalNo = lD_LicenseInfo1.GetNationalNo();
            clsPerson person = PersonBusinessLayer.FindByNationalNo(NattionalNo);
            if (person != null)
            {
                Form form = new PersonLicenseHistory(person);
                form.ShowDialog();
            }
            else
            {
                DVLDProgram.Show("Error", "Person not found.", MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            clsApplications application = new clsApplications();
            application.ApplicationTypeID = 2; // 2 = Renew License
            application.ApplicationDate = DateTime.Now;
            application.LastStatusDate = DateTime.Now;
            application.CreatedByUserID = Program.CurrentUser.UserID;
            application.ApplicationPersonID = lD_LicenseInfo1.GetPersonID();
            application.PaidFees = renewLicenseApplication1.GetApplicationFees();
            application.ApplicationStatus = clsApplications.ApplicationStatusEnum.Completed;

            bool result = ApplicationsBusinessLayer.AddNewApplication(application);
            if (result)
            {
                clsLocalLicense localLicense = new clsLocalLicense();
                localLicense.ApplicationID = application.ApplicationID;
                localLicense.DriverID = lD_LicenseInfo1.GetDriverID();
                localLicense.LicenseClassID = lD_LicenseInfo1.GetClassID();
                localLicense.IssueDate = DateTime.Now;
                localLicense.ExpirationDate = DateTime.Now.AddYears(LicenseClassesBusinessLayer.GetExpiryPeriodByClassID(lD_LicenseInfo1.GetClassID()));
                localLicense.Notes = renewLicenseApplication1.GetNotes();
                localLicense.PaidFees = renewLicenseApplication1.GetTotalFees();
                localLicense.IssueReasonID = 2; // 2 = Renewal
                localLicense.IsActive = true;
                localLicense.CreatedByUserID = Program.CurrentUser.UserID;
                bool DeActiveOldLicense = LocalDrivingLicensesBusinessLayer.DeactivateLocalLicenseByID(LocalLicenseID);
                if (DeActiveOldLicense)
                {
                    lD_LicenseInfo1.DeactiveLicense();
                    bool Added = LocalDrivingLicensesBusinessLayer.IssueLocalDrivingLicense(localLicense);
                    if (Added)
                    {
                        RenewLicenseID = localLicense.LicenseID;
                        renewLicenseApplication1.DisableNotesEditing();
                        renewLicenseApplication1.SetApplicationID(localLicense.ApplicationID);
                        renewLicenseApplication1.SetRenewLicenseID(RenewLicenseID);
                        btnRenew.Enabled = false;
                        linkLabel2.Enabled = true;
                        DVLDProgram.Show("Success", "Local License renewed successfully.", MessageBoxIcon.Information);                    }
                    else
                    {
                        DVLDProgram.Show("Error", "Failed to Renew Local License.", MessageBoxIcon.Error);
                    }
                }
                else
                {
                    DVLDProgram.Show("Warning", "Warning: Failed to deactivate old license.", MessageBoxIcon.Warning);
                }
            }
            else
            {
                DVLDProgram.Show("Error", "Failed to create application.", MessageBoxIcon.Error);
            }
        }
    }
}
