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
    public partial class UserDetails : Form
    {
        public UserDetails(clsUser user)
        {
            InitializeComponent();
            personInfo1.LoadData(user.Person);
            user_Perm1.LoadData(user);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
