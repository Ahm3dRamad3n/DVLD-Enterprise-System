using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient; using System.Configuration;
using System.Linq;
using System.Text;
using DVLD_DTOs;
 
 

namespace DVLD_Data_Access_Layer
{
     public class LicenseClassesDataLayer
    {
        public static int GetExpiryPeriodByClassID(int classId)
        {
            int expiryPeriod = 0;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT ExpiryPeriod FROM LicenseClasses WHERE LicenseClassID = @classId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@classId", classId);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    expiryPeriod = Convert.ToInt32(result);
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
            return expiryPeriod;
        }
        public static int GetFeesByClassID(int classId)
        {
            int fees = 0;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT ClassFees FROM LicenseClasses WHERE LicenseClassID = @classId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@classId", classId);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    fees = Convert.ToInt32(result);
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
            return fees;
        }
        public static int GetLicenseClassIDByALId(int ALId)
        {
            int classId = -1;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT LicenseClasses.LicenseClassID FROM LicenseClasses INNER JOIN AppLicenses ON LicenseClasses.LicenseClassID = AppLicenses.LicenseClassID WHERE AppLicenses.AppLicenseID = @ALId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ALId", ALId);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    classId = Convert.ToInt32(result);
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
            return classId;
        }
        public static string GetLicenseClassNameByID(int classId)
        {
            string className = string.Empty;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT ClassName FROM LicenseClasses WHERE LicenseClassID = @classId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@classId", classId);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    className = Convert.ToString(result);
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
            return className;
        }
        public static DataTable GetLicenseClassesList()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT * FROM LicenseClasses";
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
