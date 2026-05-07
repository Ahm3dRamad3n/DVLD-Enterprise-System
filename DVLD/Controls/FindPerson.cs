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
    public partial class FindPerson : UserControl
    {
        public delegate void PersonFoundHandler(bool Founded);
        public event PersonFoundHandler PersonFoundEvent;

        public clsPerson Person = null;
        public FindPerson()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        public void DisableEditing()
        {
            groupBoxFillter.Enabled = false;
        }
        private void AddPerson_Click(object sender, EventArgs e)
        {
            AddOrEditPerson form = new AddOrEditPerson();
            form.PersonAddedEvent += AddedSuccessfully;
            form.ShowDialog();
        }

        public void LoadData(clsPerson person)
        {
            Person = person;
            personInfo1.LoadData(Person);
            textBox1.Text = Person.PersonID.ToString();
            comboBox1.SelectedIndex = 0;
        }

        private void AddedSuccessfully(int personID)
        {
            comboBox1.SelectedIndex = 0;
            textBox1.Text = personID.ToString();
            Person = PersonBusinessLayer.FindByID(personID);
            personInfo1.LoadData(Person);
            PersonFoundEvent?.Invoke(true);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "PersonID")
            {
                Person = PersonBusinessLayer.FindByID(Convert.ToInt32(textBox1.Text));
                if (Person != null)
                {
                    personInfo1.LoadData(Person);
                    PersonFoundEvent?.Invoke(true);
                }
                else
                {
                    DVLDProgram.Show("Search Error", "Person not found with ID: " + textBox1.Text, MessageBoxIcon.Error);
                }
            }
            else  // if (comboBox1.SelectedItem.ToString() == "NationalNo")
            {
                Person = PersonBusinessLayer.FindByNationalNo(textBox1.Text);
                if (Person != null)
                {
                    personInfo1.LoadData(Person);
                    PersonFoundEvent?.Invoke(true);
                }
                else
                {
                    DVLDProgram.Show("Search Error", "Person not found with National No: " + textBox1.Text, MessageBoxIcon.Error);
                }
            }
        }
    }
}
