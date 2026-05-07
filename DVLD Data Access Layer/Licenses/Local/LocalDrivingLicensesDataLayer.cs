using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient; using System.Configuration;
using System.Linq;
using System.Text;
using DVLD_DTOs;

namespace DVLD_Data_Access_Layer
{
     public class LocalDrivingLicensesDataLayer
    {
        public static int GetClassIDByLicenseID(int licenseID)
        {
            int classID = -1;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT LicenseClassID FROM LocalDrivingLicenses WHERE LicenseID = @LicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", licenseID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    classID = Convert.ToInt32(result);
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
            return classID;
        }
        public static bool DeactivateLocalLicenseByID(int licenseID)
        {
            bool isSuccess = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "UPDATE LocalDrivingLicenses SET IsActive = 0 WHERE LicenseID = @LicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", licenseID);
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
        public static DataTable LoadAll_LDL_History()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT * FROM LDL_History_View";
            SqlCommand command = new SqlCommand(query, connection);
            try 
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
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
            return dt;
        }
        public static string GetIssueReasonByID(int reasonID)
        {
            string issueReason = string.Empty;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT ReasonName FROM IssueReasons WHERE IssueReasonID = @IssueReasonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IssueReasonID", reasonID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    issueReason = result.ToString();
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
            return issueReason;
        }
        public static clsLocalLicense FindByID(int licenseID)
        {
            clsLocalLicense localLicense = null;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT * FROM LocalDrivingLicenses WHERE LicenseID = @LicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", licenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    localLicense = new clsLocalLicense
                    {
                        LicenseID = Convert.ToInt32(reader["LicenseID"]),
                        ApplicationID = Convert.ToInt32(reader["ApplicationID"]),
                        DriverID = Convert.ToInt32(reader["DriverID"]),
                        LicenseClassID = Convert.ToInt32(reader["LicenseClassID"]),
                        IssueDate = Convert.ToDateTime(reader["IssueDate"]),
                        ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]),
                        IssueReasonID = Convert.ToInt32(reader["IssueReason"]),
                        Notes = reader["Notes"].ToString(),
                        PaidFees = Convert.ToInt32(reader["PaidFees"]),
                        IsActive = Convert.ToBoolean(reader["IsActive"]),
                        CreatedByUserID = Convert.ToInt32(reader["CreatedByUserID"])
                    };
                }
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
            return localLicense;
        }
        public static int GetLicenseIDByApplicationID(int applicationID)
        {
            int licenseID = -1;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT LicenseID FROM LocalDrivingLicenses WHERE ApplicationID = @ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    licenseID = Convert.ToInt32(result);
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
            return licenseID;
        }
        public static bool IssueLocalDrivingLicense(clsLocalLicense localLicense)
        {
            bool isSuccess = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "INSERT INTO LocalDrivingLicenses (ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate, IssueReason, Notes, PaidFees, IsActive, CreatedByUserID) " +
                           "VALUES (@ApplicationID, @DriverID, @LicenseClassID, @IssueDate, @ExpirationDate, @IssueReason, @Notes, @PaidFees, @IsActive, @CreatedByUserID); SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", localLicense.ApplicationID);
            command.Parameters.AddWithValue("@DriverID", localLicense.DriverID);
            command.Parameters.AddWithValue("@LicenseClassID", localLicense.LicenseClassID);
            command.Parameters.AddWithValue("@IssueDate", localLicense.IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", localLicense.ExpirationDate);
            command.Parameters.AddWithValue("@IssueReason", localLicense.IssueReasonID);
            command.Parameters.AddWithValue("@Notes", localLicense.Notes);
            command.Parameters.AddWithValue("@PaidFees", localLicense.PaidFees);
            command.Parameters.AddWithValue("@IsActive", localLicense.IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", localLicense.CreatedByUserID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    isSuccess = true;
                    localLicense.LicenseID = Convert.ToInt32(result);
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
        public static DataTable LoadAll_LDL_HistoryWithPersonID(int personID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT * FROM LDL_History_View WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", personID);
            try 
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dt.Load(reader);
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
            return dt;
        }
    }
}
