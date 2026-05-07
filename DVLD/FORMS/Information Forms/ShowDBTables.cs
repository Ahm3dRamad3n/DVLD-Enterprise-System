 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient; using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using DVLD_DTOs;
using System.Windows.Forms;

namespace Driving_License_Management
{
    public partial class ShowDBTables : Form
    {
        private bool ShowingEntriesFromEventLogs = false;
        public ShowDBTables()
        {
            InitializeComponent();
        }

        private void ShowDBTables_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private DataTable GetDataTable(string tableName)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            SqlCommand cmd = new SqlCommand($"SELECT * FROM {tableName}", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTable = comboBox1.SelectedItem.ToString();
            Title.Text = "Show " + selectedTable + " Table";
            dataGridView1.DataSource = GetDataTable(selectedTable);
        }

    }
}
