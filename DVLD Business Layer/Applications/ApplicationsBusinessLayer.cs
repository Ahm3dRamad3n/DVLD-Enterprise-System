using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DVLD_DTOs;
using DVLD_Data_Access_Layer;

namespace DVLD_Business_Layer
{
    public class ApplicationsBusinessLayer
    {
        public static DataTable GetAllAppTypes()
        {
            return AppTypesDataLayer.GetAllAppTypes();
        }
        public static bool UpdateAppType(int ApplicationTypeID, string ApplicationTypeTitle, int ApplicationFees)
        {
            return AppTypesDataLayer.UpdateAppType(ApplicationTypeID, ApplicationTypeTitle, ApplicationFees);
        }
        public static int GetAppFees(int ApplicationTypeID)
        {
            return AppTypesDataLayer.GetAppFees(ApplicationTypeID);
        }
        public static string GetAppTypeTitle(int ApplicationTypeID)
        {
            return AppTypesDataLayer.GetAppTypeTitle(ApplicationTypeID);
        }
        public static int GetApplicationFeesByAppID(int applicationId)
        {
            return ApplicationsDataLayer.GetApplicationFeesByAppID(applicationId);
        }
        public static DateTime GetApplicationDateByAppID(int applicationId)
        {
            return ApplicationsDataLayer.GetApplicationDateByAppID(applicationId);
        }
        public static bool UpdateApplicationStatusByID(int applicationId, clsApplications.ApplicationStatusEnum newStatus)
        {
            return ApplicationsDataLayer.UpdateApplicationStatusByID(applicationId, newStatus);
        }
        public static bool UpdateApplication(clsApplications application)
        {
            return ApplicationsDataLayer.UpdateApplication(application);
        }
        public static bool DeleteApplicationAndLDL(int applicationId, int ldlId)
        {
            bool isLDLDeleted = AppLicenseBusinessLayer.DeleteLocalDrivingLicense(ldlId);
            if (!isLDLDeleted)
            {
                return false;
            }
            bool isApplicationDeleted = ApplicationsDataLayer.DeleteApplication(applicationId);
            if (!isApplicationDeleted)
            {
                throw new Exception("Failed to delete application after deleting LDL.");
            }
            return isApplicationDeleted;
        }
        public static clsApplications FindByID(int applicationId)
        {
            return ApplicationsDataLayer.FindByID(applicationId);
        }
        public static bool CancelApplication(int applicationId)
        {
            return ApplicationsDataLayer.CancelApplication(applicationId);
        }
        public static bool AddNewApplication(clsApplications application)
        {
            return ApplicationsDataLayer.AddNewApplication(application);
        }
        public static DataTable LoadAll_IDLApplications()
        {
            return ApplicationsDataLayer.LoadAll_IDLApplications();
        }
    }
}
