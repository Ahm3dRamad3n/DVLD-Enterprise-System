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
    public partial class ManageUsers : Form
    {
        DataTable dtUsers = new DataTable();
        public ManageUsers()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            _LoadUsersData();
            dataGridView1.Columns[3].Width *= 3;
            dataGridView1.Columns["Email"].Visible = false;
        }

        private void _LoadUsersData()
        {
            dtUsers = UsersBusinessLayer.LoadAllUsers();
            // Load All Data Except {Password}
            dataGridView1.DataSource = dtUsers;
            RecordsNumber.Text = $"{dataGridView1.Rows.Count}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filter = comboBox1.SelectedItem.ToString();
            if (filter == "None")
            {
                textBox1.Visible = false;
                comboBox2.Visible = false;
                dataGridView1.DataSource = dtUsers;
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
            string filterExpression = $"Convert({filter}, 'System.String') LIKE '{textBox1.Text}%'";
            DataView dv = new DataView(dtUsers);
            dv.RowFilter = filterExpression;
            dataGridView1.DataSource = dv;
            RecordsNumber.Text = $"{dataGridView1.Rows.Count}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new AddOrEditUser();
            form.ShowDialog();
            _LoadUsersData();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "UserID" || comboBox1.SelectedItem.ToString() == "PersonID")
            {
                // Allow only digits and control characters (like backspace)
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Ignore the input
                }
            }
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

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.SelectedRows.Count == 0)
            //{
            //    DVLDProgram.Show("Selection Required", "Please select a person to edit.", MessageBoxIcon.Warning);
            //    return;
            //}

            clsUser user = UsersBusinessLayer.FindByID(Convert.ToInt32(dataGridView1.CurrentRow.Cells["UserID"].Value));
            if (user != null)
            {
                Form form = new UserDetails(user);
                form.ShowDialog();
            }
            else
            {
                DVLDProgram.Show("Error", "Selected user not found.", MessageBoxIcon.Error);
            }
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
            DVLDProgram.Show("Info", "This feature is not implemented yet.", MessageBoxIcon.Information);
        }

        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.SelectedRows.Count == 0)
            //{
            //    DVLDProgram.Show("Selection Required", "Please select a user to delete.", MessageBoxIcon.Warning);
            //    return;
            //}

            int userID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["UserID"].Value);

            bool IsExist = UsersBusinessLayer.IsExist(userID);

            if (!IsExist)
            {
                DVLDProgram.Show("Delete Error", "Cannot delete this user because there are related records in the system.", MessageBoxIcon.Error);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to delete the selected user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                bool isDeleted = UsersBusinessLayer.DeleteUser(userID);
                if (isDeleted)
                {
                    DVLDProgram.Show("Delete Successful", "User deleted successfully.", MessageBoxIcon.Information);
                    _LoadUsersData();
                }
                else
                {
                    DVLDProgram.Show("Delete Failed", "Failed to delete the user.", MessageBoxIcon.Error);
                }
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.SelectedRows.Count == 0)
            //{
            //    DVLDProgram.Show("Selection Required", "Please select a user to change the password.", MessageBoxIcon.Warning);
            //    return;
            //}

            clsUser user = UsersBusinessLayer.FindByID(Convert.ToInt32(dataGridView1.CurrentRow.Cells["UserID"].Value));

            if (user != null)
            {
                Form form = new ChangePassword(user);
                form.ShowDialog();
            }
            else
            {
                DVLDProgram.Show("Error", "Selected user not found.", MessageBoxIcon.Error);
            }
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form = new AddOrEditUser();
            form.ShowDialog();
            _LoadUsersData();
        }

        private void editPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.SelectedRows.Count == 0)
            //{
            //    DVLDProgram.Show("Selection Required", "Please select a person to edit.", MessageBoxIcon.Warning);
            //    return;
            //}

            clsUser user = UsersBusinessLayer.FindByID(Convert.ToInt32(dataGridView1.CurrentRow.Cells["UserID"].Value));

            if (user != null)
            {
                Form form = new AddOrEditUser(user);
                form.ShowDialog();
                _LoadUsersData();
            }
            else
            {
                DVLDProgram.Show("Error", "Selected user not found.", MessageBoxIcon.Error);
            }
        }

    }
}
