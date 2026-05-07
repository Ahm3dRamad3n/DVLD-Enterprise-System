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
    public partial class DetainOrReleaseInfo : UserControl
    {
        public enum LicenseAction
        {
            Release,
            Detain
        }
        private LicenseAction _action;
        public LicenseAction Action
        {
            get { return _action; }
            set
            {
                _action = value;
                if (_action == LicenseAction.Release)
                    ReleaseMode();
                else
                    DetainMode();
            }
        }
        public DetainOrReleaseInfo()
        {
            InitializeComponent();
        }
        private void DetainMode()
        {
            lblAppFees.Visible = false;
            AppFees.Visible = false;
            FineFees.Visible = false;
            txtFineFees.Visible = true;
            groupBox1.Height = 113;
            groupBox1.Text = "Detain Information";
        }
        private void ReleaseMode()
        {
            lblTotalFees.Visible = true;
            AppFees.Visible = true;
            FineFees.Visible = true;
            txtFineFees.Visible = false;
            groupBox1.Height = 154;
            groupBox1.Text = "Release Information";
        }

        public void LoadDetainInfoByLocalLID(int LicenseID)
        {
            txtFineFees.Focus();

            SetDetainID(-1);
            SetLicenseID(LicenseID);
            SetDetainDate(DateTime.Now);
            SetCreatedBy(Program.CurrentUser.UserName);
            // Fine Fees From Textbox Input
            SetAppFees(0);
            // Total Fees Equal  Fine Fees
            SetApplicationID(-1);
        }
        public void LoadReleaseInfoByLocalLID(int LicenseID)
        {
            txtFineFees.Clear();

            DataRow record = DetainedLicensesBusinessLayer.FindByLicenseIDAndNotReleased(LicenseID);
            if (record == null)
            {
                DVLDProgram.Show("Data Error", "No detained license record found for LicenseID: " + LicenseID.ToString(), MessageBoxIcon.Error);
                return; 
            }
            /*
             DetainID = index 0 , LicenseID = index 1 , DetainDate = index 2 ,
             FineFees = index 3 , CreatedByUserID = index 4 , IsRelease = index 5
             ReleaseDate = index 6 , ReleaseByUserID = index 7, ReleaseApplicationID = index 8
             */
            SetDetainID(Convert.ToInt32(record[0]));
            SetLicenseID(LicenseID);
            SetDetainDate(Convert.ToDateTime(record[2]));
            SetCreatedBy(UsersBusinessLayer.GetUserNameByID(Convert.ToInt32(record[4])));
            SetFineFees(Convert.ToInt32(record[3]));
            SetApplicationID(-1);
            int appFees = ApplicationsBusinessLayer.GetAppFees(5); // 5 = Release Local License
            if (appFees == -1)
            {
                DVLDProgram.Show("Data Error", "Release Local License application fee is not set. Please contact administrator.", MessageBoxIcon.Error);
                return;
            }
            SetAppFees(appFees);
            SetTotalFees();
        }

        public void SetDetainID(int _DetainID)
        {
            DetainID.Text = _DetainID == -1 ? "[???]" : _DetainID.ToString();
        }
        public void SetApplicationID(int _ApplicationID)
        {
            AppID.Text = _ApplicationID == -1 ? "[???]" : _ApplicationID.ToString();
        }
        
        public int GetTotalFees()
        {
            int totalFees = int.TryParse(TotalFees.Text.Trim(), out totalFees) ? totalFees : -1;
            return totalFees;
        }
        public int GetDetainID()
        {
            int detainID = int.TryParse(DetainID.Text.Trim(), out detainID) ? detainID : -1;
            return detainID;
        }

        private void SetLicenseID(int _LicenseID)
        {
            LicenseID.Text = _LicenseID.ToString();
        }
        private void SetDetainDate(DateTime _DetainDate)
        {
            DetainDate.Text = _DetainDate.ToShortDateString();
        }
        private void SetCreatedBy(string _CreatedBy)
        {
            CreatedBy.Text = _CreatedBy;
        }
        private void SetFineFees(int _FineFees)
        {
            FineFees.Text = _FineFees.ToString();
        }
        private void SetAppFees(int _AppFees)
        {
            AppFees.Text = _AppFees.ToString();
        }
        private void SetTotalFees()
        {
            int fineFees = int.TryParse(FineFees.Text.Trim(), out fineFees) ? fineFees : -1;
            int appFees = int.TryParse(AppFees.Text.Trim(), out appFees) ? appFees : -1;
            if (fineFees == -1 || appFees == -1)
                TotalFees.Text = "[???]";
            else
            {
                int totalFees = fineFees + appFees;
                TotalFees.Text = totalFees.ToString();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtFineFees_Validating(object sender, CancelEventArgs e)
        {
            int fineFees;
            fineFees = int.TryParse(txtFineFees.Text.Trim(), out fineFees) ? fineFees : -1;
            if (fineFees < 0)
            {
                errorProvider1.SetError(txtFineFees, "Please enter a valid Fine Fees amount.");
                e.Cancel = true;
            }
            else { 
                errorProvider1.SetError(txtFineFees, null);
                SetFineFees(fineFees);
                SetTotalFees();
                e.Cancel = false;
            }
        }
    }
}
