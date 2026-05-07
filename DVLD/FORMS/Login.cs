using Microsoft.Win32;
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
using System.Configuration;
namespace Driving_License_Management
{
    public partial class Login : Form
    {
        bool signOut = false;
        bool isLoadingCredentials = false;
        private readonly string regKeyPath = ConfigurationManager.ConnectionStrings["RegistryKeyPath"].ConnectionString;
        public Login()
        {
            InitializeComponent();
            
        }

        private void Login_Shown(object sender, EventArgs e)
        {
            // Load saved username and password if "Remember Me" was checked
            LoadSavedUserNameAndPassword();
        }
        private void LoadSavedUserNameAndPassword()
        {
            textBox1.Clear();
            textBox2.Clear();

            try
            {
                string Username = Registry.GetValue(regKeyPath, "SavedUsername", null) as string;
                string Password = Registry.GetValue(regKeyPath, "SavedPassword", null) as string;
                if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
                {
                    textBox1.Text = Username;
                    textBox2.Text = Password;
                    rememberme.Checked = true;
                    btnLogin.Focus();
                    isLoadingCredentials = true;
                }
            }
            catch (Exception ex)
            {
                DVLDProgram.Show("Error", "An error occurred while loading saved credentials: \n" + ex.Message, MessageBoxIcon.Error);
            }
        }
        private void SaveCredentials(string username, string password)
        {
            try
            {
                Registry.SetValue(regKeyPath, "SavedUsername", textBox1.Text);
                Registry.SetValue(regKeyPath, "SavedPassword", textBox2.Text);
            }
            catch (Exception ex)
            {
                DVLDProgram.Show("Error", "An error occurred while saving credentials: \n" + ex.Message, MessageBoxIcon.Error);
            }
        }
        private void DeleteSavedCredentials()
        {
            try
            {
                using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    string keyPath = regKeyPath.Replace("HKEY_CURRENT_USER\\", "");
                    using (RegistryKey key = baseKey.OpenSubKey(keyPath, true))
                    {
                        if (key != null)
                        {
                            if (key.GetValue("SavedUsername") != null) key.DeleteValue("SavedUsername");
                            if (key.GetValue("SavedPassword") != null) key.DeleteValue("SavedPassword");
                        }
                        else
                        {
                            DVLDProgram.Show("No Saved Credentials", "No saved credentials found to delete.", MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                DVLDProgram.Show("Permission Denied", "You do not have permission to delete the saved credentials from the registry.", MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                DVLDProgram.Show("Error", "An error occurred while deleting saved credentials: \n"  + ex.Message, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                DVLDProgram.Show("Login Failed", "Username or Password cannot be empty. Please enter both.", MessageBoxIcon.Error);
                return;
            }

            string hashedPassword = UsersBusinessLayer.HashPassword(textBox2.Text);
            Program.CurrentUser = UsersBusinessLayer.Find(textBox1.Text, hashedPassword);
            if (Program.CurrentUser == null)
            {
                DVLDProgram.Show("Login Failed", "Invalid username\\Email or password. Please try again.", MessageBoxIcon.Error);
                return;
            }

            if (!Program.CurrentUser.IsActive)
            {
                DVLDProgram.Show("Login Failed", "Your account is inactive. Please contact the administrator.", MessageBoxIcon.Warning);
                return;
            }

            if (rememberme.Checked)
            {
                // save username and password in Registry
                SaveCredentials(textBox1.Text, textBox2.Text);
            }
            else
            {
                if (isLoadingCredentials)
                {
                    // If credentials were loaded, delete them from the registry
                    DeleteSavedCredentials();
                    isLoadingCredentials = false;
                }
            }

            this.Hide();
            MainForm mainForm = new MainForm();
            mainForm.SignOutEvent += MainForm_SignOutEvent;
            mainForm.ShowDialog();

            if (signOut)
            {
                this.Show();
                textBox1.Focus();
                signOut = false;
                LoadSavedUserNameAndPassword();
                return;
            }

            this.Close();
        }

        private void MainForm_SignOutEvent(bool SignOut)
        {
            signOut = SignOut;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.Enabled = false; // Disable the link to prevent multiple clicks

            ResetPasswordUsingVerification();

            linkLabel1.Enabled = true; 
        }

        private void ResetPasswordUsingVerification()
        {
            if (textBox1.Text == "")
            {
                DVLDProgram.Show("Input Required", "Please enter your username or email to reset your password.", MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }

            string usernameOrEmail = textBox1.Text;
            int userID = UsersBusinessLayer.FindByUsernameOrEmail(usernameOrEmail);

            if (userID == -1)
            {
                DVLDProgram.Show("User Not Found", "No user found with the provided username or email. Please check your input and try again.", MessageBoxIcon.Error);
                return;
            }

            SendEmail sendEmailForm = new SendEmail(UsersBusinessLayer.GetEmailByUserID(userID), SendEmail.SendEmailMode.PasswordReset, userID);
            sendEmailForm.ShowDialog();
        }

        private void llportfolio_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://ahm3dramad3n.github.io/portfolio/en/");
        }
    }
}
