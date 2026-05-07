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
    public partial class UpdateAppTypes : Form
    {
        private int _appTypeID;
        public UpdateAppTypes(int appTypeID, string appTypeTitle, int appTypeFee)
        {
            InitializeComponent();
            _appTypeID = appTypeID;
            label4.Text = appTypeID.ToString();
            textBox1.Text = appTypeTitle;
            textBox2.Text = appTypeFee.ToString();
        }

        private void UpdateAppTypes_Load(object sender, EventArgs e)
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
                DVLDProgram.Show("Input Error", "Please enter a valid application type name.", MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                DVLDProgram.Show("Input Error", "Please enter a valid Fee amount.", MessageBoxIcon.Error);
                return;
            }

            if (ApplicationsBusinessLayer.UpdateAppType(_appTypeID, textBox1.Text.Trim(), int.Parse(textBox2.Text.Trim())))
            {
                DVLDProgram.Show("Success", "Application type updated successfully.", MessageBoxIcon.Information);
                
            }
            else
            {
                DVLDProgram.Show("Error", "Failed to update application type.", MessageBoxIcon.Error);
            }
        }
    }
}
