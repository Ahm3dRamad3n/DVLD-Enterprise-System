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
    public partial class TakeTest : Form
    {
        int AppointmentID = -1;
        public TakeTest(int appointmentId, TestInfo.enTestType CurrentTest)
        {
            InitializeComponent();
            this.AppointmentID = appointmentId;
            DataRow dataRow = TestsBusinessLayer.GetTestInfoByAppointmentID(appointmentId);
            testInfo1.TestType = CurrentTest;
            testInfo1.LoadData(dataRow, CurrentTest);
            testInfo1.DisableDate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clsTests test = new clsTests();
            test.Notes = txtNotes.Text;
            test.IsPassed = radioButton1.Checked;
            test.TestAppointmentID = AppointmentID;
            test.CreatedByUserID = Program.CurrentUser.UserID;

            bool result = TestsBusinessLayer.SaveTestResult(test);
            if (result)
            {
                bool Locked = TestsBusinessLayer.LockTestAppointmentByID(AppointmentID);
                if (Locked) {
                    btnSave.Enabled = false;
                    testInfo1.SaveID(test.TestID);
                    DVLDProgram.Show("Success", "Test result saved successfully.", MessageBoxIcon.Information);
                }
                else
                {
                    DVLDProgram.Show("Error", "Failed to lock test appointment after saving result.", MessageBoxIcon.Error);
                }
            }
            else
            {
                DVLDProgram.Show("Error", "Failed to save test result.", MessageBoxIcon.Error);
            }
        }
    }
}
