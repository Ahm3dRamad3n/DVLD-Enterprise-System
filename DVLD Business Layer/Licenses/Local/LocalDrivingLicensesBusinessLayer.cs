using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DVLD_DTOs;
using DVLD_Data_Access_Layer;
namespace DVLD_Business_Layer
{
    public class LocalDrivingLicensesBusinessLayer
    {
        public static int GetClassIDByLicenseID(int licenseID)
        {
            return LocalDrivingLicensesDataLayer.GetClassIDByLicenseID(licenseID);
        }
        public static bool DeactivateLocalLicenseByID(int licenseID)
        {
            return LocalDrivingLicensesDataLayer.DeactivateLocalLicenseByID(licenseID);
        }
        public static string GetIssueReasonByID(int reasonID)
        {
            return LocalDrivingLicensesDataLayer.GetIssueReasonByID(reasonID);
        }
        public static clsLocalLicense FindByID(int licenseID)
        {
            return LocalDrivingLicensesDataLayer.FindByID(licenseID);
        }
        public static int GetLicenseIDByApplicationID(int applicationID)
        {
            return LocalDrivingLicensesDataLayer.GetLicenseIDByApplicationID(applicationID);
        }
        public static bool IssueLocalDrivingLicense(clsLocalLicense localLicense)
        {
            return LocalDrivingLicensesDataLayer.IssueLocalDrivingLicense(localLicense);
        }
        public static DataTable LoadAll_LDL_History()
        {
            return LocalDrivingLicensesDataLayer.LoadAll_LDL_History();
        }
        public static DataTable LoadAll_LDL_HistoryWithPersonID(int personID)
        {
            return LocalDrivingLicensesDataLayer.LoadAll_LDL_HistoryWithPersonID(personID);
        }
    }
}
