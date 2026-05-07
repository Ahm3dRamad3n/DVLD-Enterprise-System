using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DVLD_DTOs;
using DVLD_Data_Access_Layer;

namespace DVLD_Business_Layer
{
    public class InternationalLicensesBusinessLayer
    {
        public static bool IssueInternationalLicense(clsInternationalLicense intlLicense)
        {
            return InternationalLicensesDataLayer.IssueInternationalLicense(intlLicense);
        }
        public static int Get_ILID_By_LLID(int LocalLicenseID)
        {
            return InternationalLicensesDataLayer.Get_ILID_By_LLID(LocalLicenseID);
        }
        public static DataTable LoadAll_IDL_History()
        {
              return InternationalLicensesDataLayer.LoadAll_IDL_History();
        }
        public static clsInternationalLicense FindByID(int IntLID)
        {
            return InternationalLicensesDataLayer.FindByID(IntLID);
        }
        public static DataTable LoadAll_IDL_HistoryWithPersonID(int personID)
        {
            return InternationalLicensesDataLayer.LoadAll_IDL_HistoryWithPersonID(personID);
        }
    }
}
