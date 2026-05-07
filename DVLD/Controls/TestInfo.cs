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
    public partial class TestInfo : UserControl
    {
        public TestInfo()
        {
            InitializeComponent();
        }
        public enum enTestType
        {
            VisionTest = 1,
            WrittenTest = 2,
            StreetTest = 3
        }
        public enTestType TestType
        {
            get { return TestType; }
            set
            {
                int testTypeID = (int)value;
                switch (testTypeID)
                {
                    case 1:
                        groupBox1.Text = "Vision Test Info";
                        pictureBox1.Image = Properties.Resources.eye2;
                        break;
                    case 2:
                        groupBox1.Text = "Written Test Info";
                        pictureBox1.Image = Properties.Resources.Written;
                        break;
                    case 3:
                        groupBox1.Text = "Street Test Info";
                        pictureBox1.Image = Properties.Resources.Street;
                        break;
                    default:
                        DVLDProgram.Show("Error", "Invalid Test Type ID", MessageBoxIcon.Error);
                        this.Dispose();
                        break;
                }
            }
        }
        public void LoadData(DataRow test, enTestType testType)
        {
            Trial.Text = TestsBusinessLayer.GetTrialNumberByALIdANDTestTypeId(Convert.ToInt32(test["AppLicenseID"]),(int)testType).ToString();
            AppLicenseID.Text = test["AppLicenseID"].ToString();
            ClassName.Text = test["ClassName"].ToString();
            Fees.Text = test["PaidFees"].ToString();
            Name.Text = test["FullName"].ToString();
            
            if (test.Table.Columns.Contains("TestDate"))
            {
                Date.Value = Convert.ToDateTime(test["TestDate"]);
            }
        }
        public void SaveID(int TestID)
        {
            this.TestID.Text = TestID.ToString();
        }

        public DateTime GetDate()
        {
            return Date.Value;
        }

        public void DisVisableTestID()
        {
            TestID.Visible = false;
            lblTestID.Visible = false;
            groupBox1.Height = 386;
            this.Height = 393;
        }

        public void DisableDate()
        {
            Date.Enabled = false;
        }
    }
}
