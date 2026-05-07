using Driving_License_Management.FORMS.Add_Only_Forms;
using DVLD_Business_Layer;
using DVLD_DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Driving_License_Management
{
    public partial class ManageInternationalLicenseApp : Form
    {
        private enum pageMode
        {
            ManageApplications,
            ViewLicenses
        }
        private pageMode currentMode = pageMode.ManageApplications;

        private int userPermission = (int)Program.CurrentUser.permissions;
        DataTable dtInternationalLicenses = new DataTable();

        public ManageInternationalLicenseApp()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            _LoadInternationalLicensesData();
        }

        private void _LoadInternationalLicensesData()
        {
            if (currentMode == pageMode.ManageApplications)
            {
                dtInternationalLicenses = ApplicationsBusinessLayer.LoadAll_IDLApplications();
                dataGridView1.DataSource = dtInternationalLicenses;
                dataGridView1.Columns[0].Width = 130;
                dataGridView1.Columns[1].Width = 130;
                dataGridView1.Columns[2].Width = 308;
                dataGridView1.Columns[3].Width = 170;
                dataGridView1.Columns[4].Width = 130;
                dataGridView1.Columns[5].Width = 130;
            }
            else
            {
                dtInternationalLicenses = InternationalLicensesBusinessLayer.LoadAll_IDL_History();
                dataGridView1.DataSource = dtInternationalLicenses;
                dataGridView1.Columns[0].Width = 160;
                dataGridView1.Columns[1].Width = 130;
                dataGridView1.Columns[2].Width = 130;
                dataGridView1.Columns[3].Width = 130;
                dataGridView1.Columns[4].Width = 160;
                dataGridView1.Columns[5].Width = 160;
                dataGridView1.Columns[6].Width = 128;
            }
            
            RecordsNumber.Text = $"{dataGridView1.Rows.Count}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int requiredPermission = (int)DVLDProgram.Permission.AddNewInternationalApp;
            if ((userPermission & requiredPermission) != requiredPermission)
            {
                DVLDProgram.Show("Access Denied", "You do not have permission to access this feature.", MessageBoxIcon.Warning);
                return;
            }

            Form form = new IssueInternationalLicense();
            form.ShowDialog();
            _LoadInternationalLicensesData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter = comboBox1.SelectedItem.ToString();
            if (filter == "None")
            {
                textBox1.Visible = false;
                comboBox2.Visible = false;
                dataGridView1.DataSource = dtInternationalLicenses;
                RecordsNumber.Text = $"{dataGridView1.Rows.Count}";
                return;
            }
            textBox1.Clear();
            if (filter == "IsActive")
            {
                comboBox2.Visible = true;
                textBox1.Visible = false;
                comboBox2.SelectedItem = "ALL";
            }
            else
            {
                textBox1.Visible = true;
                comboBox2.Visible = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filter = comboBox1.SelectedItem.ToString();
            string filterExpression = "";
         
            filterExpression = $"Convert({filter}, 'System.String') LIKE '{textBox1.Text}%'";
         
            DataView dv = new DataView(dtInternationalLicenses);
            dv.RowFilter = filterExpression;
            dataGridView1.DataSource = dv;
            RecordsNumber.Text = $"{dataGridView1.Rows.Count}";
        }

        //private bool NotSelectedShowMessage()
        //{
        //    if (dataGridView1.SelectedRows.Count == 0)
        //    {
        //        DVLDProgram.Show("No Record Selected", "Please select a record first.", MessageBoxIcon.Warning);
        //        return true;
        //    }
        //    return false;
        //}

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (NotSelectedShowMessage())
            //    return;

            int applicationId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ApplicationID"].Value);
            clsApplications application = ApplicationsBusinessLayer.FindByID(applicationId);
            if (application != null)
            {
                Form form = new ApplicationDetails(application);
                form.ShowDialog();
            }
            else
            {
                DVLDProgram.Show("Error", "Application record not found.", MessageBoxIcon.Error);
            }
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (NotSelectedShowMessage())
            //    return;

            int PersonID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ApplicationPersonID"].Value);
            clsPerson person = PersonBusinessLayer.FindByID(PersonID);
            if (person == null)
            {
                DVLDProgram.Show("Error", "Person record not found.", MessageBoxIcon.Error);
                return;
            }

            Form form = new PersonLicenseHistory(person);
            form.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem.ToString() == "ALL")
            {
                textBox1.Text = "";
            }
            else if (comboBox2.SelectedItem.ToString() == "True")
            {
                textBox1.Text = "True";
            }
            else if (comboBox2.SelectedItem.ToString() == "False")
            {
                textBox1.Text = "False";
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string selectedFilter = comboBox1.SelectedItem.ToString();
            if (selectedFilter == "FullName" || selectedFilter == "ApplicationDate") return;

            // All filters are integer based except IsActive
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignore the input
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (currentMode == pageMode.ManageApplications)
            {
                _GoToPageViewLicenses();
            }
            else
            {
                _ReturnToPageManageApplication();
            }
        }

        private void _GoToPageViewLicenses()
        {
            currentMode = pageMode.ViewLicenses;
            button3.Text = "Manage Applications";
            button3.Image = Properties.Resources.applications;
            label1.Text = "International Driving Licenses History";
            pictureBox1.Image = Properties.Resources.worldFullSize;
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new string[] { "None", "InternationalLicenseID", "ApplicationID", "DriverID", "LocalLicenseID", "IsActive" });
            comboBox1.SelectedIndex = 0;
            comboBox2.Visible = false;
            textBox1.Visible = false;
            _LoadInternationalLicensesData();
            dataGridView1.ContextMenuStrip = contextMenuStrip2;
        }
        private void _ReturnToPageManageApplication()
        {
            currentMode = pageMode.ManageApplications;
            button3.Text = "View Licenses";
            button3.Image = Properties.Resources.world32;
            label1.Text = "International License Applications";
            pictureBox1.Image = Properties.Resources.unnamed__4__removebg_preview;
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(new string[] { "None", "ApplicationID", "ApplicationPersonID", "FullName", "ApplicationDate", "CreatedByUserID" });
            comboBox1.SelectedIndex = 0;
            comboBox2.Visible = false;
            textBox1.Visible = false;
            _LoadInternationalLicensesData();
            dataGridView1.ContextMenuStrip = contextMenuStrip1;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int licenseId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["InternationalLicenseID"].Value);
            Form form = new InternationalLicenseDetails(licenseId);
            form.ShowDialog();
        }
    }
}
