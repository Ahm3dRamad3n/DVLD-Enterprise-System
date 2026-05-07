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
namespace Driving_License_Management.FORMS.Add_Only_Forms
{
    public partial class IssueInternationalLicense : Form
    {
        private int LocalLicenseID = -1;
        private int InternationalLicenseID = -1;
        public IssueInternationalLicense()
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
            applicationInfo1.LoadNewApplicationByLocalLID(LocalLicenseID);

            if (lD_LicenseInfo1.GetClassID() != 3)
            {
                DVLDProgram.Show("Incompatible License Class", "Only Local Licenses of Class 3 are eligible for International License issuance.", MessageBoxIcon.Error);
                btnIssue.Enabled = false;
                linkLabel2.Enabled = false;
                return;
            }

            if (_IsExistingInternationalLicense())
            {
                btnIssue.Enabled = false;
                linkLabel2.Enabled = true;
                applicationInfo1.LoadDataByInternationalLicenseID(InternationalLicenseID);
                DVLDProgram.Show("Information", "An International License has already been issued for this Local License.", MessageBoxIcon.Information);
                return;
            }

            btnIssue.Enabled = true;
            linkLabel2.Enabled = false;

        }
        private bool _IsExistingInternationalLicense()
        {
            InternationalLicenseID = InternationalLicensesBusinessLayer.Get_ILID_By_LLID(LocalLicenseID);
            return InternationalLicenseID != -1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new InternationalLicenseDetails(InternationalLicenseID);
            form.ShowDialog();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            clsApplications application = new clsApplications();
            application.ApplicationTypeID = 6; // 6 = International License
            application.ApplicationDate = DateTime.Now;
            application.LastStatusDate = DateTime.Now;
            application.CreatedByUserID = Program.CurrentUser.UserID;
            application.ApplicationPersonID = lD_LicenseInfo1.GetPersonID();
            application.PaidFees = applicationInfo1.GetApplicationTypeFees();
            application.ApplicationStatus = clsApplications.ApplicationStatusEnum.Completed;

            bool result = ApplicationsBusinessLayer.AddNewApplication(application);
            if (result)
            {
                clsInternationalLicense internationalLicense = new clsInternationalLicense();
                internationalLicense.ApplicationID = application.ApplicationID;
                internationalLicense.DriverID = lD_LicenseInfo1.GetDriverID();
                internationalLicense.IssuedUsingLocalLicenseID = LocalLicenseID;
                internationalLicense.IssueDate = DateTime.Now;
                internationalLicense.ExpirationDate = DateTime.Now.AddYears(LicenseClassesBusinessLayer.GetExpiryPeriodByClassID(lD_LicenseInfo1.GetClassID()));
                internationalLicense.IsActive = true;
                internationalLicense.CreatedByUserID = Program.CurrentUser.UserID;
                bool Added = InternationalLicensesBusinessLayer.IssueInternationalLicense(internationalLicense);
                if (Added)
                {
                    InternationalLicenseID = internationalLicense.InternationalLicenseID;
                    applicationInfo1.SetApplicationID(internationalLicense.ApplicationID);
                    applicationInfo1.SetInternationalLicenseID(InternationalLicenseID);
                    btnIssue.Enabled = false;
                    linkLabel2.Enabled = true;
                    DVLDProgram.Show("Success", "International License issued successfully.", MessageBoxIcon.Information);
                }
                else
                {
                    DVLDProgram.Show("Error", "Failed to issue International License.", MessageBoxIcon.Error);
                }
            }
            else
            {
                DVLDProgram.Show("Error", "Failed to create application.", MessageBoxIcon.Error);
            }
        }
    }
}
