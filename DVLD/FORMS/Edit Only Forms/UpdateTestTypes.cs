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
    public partial class UpdateTestTypes : Form
    {
        private int _testTypeID;
        public UpdateTestTypes(int testTypeID, string testTypeTitle, string testTypeDescription, int testTypeFee)
        {
            InitializeComponent();
            _testTypeID = testTypeID;
            label4.Text = testTypeID.ToString();
            textBox1.Text = testTypeTitle;
            textBox2.Text = testTypeFee.ToString();
            textBox3.Text = testTypeDescription;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                DVLDProgram.Show("Input Error", "Please enter a valid test type name.", MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                DVLDProgram.Show("Input Error", "Please enter a valid Fee amount.", MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                DVLDProgram.Show("Input Error", "Please enter a valid description.", MessageBoxIcon.Error);
                return;
            }

            if (TestsBusinessLayer.UpdateTestType(_testTypeID, textBox1.Text.Trim(), textBox3.Text.Trim(), int.Parse(textBox2.Text.Trim())))
            {
                DVLDProgram.Show("Success", "Test type updated successfully.", MessageBoxIcon.Information);

            }
            else
            {
                DVLDProgram.Show("Error", "Failed to update test type.", MessageBoxIcon.Error);
            }
        }
    }
}
