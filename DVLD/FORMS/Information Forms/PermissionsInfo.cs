using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DVLD_DTOs;
using System.Windows.Forms;

namespace Driving_License_Management
{
    public partial class PermissionsInfo : Form
    {
        public PermissionsInfo()
        {
            InitializeComponent();
            permissions1.DisableEditing();
            permissions1.LoadPermissionsIntoList();
        }

        public PermissionsInfo(int permissions)
        {
            InitializeComponent();
            permissions1.DisableEditing();
            permissions1.LoadPermissionsIntoList(permissions);
        }

    }
}
