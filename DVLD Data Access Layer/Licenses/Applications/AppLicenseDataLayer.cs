using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient; using System.Configuration;
using System.Text;
using DVLD_DTOs;
 
 

namespace DVLD_Data_Access_Layer
{
     public class AppLicenseDataLayer
    {
        public static bool UpdateLicenseClassByALId(int appLicenseID, int newLicenseClassID)
        {
            bool isSuccess = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "UPDATE AppLicenses SET LicenseClassID = @NewLicenseClassID WHERE AppLicenseID = @AppLicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NewLicenseClassID", newLicenseClassID);
            command.Parameters.AddWithValue("@AppLicenseID", appLicenseID);
            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                isSuccess = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return isSuccess;
        }
        public static bool DeleteLocalDrivingLicense(int ldlId)
        {
            bool isSuccess = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "DELETE FROM AppLicenses WHERE AppLicenseID = @LDLId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LDLId", ldlId);
            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                isSuccess = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return isSuccess;
        }
        public static int GetApplicationIdByALId(int appLicenseID)
        {
            int applicationId = -1;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT ApplicationID FROM AppLicenses WHERE AppLicenseID = @appLicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@appLicenseID", appLicenseID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    applicationId = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return applicationId;
        }
        public static int GetActiveAppIDForLicenseClass(int PersonID, int ClassID)
        {
            int applicationId = -1;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = @"SELECT TOP 1 A.ApplicationID 
                             FROM AppLicenses AL
                             INNER JOIN Applications A ON AL.ApplicationID = A.ApplicationID
                             WHERE A.ApplicationPersonID = @PersonID AND AL.LicenseClassID = @ClassID
                             AND A.ApplicationStatus != @Cancelled
                             ORDER BY A.ApplicationDate DESC";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@ClassID", ClassID);
            command.Parameters.AddWithValue("@Cancelled", (int)clsApplications.ApplicationStatusEnum.Cancelled);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    applicationId = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return applicationId;

        }
        public static bool IssueNewLicense(int applicationID, int licenseClassID, ref int newLicenseID)
        {
            bool isSuccess = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "INSERT INTO AppLicenses (ApplicationID, LicenseClassID) " +
                           "VALUES (@ApplicationID, @LicenseClassID); SELECT SCOPE_IDENTITY()";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationID);
            command.Parameters.AddWithValue("@LicenseClassID", licenseClassID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    newLicenseID = Convert.ToInt32(result);
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return isSuccess;
        }
        public static DataTable LoadAll_LDLApplications()
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT * FROM AppLicenses_View";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dataTable.Load(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return dataTable;
        }
    }
}
