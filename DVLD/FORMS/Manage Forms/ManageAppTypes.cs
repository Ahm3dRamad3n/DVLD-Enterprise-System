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
    public partial class ManageAppTypes : Form
    {
        private DataTable _appTypesTable = new DataTable();
        public ManageAppTypes()
        {
            InitializeComponent();
            _LoadAppTypes();
            dataGridView1.Columns[1].Width = dataGridView1.Columns[1].Width * 3;
        }

        private void _LoadAppTypes()
        {
            _appTypesTable = ApplicationsBusinessLayer.GetAllAppTypes();
            dataGridView1.DataSource = _appTypesTable;
            RecordsNumber.Text = _appTypesTable.Rows.Count.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.SelectedRows.Count == 0)
            //{
            //    DVLDProgram.Show("No Selection", "Please select an application type to edit.", MessageBoxIcon.Warning);
            //    return;
            //}

            int appTypeID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            string appTypeTitle = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            int appTypeFee = Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value);
            Form form = new UpdateAppTypes(appTypeID, appTypeTitle, appTypeFee);
            form.ShowDialog();
            _LoadAppTypes();
        }
    }
}
