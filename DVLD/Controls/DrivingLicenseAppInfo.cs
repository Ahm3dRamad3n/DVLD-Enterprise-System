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
    public partial class DrivingLicenseAppInfo : UserControl
    {
        public DrivingLicenseAppInfo()
        {
            InitializeComponent();
        }
        public void LoadData(int id,string classname, int passed)
        {
            ID.Text = id.ToString();
            Class.Text = classname;
            Passed.Text = passed.ToString();
        }
        public void UpdatePassedTestCount(int passed)
        {
            Passed.Text = passed.ToString();
        }
        private void Passed_Click(object sender, EventArgs e)
        {

        }
    }
}
