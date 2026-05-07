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
    public partial class LocalLicenseDetails : Form
    {
        public LocalLicenseDetails(int licenseID)
        {
            InitializeComponent();
            licenseInfo1.LoadData(licenseID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
