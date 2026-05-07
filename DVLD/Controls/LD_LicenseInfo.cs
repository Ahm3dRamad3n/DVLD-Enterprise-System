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
    public partial class LD_LicenseInfo : UserControl
    {
        int _personID = -1,_classID = -1;
        public LD_LicenseInfo()
        {
            InitializeComponent();
        }
        public void DeactiveLicense()
        {
            IsActive.Text = "NO";
        }
        public void DetainLicense()
        {
            IsDetained.Text = "YES";
        }
        public void ReleaseLicense()
        {
            IsDetained.Text = "NO";
        }
        public bool IsLicenseActive()
        {
            return IsActive.Text == "YES";
        }
        public bool IsLicenseDetained()
        {
            return IsDetained.Text == "YES";
        }
        public int GetPersonID()
        {
            return _personID;
        }
        public int GetClassID()
        {
            return _classID;
        }
        public int GetDriverID()
        {
            return int.TryParse(DriverID.Text, out int driverID) ? driverID : -1;
        }
        public string GetNationalNo()
        {
            return NationalNo.Text;
        }
        public DateTime GetExpirationDate()
        {
            return DateTime.TryParse(ExpirationDate.Text, out DateTime expDate) ? expDate : DateTime.MinValue;
        }

        private void IssueReason_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(IssueReason, IssueReason.Text);
        }

        private void Notes_TextChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(Notes, Notes.Text);
        }

        public void LoadData(int licenseID)
        {
            clsLocalLicense localLicense = LocalDrivingLicensesBusinessLayer.FindByID(licenseID);
            if (localLicense == null)
            {
                DVLDProgram.Show("Error", "Local license not found for the given LicenseID.", MessageBoxIcon.Error);
                return;
            }
            _classID = localLicense.LicenseClassID;

            int personID = PersonBusinessLayer.GetPersonIDByDriverID(localLicense.DriverID);
            if (personID == -1)
            {
                DVLDProgram.Show("Error", "Person not found for the given DriverID.", MessageBoxIcon.Error);
                return;
            }

            clsPerson person = PersonBusinessLayer.FindByID(personID);
            if (person == null)
            {
                DVLDProgram.Show("Error", "Person record not found.", MessageBoxIcon.Error);
                return;
            }
            _personID = person.PersonID;

            ClassName.Text = LicenseClassesBusinessLayer.GetLicenseClassNameByID(localLicense.LicenseClassID);

            Name.Text = person.FullName;
            NationalNo.Text = person.NationalNo;
            Gender.Text = person.Gender;
            DateOfBirth.Text = person.DateOfBirth.ToShortDateString();
            IssueDate.Text = localLicense.IssueDate.ToShortDateString();
            ExpirationDate.Text = localLicense.ExpirationDate.ToShortDateString();
            IssueReason.Text = LocalDrivingLicensesBusinessLayer.GetIssueReasonByID(localLicense.IssueReasonID);
            IsActive.Text = localLicense.IsActive ? "YES" : "NO";
            IsDetained.Text = DetainedLicensesBusinessLayer.IsLicenseDetained(localLicense.LicenseID) ? "YES" : "NO";
            if (string.IsNullOrEmpty(localLicense.Notes))
            {
                Notes.Text = "No Notes Available";
            }
            else
            {
                Notes.Text = localLicense.Notes;
            }
            LicenseID.Text = localLicense.LicenseID.ToString();
            DriverID.Text = localLicense.DriverID.ToString();
            if (string.IsNullOrEmpty(person.ImagePath) == false && System.IO.File.Exists(person.ImagePath))
            {
                DriverImage.Image = Image.FromFile(person.ImagePath);
            }
            else
            {
                if (person.Gender == "Male")
                {
                    DriverImage.Image = Properties.Resources.Noimageavailable_boy;
                }
                else
                {
                    DriverImage.Image = Properties.Resources.Noimageavailable_girl;
                }
            }
        }
    }
}
