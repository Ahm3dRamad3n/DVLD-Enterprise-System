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
    public partial class ManageDetainedLicenses : Form
    {
        private int userPermission = Program.CurrentUser.permissions;

        DataTable dtDetainedLicenses = new DataTable();
        public ManageDetainedLicenses()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            _LoadDetainList();
            dataGridView1.Columns[2].Width = 140;
            dataGridView1.Columns[5].Width = 140;
            dataGridView1.Columns[6].Width = 108;
            dataGridView1.Columns[7].Width = 200;
        }

        private void _LoadDetainList()
        {
            dtDetainedLicenses = DetainedLicensesBusinessLayer.LoadAllDetainedLicenses();
            dataGridView1.DataSource = dtDetainedLicenses;
            RecordsNumber.Text = dataGridView1.Rows.Count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string filter = comboBox1.SelectedItem.ToString();
            if (filter == "DetainID" || filter == "LicenseID" || filter == "ReleaseAppID")
            {
                // Allow only digits and control characters (like backspace)
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Ignore the input
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filter = comboBox1.SelectedItem.ToString();
            string filterExpression = $"Convert({filter}, 'System.String') LIKE '{textBox1.Text}%'";
            DataView dv = new DataView(dtDetainedLicenses);
            dv.RowFilter = filterExpression;
            dataGridView1.DataSource = dv;
            RecordsNumber.Text = $"{dataGridView1.Rows.Count}";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter = comboBox1.SelectedItem.ToString();
            if (filter == "None")
            {
                textBox1.Visible = false;
                dataGridView1.DataSource = dtDetainedLicenses;
                RecordsNumber.Text = $"{dataGridView1.Rows.Count}";
                return;
            }
            textBox1.Clear();
            textBox1.Visible = true;
        }

        //private bool NotSelectedShowMessage()
        //{
        //    if (dataGridView1.SelectedRows.Count == 0)
        //    {
        //        DVLDProgram.Show("No Selection", "Please select a detained license from the list.", MessageBoxIcon.Warning);
        //        return true;
        //    }
        //    return false;
        //}

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (NotSelectedShowMessage())
            //    return;

            clsPerson person = PersonBusinessLayer.FindByNationalNo(dataGridView1.CurrentRow.Cells["NationalNo"].Value.ToString());
            if (person == null)
            {
                DVLDProgram.Show("Error", "Person not found for the selected detained license.", MessageBoxIcon.Error);
                return;
            }
            Form form = new PersonDetails(person);
            form.ShowDialog();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (NotSelectedShowMessage())
            //    return;

            int LicenseID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["LicenseID"].Value);
            Form form = new LocalLicenseDetails(LicenseID);
            form.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (NotSelectedShowMessage())
            //    return;

            clsPerson person = PersonBusinessLayer.FindByNationalNo(dataGridView1.CurrentRow.Cells["NationalNo"].Value.ToString());
            if (person == null)
            {
                DVLDProgram.Show("Error", "Person not found for the selected detained license.", MessageBoxIcon.Error);
                return;
            }
            Form form = new PersonLicenseHistory(person);
            form.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (NotSelectedShowMessage())
            //    return;

            int requiredPermission = (int)DVLDProgram.Permission.ReleaseLicense;
            if ((userPermission & requiredPermission) != requiredPermission)
            {
                DVLDProgram.Show("Access Denied", "You do not have permission to access this feature.", MessageBoxIcon.Warning);
                return;
            }

            int LicenseID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["LicenseID"].Value);
            Form form = new ReleaseOrDetainLicense(LicenseID);
            form.ShowDialog();
            _LoadDetainList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int requiredPermission = (int)DVLDProgram.Permission.DetainLicense;
            if ((userPermission & requiredPermission) != requiredPermission)
            {
                DVLDProgram.Show("Access Denied", "You do not have permission to access this feature.", MessageBoxIcon.Warning);
                return;
            }

            Form form = new ReleaseOrDetainLicense(ReleaseOrDetainLicense.LicenseAction.Detain);
            form.ShowDialog();
            _LoadDetainList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int requiredPermission = (int)DVLDProgram.Permission.ReleaseLicense;
            if ((userPermission & requiredPermission) != requiredPermission)
            {
                DVLDProgram.Show("Access Denied", "You do not have permission to access this feature.", MessageBoxIcon.Warning);
                return;
            }

            Form form = new ReleaseOrDetainLicense(ReleaseOrDetainLicense.LicenseAction.Release);
            form.ShowDialog();
            _LoadDetainList();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            //if (dataGridView1.SelectedRows.Count > 0)
            //{
                bool isReleased = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["IsReleased"].Value);
                releaseDetainedLicenseToolStripMenuItem.Enabled = !isReleased;
            //}
        }
    }
}
