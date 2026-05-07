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
    public partial class PersonInfo : UserControl
    {
        clsPerson _person = new clsPerson();
        public PersonInfo()
        {
            InitializeComponent();
        }
        public void LoadData(clsPerson person)
        {
            _person = person;
            label13.Text = person.PersonID.ToString();
            label11.Text = person.NationalNo;
            label12.Text = person.FullName;
            label14.Text = person.Gender;
            dateTimePicker1.Value = person.DateOfBirth;
            label15.Text = person.PhoneNumber;
            label16.Text = person.Address;
            label17.Text = person.Email;
            label18.Text = person.Country;
            if (!string.IsNullOrEmpty(person.ImagePath))
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(person.ImagePath);
                }
                catch
                {
                    DVLDProgram.Show("Error", "Image file not found", MessageBoxIcon.Error);
                }
            }
            else
            {
                if (person.Gender == "Male")
                    pictureBox1.Image = Properties.Resources.Noimageavailable_boy;
                else pictureBox1.Image = Properties.Resources.Noimageavailable_girl;

            }
        }
        private void _ReloadData() 
        {
            _person = PersonBusinessLayer.FindByID(_person.PersonID);
            LoadData(_person);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.patient_boy72;
            Form form = new AddOrEditPerson(_person);
            form.ShowDialog();
            _ReloadData();
        }
    }
}
