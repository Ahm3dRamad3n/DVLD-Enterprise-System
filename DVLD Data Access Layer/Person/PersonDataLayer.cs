using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient; using System.Configuration;
using DVLD_DTOs;
using System.Net;
using System.Data;
 
 

namespace DVLD_Data_Access_Layer
{
     public class PersonDataLayer
    {
        public static int GetPersonIDByDriverID(int DriverID)
        {
            int personID = -1;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT personID FROM Drivers WHERE DriverID = @DriverID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    personID = reader.GetInt32(0);
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
            return personID;
        }
        public static string GetPersonFullName(int personID)
        {
            string fullName = string.Empty;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT FirstName, SecondName, ThirdName, LastName FROM People WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", personID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    fullName = string.Format("{0} {1} {2} {3}",
                        reader["FirstName"].ToString(),
                        reader["SecondName"].ToString(),
                        reader["ThirdName"].ToString(),
                        reader["LastName"].ToString());
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
            return fullName;
        }
        public static bool AddPerson(ref clsPerson person)
        {
            bool Added = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "INSERT INTO People (NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth, Gender, Address, Phone, Email, NationalityCountryID, ImagePath) " +
                "output INSERTED.PersonID " +
                "VALUES (@NationalNo, @FirstName, @SecondName, @ThirdName, @LastName, @DateOfBirth, @Gender, @Address, @Phone, @Email, @NationalityCountryID, @ImagePath)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", person.NationalNo);
            command.Parameters.AddWithValue("@FirstName", person.FirstName);
            command.Parameters.AddWithValue("@SecondName", person.SecondName);
            command.Parameters.AddWithValue("@ThirdName", person.ThirdName);
            command.Parameters.AddWithValue("@LastName", person.LastName);
            command.Parameters.AddWithValue("@DateOfBirth", person.DateOfBirth);
            command.Parameters.AddWithValue("@Gender", person.Gender);
            command.Parameters.AddWithValue("@Address", person.Address);
            command.Parameters.AddWithValue("@Phone", person.PhoneNumber);
            command.Parameters.AddWithValue("@Email", person.Email);
            command.Parameters.AddWithValue("@NationalityCountryID", person.CountryID);
            command.Parameters.AddWithValue("@ImagePath", person.ImagePath);
            try
            {
                connection.Open();
                person.PersonID = (int)command.ExecuteScalar();
                Added = person.PersonID > 0;
            }
            catch (Exception ex)
            {
                Added = false;
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return Added;
        }
        public static bool UpdatePerson(clsPerson person)
        {
            bool Updated = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "UPDATE People SET NationalNo = @NationalNo, FirstName = @FirstName, SecondName = @SecondName, ThirdName = @ThirdName, LastName = @LastName" +
                ", DateOfBirth = @DateOfBirth, Gender = @Gender, Address = @Address, Phone = @Phone, Email = @Email, NationalityCountryID = @NationalityCountryID, ImagePath = @ImagePath" +
                " WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", person.NationalNo);
            command.Parameters.AddWithValue("@FirstName", person.FirstName);
            command.Parameters.AddWithValue("@SecondName", person.SecondName);
            command.Parameters.AddWithValue("@ThirdName", person.ThirdName);
            command.Parameters.AddWithValue("@LastName", person.LastName);
            command.Parameters.AddWithValue("@DateOfBirth", person.DateOfBirth);
            command.Parameters.AddWithValue("@Gender", person.Gender);
            command.Parameters.AddWithValue("@Address", person.Address);
            command.Parameters.AddWithValue("@Phone", person.PhoneNumber);
            command.Parameters.AddWithValue("@Email", person.Email);
            command.Parameters.AddWithValue("@NationalityCountryID", person.CountryID);
            command.Parameters.AddWithValue("@ImagePath", person.ImagePath);
            command.Parameters.AddWithValue("@PersonID", person.PersonID);
            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Updated = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Updated = false;
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return Updated;
        }
        public static DataTable LoadAllPeople()
        {
            DataTable dtPeople = new DataTable();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT * FROM People Inner Join Countries on People.NationalityCountryID=Countries.CountryID";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dtPeople.Load(reader);
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
            return dtPeople;
        }
        public static bool FindByID(int PersonID, ref clsPerson person)
        {
            bool found = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT * FROM People WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    found = true;
                    person.PersonID = Convert.ToInt32(reader["PersonID"]);
                    person.NationalNo = reader["NationalNo"].ToString();
                    person.FirstName = reader["FirstName"].ToString();
                    person.SecondName = reader["SecondName"].ToString();
                    person.ThirdName = reader["ThirdName"].ToString();
                    person.LastName = reader["LastName"].ToString();
                    person.Address = reader["Address"].ToString();
                    person.PhoneNumber = reader["Phone"].ToString();
                    person.Email = reader["Email"].ToString();
                    person.Gender = reader["Gender"].ToString();
                    person.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    person.CountryID = Convert.ToInt32(reader["NationalityCountryID"]);
                    person.ImagePath = reader["ImagePath"].ToString();
                    person.Country = CountryDataLayer.GetCountryNameByID(person.CountryID);
                }
                else
                {
                    found = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                found = false;
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return found;
        }
        public static bool FindByNationalNo(string NationalNO, ref clsPerson person)
        {
            bool found = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT * FROM People WHERE NationalNO = @NationalNO";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNO", NationalNO);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    found = true;
                    person.PersonID = Convert.ToInt32(reader["PersonID"]);
                    person.NationalNo = reader["NationalNo"].ToString();
                    person.FirstName = reader["FirstName"].ToString();
                    person.SecondName = reader["SecondName"].ToString();
                    person.ThirdName = reader["ThirdName"].ToString();
                    person.LastName = reader["LastName"].ToString();
                    person.Address = reader["Address"].ToString();
                    person.PhoneNumber = reader["Phone"].ToString();
                    person.Email = reader["Email"].ToString();
                    person.Gender = reader["Gender"].ToString();
                    person.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    person.CountryID = Convert.ToInt32(reader["NationalityCountryID"]);
                    person.ImagePath = reader["ImagePath"].ToString();
                    person.Country = CountryDataLayer.GetCountryNameByID(person.CountryID);
                }
                else
                {
                    found = false;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                found = false;
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return found;
        }
        public static bool IsExist(int personID)
        {
            bool exists = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT COUNT(1) FROM People WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", personID);
            try
            {
                connection.Open();
                int count = (int)command.ExecuteScalar();
                exists = count > 0;
            }
            catch (Exception ex)
            {
                exists = false;
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return exists;
        }
        public static bool IsExist(string nationalNo)
        {
            bool exists = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "SELECT COUNT(1) FROM People WHERE NationalNo = @NationalNo";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@NationalNo", nationalNo);
            try
            {
                connection.Open();
                int count = (int)command.ExecuteScalar();
                exists = count > 0;
            }
            catch (Exception ex)
            {
                exists = false;
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return exists;
        }
        public static bool DeletePerson(int personID)
        {
            bool Deleted = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "DELETE FROM People WHERE PersonID = @PersonID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", personID);
            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Deleted = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Deleted = false;
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return Deleted;
        }
    }
}
