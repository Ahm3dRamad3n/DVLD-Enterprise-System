using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DVLD_DTOs;
using DVLD_Data_Access_Layer;

namespace DVLD_Business_Layer
{
    public class AppLicenseBusinessLayer
    {
        public static DataTable LoadAll_LDLApplications()
        {
            return AppLicenseDataLayer.LoadAll_LDLApplications();
        }
        public static bool IssueNewLicense(int applicationID, int licenseClassID, ref int newLicenseID)
        {
            return AppLicenseDataLayer.IssueNewLicense(applicationID, licenseClassID, ref newLicenseID);
        }
        public static int GetActiveAppIDForLicenseClass(int PersonID, int ClassID)
        {
            return AppLicenseDataLayer.GetActiveAppIDForLicenseClass(PersonID, ClassID);
        }
        public static int GetApplicationIdByALId(int appLicenseID)
        {
            return AppLicenseDataLayer.GetApplicationIdByALId(appLicenseID);
        }
        public static bool DeleteLocalDrivingLicense(int ldlId)
        {
            return AppLicenseDataLayer.DeleteLocalDrivingLicense(ldlId);
        }
        public static bool UpdateLicenseClassByALId(int appLicenseID, int newLicenseClassID)
        {
            return AppLicenseDataLayer.UpdateLicenseClassByALId(appLicenseID, newLicenseClassID);
        }
    }
}
