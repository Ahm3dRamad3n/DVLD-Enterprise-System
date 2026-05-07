using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient; using System.Configuration;
using System.Linq;
using System.Text;
using DVLD_DTOs;

namespace DVLD_Data_Access_Layer
{
     public class InternationalLicensesDataLayer
    {
        public static bool IssueInternationalLicense(clsInternationalLicense intlLicense)
        {
            bool success = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "INSERT INTO InternationalLicenses (ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID) " +
                           "VALUES (@ApplicationID, @DriverID, @IssuedUsingLocalLicenseID, @IssueDate, @ExpirationDate, @IsActive, @CreatedByUserID); SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", intlLicense.ApplicationID);
            command.Parameters.AddWithValue("@DriverID", intlLicense.DriverID);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", intlLicense.IssuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@IssueDate", intlLicense.IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", intlLicense.ExpirationDate);
            command.Parameters.AddWithValue("@IsActive", intlLicense.IsActive);
            command.Parameters.AddWithValue("@CreatedByUserID", intlLicense.CreatedByUserID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    intlLicense.InternationalLicenseID = Convert.ToInt32(result);
                    success = true;
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
            return success;
        }
        public static int Get_ILID_By_LLID(int LocalLicenseID)
        {
            int InternationalLicenseID = -1;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT InternationalLicenseID FROM InternationalLicenses WHERE IssuedUsingLocalLicenseID = @LocalLicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalLicenseID", LocalLicenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    InternationalLicenseID = Convert.ToInt32(reader["InternationalLicenseID"]);
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
            return InternationalLicenseID;
        }
        public static DataTable LoadAll_IDL_History()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT        InternationalLicenseID, ApplicationID, DriverID, IssuedUsingLocalLicenseID AS LocalLicenseID, IssueDate, ExpirationDate, IsActive\r\nFROM            dbo.InternationalLicenses";
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
        public static clsInternationalLicense FindByID(int IntLID)
        {
            clsInternationalLicense IntLicense = null;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT * FROM InternationalLicenses WHERE InternationalLicenseID = @IntLID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IntLID", IntLID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IntLicense = new clsInternationalLicense
                    {
                        InternationalLicenseID = Convert.ToInt32(reader["InternationalLicenseID"]),
                        ApplicationID = Convert.ToInt32(reader["ApplicationID"]),
                        DriverID = Convert.ToInt32(reader["DriverID"]),
                        IssuedUsingLocalLicenseID = Convert.ToInt32(reader["IssuedUsingLocalLicenseID"]),
                        IssueDate = Convert.ToDateTime(reader["IssueDate"]),
                        ExpirationDate = Convert.ToDateTime(reader["ExpirationDate"]),
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
            return IntLicense;
        }
        public static DataTable LoadAll_IDL_HistoryWithPersonID(int personID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT * FROM IDL_History_View WHERE PersonID = @PersonID";
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
