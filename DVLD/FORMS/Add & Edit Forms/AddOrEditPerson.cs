
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient; 
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using DVLD_DTOs;
using System.Windows.Forms;
using static Driving_License_Management.PersonDetails;
using DVLD_Business_Layer;
namespace Driving_License_Management
{
    public partial class AddOrEditPerson : Form
    {
        public class cmdEnterEventArgs : EventArgs
        {
            public Keys KeyData { get; }
            public clsPerson person { get; set; }
            public cmdEnterEventArgs(Keys keyData)
            {
                KeyData = keyData;
            }
        }
        public event EventHandler<cmdEnterEventArgs> MoveTo;

        public delegate void PersonAddedHandler(int personID);
        public event PersonAddedHandler PersonAddedEvent;

        clsPerson _person = new clsPerson();
        string ImagePath = string.Empty;
        private enum Mode
        {
            Add,
            Edit
        }
        private Mode _currentMode = Mode.Add;
        public AddOrEditPerson()
        {
            InitializeComponent();
            LoadCountryList();
            CountryList.SelectedIndex = 50; // Egypt
        }

        public AddOrEditPerson(clsPerson person)
        {
            InitializeComponent();
            Title.Text = "Update Person";
            LoadCountryList();
            _currentMode = Mode.Edit;
            LoadData(person);
        }

        private void LoadData(clsPerson person)
        {
            _person = person;
            ID.Text = person.PersonID.ToString();
            FirstName.Text = person.FirstName;
            SecondName.Text = person.SecondName;
            ThirdName.Text = person.ThirdName;
            LastName.Text = person.LastName;
            NationalNo.Text = person.NationalNo;
            Address.Text = person.Address;
            Phone.Text = person.PhoneNumber;
            DateOfBirth.Value = person.DateOfBirth;
            Email.Text = person.Email;
            CountryList.SelectedItem = person.Country;

            if (person.Gender == "Male")
                radioButton1.Checked = true;
            else radioButton2.Checked = true;
            LoadPersonImage(person.ImagePath);

            ImagePath = person.ImagePath;
        }

        private void LoadPersonImage(string path)
        {
            // Clear Current Image
            pictureBox1.ImageLocation = null;
            if (pictureBox1.Image != null)
            {
                var oldImage = pictureBox1.Image;
                pictureBox1.Image = null;
                oldImage.Dispose();
            }

            // Load new image if path is valid, otherwise load default image based
            if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
            {
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    pictureBox1.Image = Image.FromStream(fs); // Load image from file stream to avoid locking the file
                }
            }
            else
            {
                pictureBox1.Image = radioButton1.Checked ? Properties.Resources.Noimageavailable_boy : Properties.Resources.Noimageavailable_girl;
            }
        }

