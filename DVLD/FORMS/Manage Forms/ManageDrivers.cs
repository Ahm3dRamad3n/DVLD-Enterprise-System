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
    public partial class ManageDrivers : Form
    {
        DataTable dtDrivers = new DataTable();
        public ManageDrivers()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            _LoadDiversList();
            dataGridView1.Columns[3].Width = 270;
            dataGridView1.Columns[4].Width = 167;
        }

        private void _LoadDiversList()
        {
            dtDrivers = DriversBusinessLayer.LoadAllDrivers();
            dataGridView1.DataSource = dtDrivers;
            RecordsNumber.Text = dataGridView1.Rows.Count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "DriverID" || comboBox1.SelectedItem.ToString() == "PersonID")
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
            string filterExpression = "";
            if (filter == "DriverID" || filter == "PersonID")
            {
                filterExpression = $"Convert({filter}, 'System.String') LIKE '{textBox1.Text}%'";
            }
            else // FullName || NationalNo
            {
                filterExpression = $"{filter} LIKE '{textBox1.Text}%'";
            }
            DataView dv = new DataView(dtDrivers);
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
                dataGridView1.DataSource = dtDrivers;
                RecordsNumber.Text = $"{dataGridView1.Rows.Count}";
                return;
            }
            textBox1.Clear();
            textBox1.Visible = true;
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["PersonID"].Value);
            
            clsPerson person = PersonBusinessLayer.FindByID(personID);
            if (person == null)
            {
                DVLDProgram.Show("Error", "Person record not found.", MessageBoxIcon.Error);
                return;
            }

            PersonDetails form = new PersonDetails(person);
            form.MoveTo += ChangeRowSelection;
            form.ShowDialog();
        }

        private void ChangeRowSelection(object sender, PersonDetails.cmdEnterEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {
                if (dataGridView1.CurrentRow.Index > 0)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index - 1].Cells[0];
                }
            }
            else // if (e.KeyData == Keys.Down)
            {
                if (dataGridView1.CurrentRow.Index < dataGridView1.Rows.Count - 1)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentRow.Index + 1].Cells[0];
                }
            }

            clsPerson person = PersonBusinessLayer.FindByID(Convert.ToInt32(dataGridView1.CurrentRow.Cells["PersonID"].Value));
            if (person != null)
            {
                e.person = person;
            }
            else
            {
                DVLDProgram.Show("Error", "Could not find the selected person.", MessageBoxIcon.Error);

            }
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int personID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["PersonID"].Value);

            clsPerson person = PersonBusinessLayer.FindByID(personID);
            if (person == null)
            {
                DVLDProgram.Show("Error", "Person record not found.", MessageBoxIcon.Error);
                return;
            }

            Form form = new PersonLicenseHistory(person);
            form.ShowDialog();
        }
    }
}
