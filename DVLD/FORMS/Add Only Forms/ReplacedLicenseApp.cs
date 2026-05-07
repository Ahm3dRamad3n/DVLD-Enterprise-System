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
    public partial class ReplacedLicenseApp : Form
    {
        private int LocalLicenseID = -1;
        private int ReplaceLicenseID = -1;

        public ReplacedLicenseApp()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Lost_CheckedChanged(object sender, EventArgs e)
        {
            Title.Text = "Replacement For Lost License";
            replacementLicenseApp1.SetApplicationFees(ReplacementLicenseApp.ReplacementType.Lost);
        }

        private void Damaged_CheckedChanged(object sender, EventArgs e)
        {
            Title.Text = "Replacement For Damaged License";
            replacementLicenseApp1.SetApplicationFees(ReplacementLicenseApp.ReplacementType.Damaged);
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
            replacementLicenseApp1.LoadNewApplicationByLocalLID(LocalLicenseID);

            if (_IsLicenseAlreadyReplaced())
            {
                btnReplace.Enabled = false;
                linkLabel2.Enabled = false;
                groupBox2.Enabled = false;
                ReplaceLicenseID = LocalLicenseID;
                replacementLicenseApp1.LoadDataByOldLicenseID(LocalLicenseID);
                DVLDProgram.Show("Information", "The Local License has already been replaced.", MessageBoxIcon.Information);
                return;
            }

            btnReplace.Enabled = true;
            linkLabel2.Enabled = false;
            groupBox2.Enabled = true;
        }
        private bool _IsLicenseAlreadyReplaced()
        {
            bool IsActive = lD_LicenseInfo1.IsLicenseActive();
            return !IsActive;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new LocalLicenseDetails(ReplaceLicenseID);
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

        private void btnReplace_Click(object sender, EventArgs e)
        {
            clsApplications application = new clsApplications();
            int appTypeID = Lost.Checked ? 3 : 4; // 3 = Lost, 4 = Damaged
            application.ApplicationTypeID = appTypeID;
            application.ApplicationDate = DateTime.Now;
            application.LastStatusDate = DateTime.Now;
            application.CreatedByUserID = Program.CurrentUser.UserID;
            application.ApplicationPersonID = lD_LicenseInfo1.GetPersonID();
            application.PaidFees = replacementLicenseApp1.GetApplicationFees();
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
                localLicense.Notes = replacementLicenseApp1.GetNotes();
                localLicense.PaidFees = replacementLicenseApp1.GetApplicationFees();
                localLicense.IssueReasonID = appTypeID; // appTypeID corresponds to issue reason
                localLicense.IsActive = true;
                localLicense.CreatedByUserID = Program.CurrentUser.UserID;
                bool DeActiveOldLicense = LocalDrivingLicensesBusinessLayer.DeactivateLocalLicenseByID(LocalLicenseID);
                if (DeActiveOldLicense)
                {
                    lD_LicenseInfo1.DeactiveLicense();
                    bool Added = LocalDrivingLicensesBusinessLayer.IssueLocalDrivingLicense(localLicense);
                    if (Added)
                    {
                        ReplaceLicenseID = localLicense.LicenseID;
                        replacementLicenseApp1.DisableNotesEditing();
                        replacementLicenseApp1.SetReplacementLicenseID(ReplaceLicenseID);
                        replacementLicenseApp1.SetApplicationID(localLicense.ApplicationID);
                        btnReplace.Enabled = false;
                        linkLabel2.Enabled = true;
                        groupBox2.Enabled = false;
                        DVLDProgram.Show("Success", "Local License renewed successfully.", MessageBoxIcon.Information);
                    }
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
