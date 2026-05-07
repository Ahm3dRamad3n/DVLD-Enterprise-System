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
    public partial class AppBasicInfo : UserControl
    {
        int personID = -1;
        public AppBasicInfo()
        {
            InitializeComponent();
        }

        public void LoadData(clsApplications app)
        {
            personID = app.ApplicationPersonID;
            ID.Text = app.ApplicationID.ToString();
            status.Text = app.ApplicationStatus.ToString();
            fees.Text = ApplicationsBusinessLayer.GetAppFees(app.ApplicationTypeID).ToString();
            date.Text = app.ApplicationDate.ToShortDateString();
            statusDate.Text = app.LastStatusDate.ToShortDateString();
            createdBy.Text = UsersBusinessLayer.GetUserNameByID(app.CreatedByUserID);
            type.Text = ApplicationsBusinessLayer.GetAppTypeTitle(app.ApplicationTypeID);
            applicant.Text = PersonBusinessLayer.GetFullNameByID(app.ApplicationPersonID);
        }

        public void UpdateStatus(clsApplications.ApplicationStatusEnum newStatus)
        {
            status.Text = newStatus.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsPerson person = PersonBusinessLayer.FindByID(personID);
            if (person != null)
            {
                Form form = new PersonDetails(person);
                form.ShowDialog();
            }
            else
            {
                DVLDProgram.Show("Error", "Person not found.", MessageBoxIcon.Error);
            }
        }
    }
}
