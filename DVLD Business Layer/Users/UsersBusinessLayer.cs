using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using DVLD_DTOs;
using DVLD_Data_Access_Layer;
namespace DVLD_Business_Layer
{
    public class UsersBusinessLayer
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }
        public static bool IsUserNameExist(string username)
        {
            return UsersDataLayer.IsUserNameExist(username);
        }
        public static clsUser Find(string usernameORemail, string password)
        {
            clsUser user = new clsUser();
            if (UsersDataLayer.FindByUserName(usernameORemail, password, ref user))
            {
                user.UserName = usernameORemail;
                user.Password = password;
                return user;
            }
            else if (UsersDataLayer.FindByEmail(usernameORemail, password, ref user))
            {
                user.Person.Email = usernameORemail;
                user.Password = password;
                return user;
            }
            else
            {
                return null;
            }
        }
        public static bool UpdateUserInfo(clsUser user)
        {
            return UsersDataLayer.UpdateUserInfo(user);
        }
        public static bool DeleteUser(int userID)
        {
            return UsersDataLayer.DeleteUser(userID);
        }
        public static bool IsExist(int userID)
        {
            return UsersDataLayer.IsExist(userID);
        }
        public static clsUser FindByID(int userID)
        {
            clsUser user = new clsUser();
            if (UsersDataLayer.FindByID(userID, ref user))
            {
                return user;
            }
            else
            {
                return null;
            }
        }
        public static bool ChangePassword(int userID, string newPassword)
        {
            return UsersDataLayer.ChangePassword(userID, newPassword);
        }
        public static DataTable LoadAllUsers()
        {
            return UsersDataLayer.LoadAllUsers();
        }
        public static bool AddNewUser(ref clsUser user)
        {
            user.Password = HashPassword(user.Password);
            return UsersDataLayer.AddNewUser(ref user);
        }
        public static string GetUserNameByID(int userID)
        {
            return UsersDataLayer.GetUserNameByID(userID);
        }
        public static string GetEmailByUserID(int userID)
        {
            return UsersDataLayer.GetEmailByUserID(userID);
        }
        public static int FindByUsernameOrEmail(string usernameORemail)
        {
            return UsersDataLayer.FindByUsernameOrEmail(usernameORemail);
        }
    }
}
