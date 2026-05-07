using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using DVLD_DTOs;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using DVLD_Business_Layer;

namespace Driving_License_Management
{
    public partial class AddOrEditApplication : Form
    {
        clsPerson _Person = new clsPerson();

        clsApplications Application = new clsApplications();
        private int ALId = -1;
        private enum Mode
        {
            Add,
            Edit
        }
        private Mode _currentMode = Mode.Add;

        public AddOrEditApplication()
        {
            InitializeComponent();
            _Global_InitalizeForm();
            _Add_InitalizeForm();
        }
        public AddOrEditApplication(clsApplications application, int ALId)
        {
            InitializeComponent();
            Application = application;
            this.ALId = ALId;
            _Global_InitalizeForm();
            _Edit_InitalizeForm();
        }
        private void _Global_InitalizeForm()
        {
            Application.PaidFees = ApplicationsBusinessLayer.GetAppFees(1);
            if (Application.PaidFees == -1)
            {
                DVLDProgram.Show("Error", "New license application fee is not set. Please contact administrator.", MessageBoxIcon.Error);
                this.Close();
            }
            _LoadLicenseClasses();
            Application.ApplicationTypeID = 1; // New Local License
            label6.Text = Application.ApplicationDate.ToShortDateString();
            label7.Text = Application.PaidFees.ToString();
        }
        private void _Add_InitalizeForm()
        {
            comboBox2.SelectedIndex = 0;
            Application.CreatedByUserID = Program.CurrentUser.UserID;
            label9.Text = Program.CurrentUser.UserName;
        }
        private void _Edit_InitalizeForm()
        {
            _currentMode = Mode.Edit;
            AppID.Text = Application.ApplicationID.ToString();
            AppLID.Text = ALId.ToString();
            _Person = PersonBusinessLayer.FindByID(Application.ApplicationPersonID);
            findPerson1.LoadData(_Person);
            findPerson1.DisableEditing();
            next.Enabled = true;
            comboBox2.SelectedIndex = LicenseClassesBusinessLayer.GetLicenseClassIDByALId(ALId) - 1;
            Title.Text = "Update Local Driving License Application";
            label9.Text = UsersBusinessLayer.GetUserNameByID(Application.CreatedByUserID);
        }

        private void _LoadLicenseClasses()
        {
            DataTable dt = LicenseClassesBusinessLayer.GetLicenseClassesList();
            foreach (DataRow dr in dt.Rows)
            {
                comboBox2.Items.Add(dr["ClassName"].ToString());
            }
        }

        private void findPerson1_PersonFoundEvent(bool Founded)
        {
            next.Enabled = true;
        }

        private void next_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = AppInfo;
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == AppInfo)
            {
                if (next.Enabled == false)
                {
                    DVLDProgram.Show("Error", "Please load a person first.", MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (next.Enabled == false)
            {
                DVLDProgram.Show("Error", "Please load a person first.", MessageBoxIcon.Error);
                return;
            }

            _Person = findPerson1.Person;

            Application.ApplicationPersonID = _Person.PersonID;

            // if person already has a local driving license and the same class is requested and not cancelled, do not allow new application
            int requestedClassID = comboBox2.SelectedIndex + 1;
            int ApplicationID = AppLicenseBusinessLayer.GetActiveAppIDForLicenseClass(_Person.PersonID, requestedClassID);
            if (ApplicationID != -1)
            {
                DVLDProgram.Show("Error", "Person already has a local driving license of the requested class that is not cancelled. Cannot issue new license of the same class.", MessageBoxIcon.Error);
                return;
            }

            if (_currentMode == Mode.Add)
            {
                bool AddApp = ApplicationsBusinessLayer.AddNewApplication(Application);
                if (AddApp)
                {
                    int appID = Application.ApplicationID;
                    bool AddLicense = AppLicenseBusinessLayer.IssueNewLicense(appID, comboBox2.SelectedIndex + 1, ref ALId);
                    if (AddLicense)
                    {
                        DVLDProgram.Show("Success", "Application and License added successfully.", MessageBoxIcon.Information);
                        AppID.Text = appID.ToString();
                        AppLID.Text = ALId.ToString();
                        _currentMode = Mode.Edit;
                        Title.Text = "Update Local Driving License Application";
                    }
                    else
                    {
                        DVLDProgram.Show("Error", "Application added but error issuing license.", MessageBoxIcon.Error);
                    }
                }
                else
                {
                    DVLDProgram.Show("Error", "Error adding application.", MessageBoxIcon.Error);
                }
            }
            else if (_currentMode == Mode.Edit)
            {
                bool EditApp = ApplicationsBusinessLayer.UpdateApplication(Application);
                if (EditApp)
                {
                    bool EditLicense = AppLicenseBusinessLayer.UpdateLicenseClassByALId(ALId, comboBox2.SelectedIndex + 1);
                    if (EditLicense)
                    {
                        DVLDProgram.Show("Success", "Application and License updated successfully.", MessageBoxIcon.Information);
                    }
                    else
                    {
                        DVLDProgram.Show("Error", "Application updated but error updating license.", MessageBoxIcon.Error);
                    }
                }
                else
                {
                    DVLDProgram.Show("Error", "Error updating application.", MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void findPerson1_Load(object sender, EventArgs e)
        {
            this.findPerson1.PersonFoundEvent += findPerson1_PersonFoundEvent;

        }
    }
}
