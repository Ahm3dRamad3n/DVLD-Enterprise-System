using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient; using System.Configuration;
using System.Text;
using DVLD_DTOs;
 
 

namespace DVLD_Data_Access_Layer
{
     public class DetainedLicensesDataLayer
    {
        public static bool ReleaseDetainedLicense(int detainID, int releaseAppID)
        {
            bool isSuccess = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "UPDATE DetainedLicenses SET IsReleased = 1, ReleaseDate = @ReleaseDate, ReleasedByUserID = @ReleasedByUserID, ReleaseApplicationID = @ReleaseApplicationID WHERE DetainID = @DetainID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DetainID", detainID);
            command.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);
            command.Parameters.AddWithValue("@ReleasedByUserID", Program.CurrentUser.UserID);
            command.Parameters.AddWithValue("@ReleaseApplicationID", releaseAppID);
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
        public static bool DetainLicense(int licenseID,int fineFees, ref int DetainID)
        {
            bool isSuccess = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "INSERT INTO DetainedLicenses (LicenseID, DetainDate, FineFees, CreatedByUserID, IsReleased) VALUES (@LicenseID, @DetainDate, @FineFees, @CreatedByUserID, 0); SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", licenseID);
            command.Parameters.AddWithValue("@DetainDate", DateTime.Now);
            command.Parameters.AddWithValue("@FineFees", fineFees); 
            command.Parameters.AddWithValue("@CreatedByUserID", Program.CurrentUser.UserID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    DetainID = Convert.ToInt32(result);
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
        public static DataTable LoadAllDetainedLicenses()
        {
            DataTable dtDetainedLicenses = new DataTable();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT * FROM DetainedLicenses_View;";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dtDetainedLicenses.Load(reader);
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
            return dtDetainedLicenses;
        }
        public static bool IsLicenseDetained(int licenseID)
        {
            bool isDetained = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT COUNT(*) FROM DetainedLicenses WHERE LicenseID = @LicenseID AND IsReleased = 0";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", licenseID);
            try
            {
                connection.Open();
                int count = (int)command.ExecuteScalar();
                isDetained = count > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return isDetained;
        }
        public static DataRow FindByLicenseIDAndNotReleased(int licenseID)
        {
            DataRow detainedLicenseRecord = null;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT * FROM DetainedLicenses WHERE LicenseID = @LicenseID AND IsReleased = 0";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", licenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                if (dt.Rows.Count == 1)
                {
                    detainedLicenseRecord = dt.Rows[0];
                }
                else if (dt.Rows.Count > 1)
                {
                     throw new Exception("Data integrity error: Multiple detained license records found for the same LicenseID.");
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
            return detainedLicenseRecord;
        }
    }
}
