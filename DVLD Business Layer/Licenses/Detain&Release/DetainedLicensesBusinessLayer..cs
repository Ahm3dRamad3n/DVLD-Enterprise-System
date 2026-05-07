using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DVLD_DTOs;
using DVLD_Data_Access_Layer;
namespace DVLD_Business_Layer
{
    public class DetainedLicensesBusinessLayer
    {
        public static bool ReleaseDetainedLicense(int detainID, int releaseAppID)
        {
            return DetainedLicensesDataLayer.ReleaseDetainedLicense(detainID, releaseAppID);
        }
        public static bool DetainLicense(int licenseID, int fineFees, ref int DetainID)
        {
            return DetainedLicensesDataLayer.DetainLicense(licenseID, fineFees, ref DetainID);
        }
        public static DataTable LoadAllDetainedLicenses()
        {
            return DetainedLicensesDataLayer.LoadAllDetainedLicenses();
        }
        public static bool IsLicenseDetained(int licenseID)
        {
            return DetainedLicensesDataLayer.IsLicenseDetained(licenseID);
        }
        public static DataRow FindByLicenseIDAndNotReleased(int licenseID)
        {
            return DetainedLicensesDataLayer.FindByLicenseIDAndNotReleased(licenseID);
        }
    }
}
