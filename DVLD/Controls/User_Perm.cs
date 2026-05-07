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
    public partial class User_Perm : UserControl
    {
        private int Permissions = 0;
        public User_Perm()
        {
            InitializeComponent();
        }

        public void LoadData(clsUser user)
        {
            Permissions = user.permissions;
            label5.Text = user.UserID.ToString();
            label6.Text = user.UserName;
            if (user.IsActive)
                label7.Text = "YES";
            else
                label7.Text = "NO";
        }

        private void ShowPermissions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form = new PermissionsInfo(Permissions);
            form.ShowDialog();
        }
    }
}
