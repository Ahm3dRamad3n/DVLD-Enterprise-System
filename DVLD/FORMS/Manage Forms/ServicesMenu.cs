using Driving_License_Management.FORMS.Add_Only_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DVLD_DTOs;
using System.Windows.Forms;

namespace Driving_License_Management.FORMS
{
    public partial class ServicesMenu : Form
    {
        private int userPermission = Program.CurrentUser.permissions;

        public ServicesMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(button1, new Point(0, button1.Height));
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int requiredPermission = (int)DVLDProgram.Permission.AddNewLocalLicenseApp;
            if ((userPermission & requiredPermission) != requiredPermission)
            {
                DVLDProgram.Show("Access Denied", "You do not have permission to access this feature.", MessageBoxIcon.Warning);
                return;
            }

            Form form = new AddOrEditApplication();
            form.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int requiredPermission = (int)DVLDProgram.Permission.AddNewInternationalApp;
            if ((userPermission & requiredPermission) != requiredPermission)
            {
                DVLDProgram.Show("Access Denied", "You do not have permission to access this feature.", MessageBoxIcon.Warning);
                return;
            }

            Form form  = new IssueInternationalLicense();
            form.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int requiredPermission = (int)DVLDProgram.Permission.ManageLocalDrivingApp;
            if ((userPermission & requiredPermission) != requiredPermission)
            {
                DVLDProgram.Show("Access Denied", "You do not have permission to access this feature.", MessageBoxIcon.Warning);
                return;
            }

            Form form = new ManageLocalLicenseApp();
            form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int requiredPermission = (int)DVLDProgram.Permission.ReplacementLicense;
            if ((userPermission & requiredPermission) != requiredPermission)
            {
                DVLDProgram.Show("Access Denied", "You do not have permission to access this feature.", MessageBoxIcon.Warning);
                return;
            }

            Form form = new ReplacedLicenseApp();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int requiredPermission = (int)DVLDProgram.Permission.RenewLicense;
            if ((userPermission & requiredPermission) != requiredPermission)
            {
                DVLDProgram.Show("Access Denied", "You do not have permission to access this feature.", MessageBoxIcon.Warning);
                return;
            }

            Form form = new RenewLicenseApp();
            form.ShowDialog();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            int requiredPermission = (int)DVLDProgram.Permission.ReleaseLicense;
            if ((userPermission & requiredPermission) != requiredPermission)
            {
                DVLDProgram.Show("Access Denied", "You do not have permission to access this feature.", MessageBoxIcon.Warning);
                return;
            }

            Form form = new ReleaseOrDetainLicense(ReleaseOrDetainLicense.LicenseAction.Release);
            form.ShowDialog();
        }
    }
}
