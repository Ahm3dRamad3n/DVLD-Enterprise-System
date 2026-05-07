 
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient; using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using DVLD_DTOs;
using System.Windows.Forms;
using DVLD_Business_Layer;

namespace Driving_License_Management
{
    internal static class DVLDProgram
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
        public enum Permission
        {
            ManagePeople = 1,
            ManageUsers = 2,
            ManageDrivers = 4,
            ManageLocalDrivingApp = 8,
            ManageInternationalApp = 16,
            ManageDetainedLicenses = 32,
            ManageApplicationTypes = 64,
            ManageTestTypes = 128,
            DetainLicense = 256,
            ReleaseLicense = 512,
            AddNewLocalLicenseApp = 1024,
            AddNewInternationalApp = 2048,
            RenewLicense = 4096,
            ReplacementLicense = 8192
        }
        public static void Show(string title, string message, MessageBoxIcon type)
        {
            EventLogEntryType eventType = type == MessageBoxIcon.Error ? EventLogEntryType.Error :
                                       type == MessageBoxIcon.Warning ? EventLogEntryType.Warning :
                                       type == MessageBoxIcon.Information ? EventLogEntryType.Information : EventLogEntryType.FailureAudit; // Default to FailureAudit for unknown types

            bool isAdd = LogsBusinessLayer.AddLog(title, message, eventType);
            if (!isAdd)
            {
                MessageBox.Show("Failed to add log entry, ensure the database connection is working and if countinue to have issues contact support.... \nwill show the message without adding to log after you click OK", "Log Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
             MessageBox.Show(message, title, MessageBoxButtons.OK, type);
        }
    }
}
