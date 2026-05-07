using Driving_License_Management.FORMS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DVLD_DTOs;
using System.Windows.Forms;

namespace Driving_License_Management
{
    public partial class MainForm : Form
    {
        public delegate void SignOutHandler(bool signOut);
        public event SignOutHandler SignOutEvent;

        private int userPermission = Program.CurrentUser.permissions;

        public MainForm()
        {
            InitializeComponent();
        }

        private void pepoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int requiredPermission = (int)DVLDProgram.Permission.ManagePeople;
            if ((userPermission & requiredPermission) != requiredPermission)
            {
                DVLDProgram.Show("Permission Denied", "You do not have permission to access the Manage People feature.", MessageBoxIcon.Warning);
                return;
            }

            Form form = new ManagePeople();
            form.ShowDialog();
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Sign out logic
            SignOutEvent?.Invoke(true);
            this.Close();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new UserDetails(Program.CurrentUser);
            form.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new ChangePassword(Program.CurrentUser);
            form.ShowDialog();
        }

        private void editUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new AddOrEditPerson(Program.CurrentUser.Person);
            form.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int requiredPermission = (int)DVLDProgram.Permission.ManageApplicationTypes;
            if ((userPermission & requiredPermission) != requiredPermission)
            {
                DVLDProgram.Show("Permission Denied", "You do not have permission to access the Manage Application Types feature.", MessageBoxIcon.Warning);
                return;
            }

            Form form = new ManageAppTypes();
            form.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int requiredPermission = (int)DVLDProgram.Permission.ManageTestTypes;
            if ((userPermission & requiredPermission) != requiredPermission)
            {
                DVLDProgram.Show("Permission Denied", "You do not have permission to access the Manage Test Types feature.", MessageBoxIcon.Warning);
                return;
            }

            Form form = new ManageTestTypes();
            form.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int requiredPermission = (int)DVLDProgram.Permission.ManageUsers;
            if ((userPermission & requiredPermission) != requiredPermission)
            {
                DVLDProgram.Show("Permission Denied", "You do not have permission to access the Manage Users feature.", MessageBoxIcon.Warning);
                return;
            }

            Form form = new ManageUsers();
            form.ShowDialog();
        }

        private void drivingLiensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new ServicesMenu();
            form.ShowDialog();
        }

        private void localDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int requiredPermission = (int)DVLDProgram.Permission.ManageLocalDrivingApp;
            if ((userPermission & requiredPermission) != requiredPermission)
            {
                DVLDProgram.Show("Permission Denied", "You do not have permission to access the Manage Local License Application feature.", MessageBoxIcon.Warning);
                return;
            }

            Form form = new ManageLocalLicenseApp();
            form.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int requiredPermission = (int)DVLDProgram.Permission.ManageDrivers;
            if ((userPermission & requiredPermission) != requiredPermission)
            {
                DVLDProgram.Show("Permission Denied", "You do not have permission to access the Manage Drivers feature.", MessageBoxIcon.Warning);
                return;
            }

            Form form = new ManageDrivers();
            form.ShowDialog();
        }

        private void internayionalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int requiredPermission = (int)DVLDProgram.Permission.ManageInternationalApp;
            if ((userPermission & requiredPermission) != requiredPermission)
            {
                DVLDProgram.Show("Permission Denied", "You do not have permission to access the Manage International License Application feature.", MessageBoxIcon.Warning);
                return;
            } 

            Form form = new ManageInternationalLicenseApp();
            form.ShowDialog();
        }

        private void manageDetainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int requiredPermission = (int)DVLDProgram.Permission.ManageDetainedLicenses;
            if ((userPermission & requiredPermission) != requiredPermission)
            {
                DVLDProgram.Show("Permission Denied", "You do not have permission to access the Manage Detained Licenses feature.", MessageBoxIcon.Warning);
                return;
            } 

            Form form = new ManageDetainedLicenses();
            form.ShowDialog();
        }

        private void detainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int requiredPermission = (int)DVLDProgram.Permission.DetainLicense;
            if ((userPermission & requiredPermission) != requiredPermission)
            {
                DVLDProgram.Show("Permission Denied", "You do not have permission to access the Detain License feature.", MessageBoxIcon.Warning);
                return;
            } 

            Form form = new ReleaseOrDetainLicense(ReleaseOrDetainLicense.LicenseAction.Detain);
            form.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int requiredPermission = (int)DVLDProgram.Permission.ReleaseLicense;
            if ((userPermission & requiredPermission) != requiredPermission)
            {
                DVLDProgram.Show("Permission Denied", "You do not have permission to access the Release License feature.", MessageBoxIcon.Warning);
                return;
            }

            Form form = new ReleaseOrDetainLicense(ReleaseOrDetainLicense.LicenseAction.Release);
            form.ShowDialog();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (Program.CurrentUser.UserName.ToLower() == "admin")
            {
                showDBTabelsToolStripMenuItem.Visible = true;
            }
        }

        private void showDBTabelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new ShowDBTables();
            form.ShowDialog();
        }

        private void llportfolio_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://ahm3dramad3n.github.io/portfolio/en/");
        }
    }
}
