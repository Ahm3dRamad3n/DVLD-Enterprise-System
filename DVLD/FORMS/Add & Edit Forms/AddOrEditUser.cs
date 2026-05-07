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
    public partial class AddOrEditUser : Form
    {
        clsUser User = new clsUser();
        private enum Mode
        {
            Add,
            Edit
        }
        private Mode _currentMode = Mode.Add;
        public AddOrEditUser()
        {
            InitializeComponent();
        }
        public AddOrEditUser(clsUser user)
        {
            InitializeComponent();
            Title.Text = "Update User";
            _currentMode = Mode.Edit;
            next.Enabled = true;

            User = user;
            ID.Text = user.UserID.ToString();
            textBox4.Text = user.UserName;
            txtPassword.Text = txtConfirmPassword.Text = "*********";
            txtPassword.Enabled = txtConfirmPassword.Enabled = false;
            checkBox1.Checked = user.IsActive;

            findPerson1.LoadData(User.Person);
            findPerson1.DisableEditing();
            permissions1.LoadPermissionsIntoList(user.permissions);
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void next_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = LoginInfo;
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == LoginInfo)
            {
                if (next.Enabled == false)
                {
                    DVLDProgram.Show("Error", "Please load a person first.", MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }
        
        private void findPerson1_PersonFoundEvent(bool Founded)
        {
            next.Enabled = Founded;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (next.Enabled == false)
            {
                DVLDProgram.Show("Error", "Please load a person first.", MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                DVLDProgram.Show("Input Error", "Please fill in all required fields.", MessageBoxIcon.Error);
                return;
            }

            User.Person = findPerson1.Person;
            User.UserName = textBox4.Text;
            User.IsActive = checkBox1.Checked;
            User.permissions = permissions1.GetPermissionsNumberFromList();
            
            if (_currentMode == Mode.Add)
            {
                User.Password = UsersBusinessLayer.HashPassword(txtPassword.Text);
                bool success = UsersBusinessLayer.AddNewUser(ref User);
                if (success)
                {
                    ID.Text = User.UserID.ToString();
                    _currentMode = Mode.Edit;
                    Title.Text = "Update User";
                    findPerson1.DisableEditing();
                    txtPassword.Enabled = txtConfirmPassword.Enabled = false;
                    DVLDProgram.Show("Success", "User added successfully.", MessageBoxIcon.Information);
                }
                else
                {
                    DVLDProgram.Show("Error", "Failed to add user. The username might already exist.", MessageBoxIcon.Error);
                }
            }
            else if (_currentMode == Mode.Edit)
            {
                bool success = UsersBusinessLayer.UpdateUserInfo(User);
                if (success)
                {
                    DVLDProgram.Show("Success", "User updated successfully.", MessageBoxIcon.Information);
                }
                else
                {
                    DVLDProgram.Show("Error", "Failed to update user.", MessageBoxIcon.Error);
                }
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox4, "Username cannot be empty.");
                return;
            }

            if (UsersBusinessLayer.IsUserNameExist(textBox4.Text) && (_currentMode == Mode.Add || textBox4.Text.ToLower() != User.UserName.ToLower()))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox4, "Username already exists. Please choose another one.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textBox4, null);
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text != txtPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Passwords do not match.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = false;

            if (txtConfirmPassword.Text != txtPassword.Text)
            {
                txtConfirmPassword.Focus();
            }
        }

        private void findPerson1_Load(object sender, EventArgs e)
        {
            this.findPerson1.PersonFoundEvent += findPerson1_PersonFoundEvent;
        }
    }
}
