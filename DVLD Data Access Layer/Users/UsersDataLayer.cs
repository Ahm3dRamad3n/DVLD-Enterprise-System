using DVLD_DTOs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient; 
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
 

namespace DVLD_Data_Access_Layer
{
    public class UsersDataLayer
    {
        public static string GetUserNameByID(int userID)
        {
            string username = null;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "Select UserName from Users where UserID=@UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", userID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    username = result.ToString();
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
            return username;
        }
        public static bool DeleteUser(int userID)
        {
            bool deleted = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "Delete from Users where UserID=@UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", userID);
            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                deleted = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                deleted = false;
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return deleted;
        }
        public static bool UpdateUserInfo(clsUser user)
        {
            bool updated = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "Update Users set PersonID=@PersonID,Password = @Password, UserName=@UserName, IsActive=@IsActive, Permissions=@Permissions where UserID=@UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", user.Person.PersonID);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@UserName", user.UserName);
            command.Parameters.AddWithValue("@IsActive", user.IsActive);
            command.Parameters.AddWithValue("@UserID", user.UserID);
            command.Parameters.AddWithValue("@Permissions", user.permissions);
            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                updated = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                updated = false;
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return updated;
        }
        public static bool IsUserNameExist(string username)
        {
            bool exists = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = @"Select count(*)
                from Users where UserName=@UserName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", username);
            try
            {
                connection.Open();
                int count = (int)command.ExecuteScalar();
                exists = count > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return exists;
        }
        public static DataTable LoadAllUsers()
        {
            DataTable dtUsers = new DataTable();
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = @"Select UserID, PersonID,
                             UserName, FullName = FirstName + ' ' +
                             SecondName + ' ' + ThirdName + ' ' +
                             LastName, IsActive, Email from UsersData_View";
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                dtUsers.Load(reader);
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
            return dtUsers;
        }
        public static bool IsExist(int userID)
        {
            bool exists = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "Select count(*) from Users where UserID=@UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", userID);
            try
            {
                connection.Open();
                int count = (int)command.ExecuteScalar();
                exists = count > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return exists;
        }
        public static bool AddNewUser(ref clsUser user)
        {
            bool added = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "Insert into Users (PersonID, UserName, Password, IsActive, Permissions) values (@PersonID, @UserName, @Password, @IsActive, @Permissions); SELECT SCOPE_IDENTITY();";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", user.Person.PersonID);
            command.Parameters.AddWithValue("@UserName", user.UserName);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@IsActive", user.IsActive);
            command.Parameters.AddWithValue("@Permissions", user.permissions);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    user.UserID = Convert.ToInt32(result);
                    added = true;
                }
            }
            catch (Exception ex)
            {
                added = false;
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return added;
        }
        public static bool FindByID(int userID, ref clsUser user)
        {
            bool found = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "Select * from UsersData_View where UserID=@UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", userID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    found = true;
                    user.UserName = reader["UserName"].ToString();
                    user.Password = reader["Password"].ToString();
                    user.UserID = Convert.ToInt32(reader["UserID"]);
                    user.IsActive = Convert.ToBoolean(reader["IsActive"]);
                    user.permissions = Convert.ToInt32(reader["Permissions"]);
                    user.Person.PersonID = Convert.ToInt32(reader["PersonID"]);
                    user.Person.NationalNo = reader["NationalNo"].ToString();
                    user.Person.FirstName = reader["FirstName"].ToString();
                    user.Person.SecondName = reader["SecondName"].ToString();
                    user.Person.ThirdName = reader["ThirdName"].ToString();
                    user.Person.LastName = reader["LastName"].ToString();
                    user.Person.Address = reader["Address"].ToString();
                    user.Person.PhoneNumber = reader["Phone"].ToString();
                    user.Person.Email = reader["Email"].ToString();
                    user.Person.Gender = reader["Gender"].ToString();
                    user.Person.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                    user.Person.CountryID = Convert.ToInt32(reader["NationalityCountryID"]);
                    user.Person.ImagePath = reader["ImagePath"].ToString();
                    user.Person.Country = CountryDataLayer.GetCountryNameByID(user.Person.CountryID);
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

        public static bool FindByUserName(string username, string password, ref clsUser user)
        {
            bool found = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "Select * from UsersData_View where UserName=@UserName";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserName", username);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string dbPassword = reader["Password"].ToString();
                    if (dbPassword == password)
                    {
                        found = true;
                        user.UserID = Convert.ToInt32(reader["UserID"]);
                        user.IsActive = Convert.ToBoolean(reader["IsActive"]);
                        user.permissions = Convert.ToInt32(reader["Permissions"]);
                        user.Person.FirstName = reader["FirstName"].ToString();
                        user.Person.SecondName = reader["SecondName"].ToString();
                        user.Person.ThirdName = reader["ThirdName"].ToString();
                        user.Person.LastName = reader["LastName"].ToString();
                        user.Person.Address = reader["Address"].ToString();
                        user.Person.Country = reader["CountryName"].ToString();
                        user.Person.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                        user.Person.Email = reader["Email"].ToString();
                        user.Person.Gender = reader["Gender"].ToString();
                        user.Person.NationalNo = reader["NationalNo"].ToString();
                        user.Person.PhoneNumber = reader["Phone"].ToString();
                        user.Person.PersonID = Convert.ToInt32(reader["PersonID"]);
                        user.Person.ImagePath = reader["ImagePath"].ToString();

                    }
                }
                else
                {
                    found = false;
                }
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
        public static bool FindByEmail(string email, string password, ref clsUser user)
        {
            bool found = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "Select * from UsersData_View where Email=@Email";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", email);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string dbPassword = reader["Password"].ToString();
                    if (dbPassword == password)
                    {
                        found = true;
                        user.UserID = Convert.ToInt32(reader["UserID"]);
                        user.UserName = reader["UserName"].ToString();
                        user.IsActive = Convert.ToBoolean(reader["IsActive"]);
                        user.permissions = Convert.ToInt32(reader["Permissions"]);
                        user.Person.PersonID = Convert.ToInt32(reader["PersonID"]);
                        user.Person.FirstName = reader["FirstName"].ToString();
                        user.Person.SecondName = reader["SecondName"].ToString();
                        user.Person.ThirdName = reader["ThirdName"].ToString();
                        user.Person.LastName = reader["LastName"].ToString();
                        user.Person.Address = reader["Address"].ToString();
                        user.Person.Country = reader["CountryName"].ToString();
                        user.Person.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);
                        user.Person.PhoneNumber = reader["Phone"].ToString();
                        user.Person.Email = reader["Email"].ToString();
                        user.Person.ImagePath = reader["ImagePath"].ToString();
                        user.Person.Gender = reader["Gender"].ToString();
                    }
                }
                else
                {
                    found = false;
                }
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
        public static bool ChangePassword(int userID, string newPassword)
        {
            bool changed = false;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "Update Users set Password=@Password where UserID=@UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Password", newPassword);
            command.Parameters.AddWithValue("@UserID", userID);
            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                changed = rowsAffected > 0;
            }
            catch (Exception ex)
            {
                changed = false;
                throw ex;
            }
            finally
            {
                connection.Close();
            }
            return changed;
        }
        public static string GetEmailByUserID(int userID)
        {
            string email = null;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "Select Email from UsersData_View where UserID=@UserID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserID", userID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    email = result.ToString();
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
            return email;
        }
        public static int FindByUsernameOrEmail(string usernameORemail)
        {
            int userID = -1;
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DVLD"].ConnectionString);
            string query = "Select UserID from Users where UserName=@UserNameOrEmail or PersonID in (Select PersonID from People where Email=@UserNameOrEmail)";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@UserNameOrEmail", usernameORemail);
            try
            {
                connection.Open();
                object result = null;
                SqlDataReader reader = command.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count++;
                    if (count == 1)
                    {
                        result = reader["UserID"];
                    }
                }
                reader.Close();

                if (count > 1)
                {
                    throw new Exception("Multiple users found with the same username or email. Please contact support.");
                }

                if (result != null)
                {
                    userID = Convert.ToInt32(result);
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
            return userID;
        }
    }
}
