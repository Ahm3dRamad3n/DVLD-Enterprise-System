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
    public partial class Permissions : UserControl
    {
        private bool isLocked = false, isLoading = false;
        public Permissions()
        {
            InitializeComponent();
        }

        public void DisableEditing()
        {
            isLocked = true;
            checkBox2.Enabled = false;
        }

        public void LoadPermissionsIntoList()
        {
            LoadPermissionsIntoList(Program.CurrentUser.permissions);
        }

        public void LoadPermissionsIntoList(int permissions)
        {
            int bitValue = 1;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if ((permissions & bitValue) == bitValue)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
                bitValue *= 2;
            }

            isLoading = true;
            checkBox2.Checked = (checkedListBox1.CheckedItems.Count == checkedListBox1.Items.Count);
        }

        public int GetPermissionsNumberFromList()
        {
            int permissions = 0, bitValue = 1;
            foreach (var item in checkedListBox1.Items)
            {
                permissions += (checkedListBox1.CheckedItems.Contains(item) ? bitValue : 0);
                bitValue *= 2;
            }
            DVLDProgram.Show("Debug", "Permissions value: " + permissions.ToString(), MessageBoxIcon.Information);
            return permissions;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
            }
            else
            {
                if (checkedListBox1.CheckedItems.Count == checkedListBox1.Items.Count)
                {
                    for (int i = 0; i < checkedListBox1.Items.Count; i++)
                    {
                        checkedListBox1.SetItemChecked(i, false);
                    }
                }
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = checkedListBox1.Items.Count == checkedListBox1.CheckedItems.Count;
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (isLocked && isLoading)
            {
                e.NewValue = e.CurrentValue; // Prevent change
                errorProvider1.SetError(checkedListBox1, "Editing permissions is disabled.");
            }
        }
    }
}
