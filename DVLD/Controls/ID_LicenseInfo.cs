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
    public partial class ID_LicenseInfo : UserControl
    {
        public ID_LicenseInfo()
        {
            InitializeComponent();
        }
        public void LoadData(int Int_licenseID)
        {
            clsInternationalLicense IntLicense = InternationalLicensesBusinessLayer.FindByID(Int_licenseID);
            if (IntLicense == null)
            {
                DVLDProgram.Show("Error", "International License record not found.", MessageBoxIcon.Error);
                return;
            }

            int personID = PersonBusinessLayer.GetPersonIDByDriverID(IntLicense.DriverID);
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

            Name.Text = person.FullName;
            InternationaLID.Text = IntLicense.InternationalLicenseID.ToString();
            ApplicationID.Text = IntLicense.ApplicationID.ToString();
            NationalNo.Text = person.NationalNo;
            Gender.Text = person.Gender;
            DateOfBirth.Text = person.DateOfBirth.ToShortDateString();
            IssueDate.Text = IntLicense.IssueDate.ToShortDateString();
            ExpirationDate.Text = IntLicense.ExpirationDate.ToShortDateString();
            IsActive.Text = IntLicense.IsActive ? "YES" : "NO";
            LocalLicenseID.Text = IntLicense.IssuedUsingLocalLicenseID.ToString();
            DriverID.Text = IntLicense.DriverID.ToString();
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
