using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DVLD_DTOs;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Net.Mime.MediaTypeNames;
using DVLD_Business_Layer;

namespace Driving_License_Management
{
    public partial class PersonLicenseHistory : Form
    {
        clsPerson _person;
        public PersonLicenseHistory(clsPerson person)
        {
            InitializeComponent();
            _person = person;
            personInfo1.LoadData(person);
            _LoadLicensesHistoryData(person.PersonID);

            dataGridView1.Columns["PersonID"].Visible = false;
            dataGridView1.Columns[2].Width = 180;
            dataGridView1.Columns[3].Width = 122;
            dataGridView1.Columns[4].Width = 122;

            dataGridView2.Columns["PersonID"].Visible = false;
            dataGridView2.Columns[0].Width = 115;
            dataGridView2.Columns[1].Width = 115;
            dataGridView2.Columns[2].Width = 115;
            dataGridView2.Columns[3].Width = 132;
            dataGridView2.Columns[4].Width = 132;
            dataGridView2.Columns[5].Width = 115;
        }
        private void _LoadLicensesHistoryData(int personID)
        {
            DataTable LocalLicenses = LocalDrivingLicensesBusinessLayer.LoadAll_LDL_HistoryWithPersonID(personID);
            dataGridView1.DataSource = LocalLicenses;

            RecordsNumber.Text = $"{dataGridView1.Rows.Count}";

            DataTable InternationalLicenses = InternationalLicensesBusinessLayer.LoadAll_IDL_HistoryWithPersonID(personID);
            dataGridView2.DataSource = InternationalLicenses;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tabPage1)
            {
                RecordsNumber.Text = $"{dataGridView1.Rows.Count}";
            }
            else // tabPage2
            {
                RecordsNumber.Text = $"{dataGridView2.Rows.Count}";
            }
        }

        private void ShowLocalLicenses()
        {
            int licenseID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["LicenseID"].Value);
            Form form = new LocalLicenseDetails(licenseID);
            form.ShowDialog();
        }

        private void ShowInternationalLicenses()
        {
            int IntLicenseID = Convert.ToInt32(dataGridView2.CurrentRow.Cells["InternationalDL.ID"].Value);
            Form form = new InternationalLicenseDetails(IntLicenseID);
            form.ShowDialog();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1) // Local Driving License
            {
                //if (dataGridView1.SelectedRows.Count == 0)
                //{
                //    DVLDProgram.Show("No Record Selected", "Please select a license record to view its details.", MessageBoxIcon.Warning);
                //    return;
                //}
                ShowLocalLicenses();
            }
            else // International Driving License
            {
                //if (dataGridView2.SelectedRows.Count == 0)
                //{
                //    DVLDProgram.Show("No Record Selected", "Please select a license record to view its details.", MessageBoxIcon.Warning);
                //    return;
                //}
                ShowInternationalLicenses();
            }
        }
    }
}
