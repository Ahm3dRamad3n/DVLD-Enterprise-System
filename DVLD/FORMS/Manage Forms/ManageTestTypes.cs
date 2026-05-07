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
    public partial class ManageTestTypes : Form
    {
        DataTable _testTypesTable = new DataTable();
        public ManageTestTypes()
        {
            InitializeComponent();
            _LoadTestTypes();
            dataGridView1.Columns[1].Width = dataGridView1.Columns[1].Width + 20;
            dataGridView1.Columns[2].Width = dataGridView1.Columns[2].Width * 3;

        }

        private void _LoadTestTypes()
        {
            _testTypesTable = TestsBusinessLayer.GetAllTestTypes();
            dataGridView1.DataSource = _testTypesTable;
            RecordsNumber.Text = _testTypesTable.Rows.Count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.SelectedRows.Count == 0)
            //{
            //    DVLDProgram.Show("No Selection", "Please select a test type to edit.", MessageBoxIcon.Warning);
            //    return;
            //}

            int testTypeID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            string testTypeTitle = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            string testTypeDescription = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            int testTypeFee = Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value);

            Form form = new UpdateTestTypes(testTypeID, testTypeTitle, testTypeDescription, testTypeFee);
            form.ShowDialog();
            _LoadTestTypes();

        }
    }
}
