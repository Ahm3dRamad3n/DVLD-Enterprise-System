using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using DVLD_DTOs;
using System.Windows.Forms;
using DVLD_Business_Layer;

namespace Driving_License_Management
{
    public partial class ManagePeople : Form
    {
        private DataTable dtPeople = new DataTable();
        public ManagePeople()
        {
            InitializeComponent();

            comboBox1.SelectedIndex = 0;
            _LoadPeopleData();
            dataGridView1.Columns[0].Width = 88;
            dataGridView1.Columns[7].Width = 90;
            dataGridView1.Columns[9].Width = 90;
            dataGridView1.Columns[10].Width = 130;
            // Load All Data Except {ImagePath, NationalityCountryID, CountryID, Address}
            dataGridView1.Columns["ImagePath"].Visible = false;
            dataGridView1.Columns["NationalityCountryID"].Visible = false;
            dataGridView1.Columns["CountryID"].Visible = false;
            dataGridView1.Columns["Address"].Visible = false;
        }

        private void _LoadPeopleData()
        {
            dtPeople = PersonBusinessLayer.LoadAllPeople();
            dataGridView1.DataSource = dtPeople;
            RecordsNumber.Text = $"{dataGridView1.Rows.Count}";
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.SelectedRows.Count == 0)
            //{
            //    DVLDProgram.Show("Selection Required", "Please select a person to send email.", MessageBoxIcon.Warning);
            //    return;
            //}

            string recipientEmail = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
            
            Form form = new SendEmail(recipientEmail);
            form.ShowDialog();
            
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DVLDProgram.Show("Info", "Will add phone call service here in the future.", MessageBoxIcon.Information);
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddOrEditPerson form = new AddOrEditPerson();
            form.ShowDialog();
            _LoadPeopleData();
        }

        private void editPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.SelectedRows.Count == 0)
            //{
            //    DVLDProgram.Show("Selection Required", "Please select a person to edit.", MessageBoxIcon.Warning);
            //    return;
            //}

            clsPerson person = PersonBusinessLayer.FindByID(Convert.ToInt32(dataGridView1.CurrentRow.Cells["PersonID"].Value));
            if (person != null)
            {
                AddOrEditPerson form = new AddOrEditPerson(person);
                form.MoveTo += ChangeRowSelection;
                form.ShowDialog();
                _LoadPeopleData();
            }
            else
            {
                DVLDProgram.Show("Error", "Could not find the selected person.", MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            addNewPersonToolStripMenuItem_Click(sender, e);
        }

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.SelectedRows.Count == 0)
            //{
            //    DVLDProgram.Show("Selection Required", "Please select a person to edit.", MessageBoxIcon.Warning);
            //    return;
            //}

            int personID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["PersonID"].Value);

            bool IsExist = PersonBusinessLayer.IsExist(personID);

            if (!IsExist)
            {
                DVLDProgram.Show("Delete Error", "Cannot delete this person because there are related records in the system.", MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected person?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {

                    PersonBusinessLayer.DeletePerson(personID);

                    string ImagePath = dataGridView1.CurrentRow.Cells["ImagePath"].Value.ToString();
                    if (!string.IsNullOrEmpty(ImagePath) && System.IO.File.Exists(ImagePath))
                    {
                        System.IO.File.Delete(ImagePath);
                    }

                    DVLDProgram.Show("Success", "Person deleted successfully.", MessageBoxIcon.Information);
                    _LoadPeopleData();
                }
                catch (Exception ex)
                {
                    DVLDProgram.Show("Error", $"An error occurred while deleting the person: {ex.Message}", MessageBoxIcon.Error);
                }
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.SelectedRows.Count == 0)
            //{
            //    DVLDProgram.Show("Selection Required", "Please select a person to edit.", MessageBoxIcon.Warning);
            //    return;
            //}

            clsPerson person = PersonBusinessLayer.FindByID(Convert.ToInt32(dataGridView1.CurrentRow.Cells["PersonID"].Value));
            if (person != null)
            {
                PersonDetails form = new PersonDetails(person);
                form.MoveTo += ChangeRowSelection;
                form.ShowDialog();
            }
            else
            {
                DVLDProgram.Show("Error", "Could not find the selected person.", MessageBoxIcon.Error);

            }
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
        private void ChangeRowSelection(object sender, AddOrEditPerson.cmdEnterEventArgs e)
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
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter = comboBox1.SelectedItem.ToString();
            if (filter == "None")
            {
                textBox1.Visible = false;
                dataGridView1.DataSource = dtPeople;
                RecordsNumber.Text = $"{dataGridView1.Rows.Count}";
                return;
            }
            textBox1.Clear();
            textBox1.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filter = comboBox1.SelectedItem.ToString();
            string filterExpression = $"Convert({filter}, 'System.String') LIKE '{textBox1.Text}%'";
            DataView dv = new DataView(dtPeople);
            dv.RowFilter = filterExpression;
            dataGridView1.DataSource = dv;
            RecordsNumber.Text = $"{dataGridView1.Rows.Count}";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits for PersonID filter
            if (comboBox1.SelectedItem.ToString() == "PersonID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
    }
}
