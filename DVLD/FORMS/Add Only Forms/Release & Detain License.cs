using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DVLD_DTOs;
using System.Windows.Forms;
using System.Xml.Schema;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DVLD_Business_Layer;
namespace Driving_License_Management
{
    public partial class ReleaseOrDetainLicense : Form
    {
        public enum LicenseAction
        {
            Release,
            Detain
        }
        private LicenseAction _action;
        int LocalLicenseID = -1;
        public ReleaseOrDetainLicense(LicenseAction action)
        {
            InitializeComponent();
            _action = action;
            if (_action == LicenseAction.Release)
            {
                InitializeReleaseMode();
            }
            else // Detain
            {
                InitializeDetainMode();
            }
        }
        public ReleaseOrDetainLicense(int LocalLicenseID)
        {
            InitializeComponent();
            _action = LicenseAction.Release;
            this.LocalLicenseID = LocalLicenseID;
            groupBox1.Enabled = false;
            textBox1.Text = LocalLicenseID.ToString();
            linkLabel2.Enabled = true;
            InitializeReleaseMode();
            lD_LicenseInfo1.LoadData(LocalLicenseID);
            detainOrReleaseInfo1.LoadReleaseInfoByLocalLID(LocalLicenseID);
        }

        private void InitializeReleaseMode()
        {
            this.Text = "Release Local License";
            Title.Text = "Release Detained License";
            btnSave.Text = "Release";
            btnSave.Image = Properties.Resources.Release;
            detainOrReleaseInfo1.Action = DetainOrReleaseInfo.LicenseAction.Release;
            btnSave.Location = new Point(btnSave.Location.X, 558);
            button3.Location = new Point(button3.Location.X, 558);
            linkLabel1.Location = new Point(linkLabel1.Location.X, 572);
            linkLabel2.Location = new Point(linkLabel2.Location.X, 572);
            this.Height = 642;

        }
        private void InitializeDetainMode()
        {
            this.Text = "Detain Local License";
            Title.Text = "Detain License";
            btnSave.Text = "Detain";
            btnSave.Image = Properties.Resources.Detain;
            detainOrReleaseInfo1.Action = DetainOrReleaseInfo.LicenseAction.Detain;
            btnSave.Location = new Point(btnSave.Location.X, 520);
            button3.Location = new Point(button3.Location.X, 520);
            linkLabel1.Location = new Point(linkLabel1.Location.X, 533);
            linkLabel2.Location = new Point(linkLabel2.Location.X, 533);
            this.Height = 608;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new LocalLicenseDetails(LocalLicenseID);
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_action == LicenseAction.Release)
            {
                btnRelease_Click();
            }
            else // Detain
            {
                btnDetain_Click();
            }
            groupBox1.Enabled = true;
        }

        private void btnDetain_Click()
        {
            int DetainID = -1;
            bool detainResult = DetainedLicensesBusinessLayer.DetainLicense(LocalLicenseID, detainOrReleaseInfo1.GetTotalFees(), ref DetainID);
            if (detainResult)
            {
                lD_LicenseInfo1.DetainLicense();
                detainOrReleaseInfo1.SetDetainID(DetainID);
                btnSave.Enabled = false;
                DVLDProgram.Show("Success", "License detained successfully.", MessageBoxIcon.Information);
            }
            else
            {
                DVLDProgram.Show("Error", "Failed to detain license.", MessageBoxIcon.Error);
            }
        }

        private void btnRelease_Click()
        {
            clsApplications application = new clsApplications();
            application.ApplicationTypeID = 5; // 5 = Release Local License
            application.ApplicationDate = DateTime.Now;
            application.LastStatusDate = DateTime.Now;
            application.CreatedByUserID = Program.CurrentUser.UserID;
            application.ApplicationPersonID = lD_LicenseInfo1.GetPersonID();
            application.PaidFees = detainOrReleaseInfo1.GetTotalFees();
            application.ApplicationStatus = clsApplications.ApplicationStatusEnum.Completed;

            bool result = ApplicationsBusinessLayer.AddNewApplication(application);
            if (result)
            {
                bool releaseResult = DetainedLicensesBusinessLayer.ReleaseDetainedLicense(detainOrReleaseInfo1.GetDetainID(), application.ApplicationID);
                if (releaseResult)
                {
                    lD_LicenseInfo1.ReleaseLicense();
                    detainOrReleaseInfo1.SetApplicationID(application.ApplicationID);
                    btnSave.Enabled = false;
                    DVLDProgram.Show("Success", "License released successfully.", MessageBoxIcon.Information);
                }
                else
                {
                    DVLDProgram.Show("Error", "Failed to release license.", MessageBoxIcon.Error);
                }
            }
            else
            {
                DVLDProgram.Show("Error", "Failed to add application.", MessageBoxIcon.Error);
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
            linkLabel2.Enabled = true;

            lD_LicenseInfo1.LoadData(LocalLicenseID);
            if (_action == LicenseAction.Release) 
            {
                if (!_IsLicenseDetained())
                {
                    btnSave.Enabled = false;
                    DVLDProgram.Show("Information", "The Local License is not detained, cannot release.", MessageBoxIcon.Information);
                    return;
                }
                detainOrReleaseInfo1.LoadReleaseInfoByLocalLID(LocalLicenseID);
            }
            else // Detain
            {
                if (_IsLicenseDetained())
                {
                    btnSave.Enabled = false;
                    DVLDProgram.Show("Information", "The Local License is already detained.", MessageBoxIcon.Information);
                    return;
                }
                detainOrReleaseInfo1.LoadDetainInfoByLocalLID(LocalLicenseID);
            }

            btnSave.Enabled = true;
            
        }

        private bool _IsLicenseDetained()
        {
            bool IsDetained = lD_LicenseInfo1.IsLicenseDetained();
            return IsDetained;
        }
    }
}