        private void LoadCountryList()
        {
            DataTable dtCountries = CountryBusinessLayer.List();
            foreach (DataRow row in dtCountries.Rows)
            {
                CountryList.Items.Add(row["CountryName"].ToString());
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ImagePath = openFileDialog.FileName;
                LoadPersonImage(ImagePath);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ImagePath = string.Empty;
            LoadPersonImage(ImagePath);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (FirstName.Text == "" || SecondName.Text == "" || LastName.Text == "" ||
                NationalNo.Text == "" || Address.Text == "" || Email.Text == "" ||
                CountryList.SelectedItem == null)
            {
                DVLDProgram.Show("Input Error", "Please fill in all required fields.", MessageBoxIcon.Error);
                return;
            }

            _person.FirstName = FirstName.Text;
            _person.SecondName = SecondName.Text;
            _person.ThirdName = ThirdName.Text;
            _person.LastName = LastName.Text;
            _person.NationalNo = NationalNo.Text;
            _person.Address = Address.Text;
            _person.PhoneNumber = Phone.Text;
            _person.DateOfBirth = DateOfBirth.Value;
            _person.Country = CountryList.SelectedItem.ToString();
            _person.CountryID = CountryList.SelectedIndex + 1; // Assuming CountryID starts from 1
            if (radioButton1.Checked == true)
                _person.Gender = "Male";
            else _person.Gender = "Female";


            if (_currentMode == Mode.Add || _person.Email != Email.Text.Trim())
            {
                if (!VerifyEmail(Email.Text.Trim()))
                {
                    DVLDProgram.Show("Email Verification Failed", "The provided email address could not be verified. Please check the email and try again.", MessageBoxIcon.Error);
                    return;
                }
            }

            _person.Email = Email.Text.Trim();

            // save path image in local folder and set image path
            if (ImagePath != _person.ImagePath)
            {
                string destPath = string.Empty;
                if (ImagePath != string.Empty)
                {
                    destPath = Path.Combine("Persons Images", Guid.NewGuid().ToString() + Path.GetExtension(ImagePath));
                    Directory.CreateDirectory(Path.GetDirectoryName(destPath));
                    File.Copy(ImagePath, destPath, true);
                }

                if (!string.IsNullOrEmpty(_person.ImagePath) && File.Exists(_person.ImagePath))
                {
                    try
                    {
                        LoadPersonImage(destPath); // Reload the new image before deleting the old one to ensure it's not in use
                        File.Delete(_person.ImagePath);
                    }
                    catch (IOException ex)
                    {
                        DVLDProgram.Show("Warning", "Could not delete old image file because it is in use. " + ex.Message, MessageBoxIcon.Warning);
                    }
                }

                _person.ImagePath = destPath;
            }

            if (_currentMode == Mode.Add)
            {
                try
                {
                    bool success = PersonBusinessLayer.AddPerson(ref _person);
                    if (success)
                    {
                        _currentMode = Mode.Edit;
                        Title.Text = "Update Person";
                        ID.Text = _person.PersonID.ToString();
                        PersonAddedEvent?.Invoke(_person.PersonID);
                        DVLDProgram.Show("Success", "Person added successfully.", MessageBoxIcon.Information);
                    }
                    else
                    {
                        DVLDProgram.Show("Error", "Failed to add person. Please try again.", MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    DVLDProgram.Show("Error", "An error occurred while adding the person: " + ex.Message, MessageBoxIcon.Error);
                }
            }
            else if (_currentMode == Mode.Edit)
            {
                try
                {
                    bool success = PersonBusinessLayer.UpdatePerson(_person);
                    if (success)
                    {
                        DVLDProgram.Show("Success", "Person updated successfully.", MessageBoxIcon.Information);
                    }
                    else
                    {
                        DVLDProgram.Show("Error", "Failed to update person. Please try again.", MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    DVLDProgram.Show("Error", "An error occurred while updating the person: " + ex.Message, MessageBoxIcon.Error);
                }
            }
        }

        private bool VerifyEmail(string email)
        {
            bool isVerified = false;
            SendEmail VerifyForm = new SendEmail(email, SendEmail.SendEmailMode.VerifyOnly);
            VerifyForm.VerifyCredentialsCompleted += (IsVerified) =>
            {
                isVerified = IsVerified;
            };
            VerifyForm.ShowDialog();
            return isVerified;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (ImagePath == string.Empty)
            {
                pictureBox1.Image = Properties.Resources.Noimageavailable_girl;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (ImagePath == string.Empty)
            {
                pictureBox1.Image = Properties.Resources.Noimageavailable_boy;
            }
        }

        private void NationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NationalNo.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(NationalNo, "National No is required.");
                return;
            }

            if (PersonBusinessLayer.IsExist(NationalNo.Text) && (_currentMode == Mode.Add ||
            (_currentMode == Mode.Edit && _person.NationalNo.ToLower() != NationalNo.Text.ToLower())))
            {
                e.Cancel = true;
                errorProvider1.SetError(NationalNo, "National No already exists.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(NationalNo, null);
            }
        }

        private void Email_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Email.Text))
            {   e.Cancel = true;
                errorProvider1.SetError(Email, "Email is required.");
                return;
            }

            if (!SendEmail.IsValidEmail(Email.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(Email, "Invalid email format.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(Email, null);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (_currentMode == Mode.Edit && (keyData == Keys.Up || keyData == Keys.Down))
            {
                cmdEnterEventArgs args = new cmdEnterEventArgs(keyData);
                MoveTo?.Invoke(this, args);
                if (args.person != null)
                {
                    LoadData(args.person);
                }
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
