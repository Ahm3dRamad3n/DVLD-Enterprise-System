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
    public partial class ChangePassword : Form
    {
        clsUser currentUser;
        public ChangePassword(clsUser user)
        {
            InitializeComponent();
            currentUser = user;
            personInfo1.LoadData(user.Person);
            user_Perm1.LoadData(user);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                DVLDProgram.Show("Error", "Please fill the password fields correctly.", MessageBoxIcon.Error);
                return;
            }

            string hashedInputPassword = UsersBusinessLayer.HashPassword(textBox1.Text);
            if (hashedInputPassword != currentUser.Password)
            {
                DVLDProgram.Show("Error", "Current password is incorrect.", MessageBoxIcon.Error);
                return;
            }

            if (textBox2.Text != textBox3.Text)
            {
                DVLDProgram.Show("Error", "New passwords do not match.", MessageBoxIcon.Error);
                return;
            }

            string newHashedPassword = UsersBusinessLayer.HashPassword(textBox3.Text);
            if (UsersBusinessLayer.ChangePassword(currentUser.UserID, newHashedPassword))
            {
                DVLDProgram.Show("Success", "Password changed successfully.", MessageBoxIcon.Information);
                currentUser.Password = newHashedPassword;
            }
            else
            {
                DVLDProgram.Show("Error", "Failed to change password.", MessageBoxIcon.Error);
            }
        }
    }
}
