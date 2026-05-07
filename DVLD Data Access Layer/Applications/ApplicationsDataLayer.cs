using System;
using System.Collections.Generic;
using System.Data.SqlClient; 
using System.Configuration;
using System.Linq;
using System.Text;
using System.Data;
using DVLD_DTOs;

namespace DVLD_Data_Access_Layer
{
    public class ApplicationsDataLayer
    {
        public static int GetApplicationFeesByAppID(int applicationId)
        {
            int paidFees = 0;   
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT PaidFees FROM Applications WHERE ApplicationID = @ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationId);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    paidFees = Convert.ToInt32(reader["PaidFees"]);
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
            return paidFees;
        }
        public static DateTime GetApplicationDateByAppID(int applicationId)
        {
            DateTime applicationDate = DateTime.MinValue;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT ApplicationDate FROM Applications WHERE ApplicationID = @ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationId);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    applicationDate = Convert.ToDateTime(reader["ApplicationDate"]);
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
            return applicationDate;
        }
        public static bool UpdateApplicationStatusByID(int applicationId, clsApplications.ApplicationStatusEnum newStatus)
        {
            bool isSuccess = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "UPDATE Applications SET ApplicationStatus = @ApplicationStatus, LastStatusDate = @LastStatusDate WHERE ApplicationID = @ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationStatus", (int)newStatus);
            command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);
            command.Parameters.AddWithValue("@ApplicationID", applicationId);
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
        public static bool UpdateApplication(clsApplications application)
        {
            bool isSuccess = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "UPDATE Applications SET ApplicationPersonID = @ApplicationPersonID, ApplicationTypeID = @ApplicationTypeID, " +
                           "ApplicationDate = @ApplicationDate, ApplicationStatus = @ApplicationStatus, LastStatusDate = @LastStatusDate, " +
                           "PaidFees = @PaidFees, CreatedByUserID = @CreatedByUserID WHERE ApplicationID = @ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationPersonID", application.ApplicationPersonID);
            command.Parameters.AddWithValue("@ApplicationTypeID", application.ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationDate", application.ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationStatus", application.ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", application.LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", application.PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", application.CreatedByUserID);
            command.Parameters.AddWithValue("@ApplicationID", application.ApplicationID);
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
        public static clsApplications FindByID(int applicationId)
        {
            clsApplications application = null;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT * FROM Applications WHERE ApplicationID = @ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationId);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    application = new clsApplications
                    {
                        ApplicationID = Convert.ToInt32(reader["ApplicationID"]),
                        ApplicationPersonID = Convert.ToInt32(reader["ApplicationPersonID"]),
                        ApplicationTypeID = Convert.ToInt32(reader["ApplicationTypeID"]),
                        ApplicationDate = Convert.ToDateTime(reader["ApplicationDate"]),
                        ApplicationStatus = (clsApplications.ApplicationStatusEnum)Convert.ToInt32(reader["ApplicationStatus"]),
                        LastStatusDate = Convert.ToDateTime(reader["LastStatusDate"]),
                        PaidFees = Convert.ToInt32(reader["PaidFees"]),
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
            return application;
        }
        public static bool DeleteApplication(int applicationId)
        {
            bool isSuccess = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "DELETE FROM Applications WHERE ApplicationID = @ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", applicationId);
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
        public static bool CancelApplication(int applicationId)
        {
            bool isSuccess = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "UPDATE Applications SET ApplicationStatus = @ApplicationStatus, LastStatusDate = @LastStatusDate WHERE ApplicationID = @ApplicationID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationStatus", 2);
            command.Parameters.AddWithValue("@LastStatusDate", DateTime.Now);
            command.Parameters.AddWithValue("@ApplicationID", applicationId);
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
        public static bool AddNewApplication(clsApplications application)
        {
            bool isSuccess = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "INSERT INTO Applications (ApplicationPersonID, ApplicationTypeID, ApplicationDate, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID) " +
                           "VALUES (@ApplicationPersonID, @ApplicationTypeID, @ApplicationDate, @ApplicationStatus, @LastStatusDate, @PaidFees, @CreatedByUserID); SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationPersonID", application.ApplicationPersonID);
            command.Parameters.AddWithValue("@ApplicationTypeID", application.ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationDate", application.ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationStatus", application.ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", application.LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", application.PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", application.CreatedByUserID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    application.ApplicationID = Convert.ToInt32(result);
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
        public static DataTable LoadAll_IDLApplications()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT a.ApplicationID, a.ApplicationPersonID, " +
                           "FullName = pe.FirstName + ' ' + pe.SecondName + ' ' + pe.ThirdName + ' ' + pe.LastName, " +
                           "a.ApplicationDate, a.PaidFees, a.CreatedByUserID " +
                           "FROM Applications a " +
                           "JOIN People pe ON a.ApplicationPersonID = pe.PersonID " +
                           "JOIN InternationalLicenses il ON a.ApplicationID = il.ApplicationID";
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
    }
}
