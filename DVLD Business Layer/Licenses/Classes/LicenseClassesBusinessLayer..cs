using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DVLD_DTOs;
using DVLD_Data_Access_Layer;

namespace DVLD_Business_Layer
{
    public class LicenseClassesBusinessLayer
    {
        public static int GetExpiryPeriodByClassID(int classId)
        {
            return LicenseClassesDataLayer.GetExpiryPeriodByClassID(classId);
        }
        public static int GetFeesByClassID(int classId)
        {
            return LicenseClassesDataLayer.GetFeesByClassID(classId);
        }
        public static DataTable GetLicenseClassesList()
        {
            return LicenseClassesDataLayer.GetLicenseClassesList();
        }
        public static int GetLicenseClassIDByALId(int ALId)
        {
            return LicenseClassesDataLayer.GetLicenseClassIDByALId(ALId);
        }
        public static string GetLicenseClassNameByID(int classId)
        {
            return LicenseClassesDataLayer.GetLicenseClassNameByID(classId);
        }
    }
}
