using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient; using System.Configuration;
using System.Text;
using DVLD_DTOs;
using System.Data;
 
 

namespace DVLD_Data_Access_Layer
{
     public class TestsDataLayer
    {
        public static bool UpdateAppointmentDateByID(int appointmentId, DateTime newDate)
        {
            bool Updated = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "UPDATE TestAppointments SET AppointmentDate = @AppointmentDate WHERE TestAppointmentID = @TestAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AppointmentDate", newDate);
            command.Parameters.AddWithValue("@TestAppointmentID", appointmentId);
            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Updated = true;
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
            return Updated;
        }
        public static DataRow GetTestInfoByAppointmentID(int appointmentId)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT dbo.AppLicenses.AppLicenseID, dbo.LicenseClasses.ClassName, dbo.People.FirstName + N' ' + dbo.People.SecondName + N' ' + ISNULL(dbo.People.ThirdName, N'') + N' ' + dbo.People.LastName AS FullName,\r\ndbo.TestAppointments.AppointmentDate AS TestDate, CAST(dbo.TestAppointments.PaidFees AS INT) AS PaidFees FROM dbo.AppLicenses INNER JOIN\r\ndbo.TestAppointments ON dbo.AppLicenses.AppLicenseID = dbo.TestAppointments.AppLicenseID INNER JOIN         \r\ndbo.Applications ON dbo.AppLicenses.ApplicationID = dbo.Applications.ApplicationID INNER JOIN              \r\ndbo.People ON dbo.Applications.ApplicationPersonID = dbo.People.PersonID INNER JOIN                   \r\ndbo.LicenseClasses ON dbo.AppLicenses.LicenseClassID = dbo.LicenseClasses.LicenseClassID WHERE TestAppointments.TestAppointmentID = @TestAppointmentID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", appointmentId);
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

            if (dataTable.Rows.Count == 1)
            {
                return dataTable.Rows[0];
            }
            else if (dataTable.Rows.Count > 1)
            {
                throw new Exception("Multiple records found for the given Test Appointment ID.");
            }
            else
            {
                return null;
            }
        }
        public static bool LockTestAppointmentByID(int appointmentId)
        {
            bool Locked = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "UPDATE TestAppointments SET IsLocked = 1 WHERE TestAppointmentID = @TestAppointmentID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", appointmentId);
            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Locked = true;
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
            return Locked;
        }
        public static bool SaveTestResult(clsTests test)
        {
            bool Saved = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "INSERT INTO Tests (TestAppointmentID, IsPassed, Notes, CreatedByUserID) VALUES (@TestAppointmentID, @IsPassed, @Notes, @CreatedByUserID); SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", test.TestAppointmentID);
            command.Parameters.AddWithValue("@IsPassed", test.IsPassed);
            command.Parameters.AddWithValue("@Notes", test.Notes);
            command.Parameters.AddWithValue("@CreatedByUserID", test.CreatedByUserID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    test.TestID = Convert.ToInt32(result);
                    Saved = true;
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
            return Saved;
        }
        public static int GetTrialNumberByALIdANDTestTypeId(int alId, int testTypeId)
        {
            int trialNumber = 0;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "Select count(*) AS TrialNumber From Tests INNER JOIN TestAppointments\r\nON Tests.TestAppointmentID = TestAppointments.TestAppointmentID\r\nWhere Tests.IsPassed = 0 AND TestAppointments.TestTypeID = @TestTypeID AND TestAppointments.AppLicenseID = @AppLicenseID;";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AppLicenseID", alId);
            command.Parameters.AddWithValue("@TestTypeID", testTypeId);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    trialNumber = Convert.ToInt32(reader["TrialNumber"]);
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
            return trialNumber;
        }
        public static bool IsHasVisionTestAppointmentUnlocked(int appLID, int testTypeID)
        {
            bool hasUnlocked = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT COUNT(*) AS UnlockedCount FROM TestAppointments WHERE AppLicenseID = @AppLicenseID AND TestTypeID = @TestTypeID AND IsLocked = 0";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@AppLicenseID", appLID);
            command.Parameters.AddWithValue("@TestTypeID", testTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    int count = Convert.ToInt32(reader["UnlockedCount"]);
                    hasUnlocked = count > 0;
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
            return hasUnlocked;
        }
        public static bool AddTestAppointment(int testTypeID, int AppLID, int paidFees, DateTime testDate)
        {
            bool Added = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "INSERT INTO TestAppointments (TestTypeID, AppLicenseID,AppointmentDate, PaidFees, CreatedByUserID,IsLocked) VALUES (@TestTypeID, @AppLicenseID, @AppointmentDate, @PaidFees, @CreatedByUserID, @IsLocked)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", testTypeID);
            command.Parameters.AddWithValue("@AppLicenseID", AppLID);
            command.Parameters.AddWithValue("@AppointmentDate", testDate);
            command.Parameters.AddWithValue("@PaidFees", paidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", Program.CurrentUser.UserID);
            command.Parameters.AddWithValue("@IsLocked", 0);
            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Added = true;
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
            return Added;
        }
        public static DataTable LoadTestAppointmentsByALIdANDTestTypeId(int ALId, int testTypeID)
        {
            DataTable dataTable = new DataTable();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT        TestAppointmentID AS AppointmentID, AppointmentDate, PaidFees, IsLocked, AppLicenseID\r\nFROM            dbo.TestAppointments\r\nWHERE   TestTypeID = @TestTypeID AND AppLicenseID = @AppLicenseID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", testTypeID);
            command.Parameters.AddWithValue("@AppLicenseID", ALId);
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
        public static int GetPassedCount(int ldlId)
        {
            int count = 0;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT COUNT(dbo.TestAppointments.TestTypeID) AS PassedCount FROM dbo.Tests INNER JOIN dbo.TestAppointments ON dbo.Tests.TestAppointmentID = dbo.TestAppointments.TestAppointmentID WHERE dbo.TestAppointments.AppLicenseID = @ldlId AND (dbo.Tests.IsPassed = 1)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ldlId", ldlId);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    count = Convert.ToInt32(reader["PassedCount"]);
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
            return count;
        }
    }
}
