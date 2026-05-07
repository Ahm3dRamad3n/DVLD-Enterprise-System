using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DVLD_DTOs;
using DVLD_Data_Access_Layer;
namespace DVLD_Business_Layer
{
    public class PersonBusinessLayer
    {
        public static int GetPersonIDByDriverID(int DriverID)
        {
            return PersonDataLayer.GetPersonIDByDriverID(DriverID);
        }
        public static string GetFullNameByID(int personID)
        {
            return PersonDataLayer.GetPersonFullName(personID);
        }
        public static bool AddPerson(ref clsPerson person)
        {
            return PersonDataLayer.AddPerson(ref person);
        }
        public static bool UpdatePerson(clsPerson person)
        {
            return PersonDataLayer.UpdatePerson(person);
        }
        public static DataTable LoadAllPeople()
        {
            return PersonDataLayer.LoadAllPeople();
        }
        public static clsPerson FindByID(int personID)
        {
            clsPerson person = new clsPerson();
            if (PersonDataLayer.FindByID(personID, ref person))
            {
                return person;
            }
            else
            {
                return null;
            }
        }
        public static clsPerson FindByNationalNo(string nationalNo)
        {
            clsPerson person = new clsPerson();
            if (PersonDataLayer.FindByNationalNo(nationalNo, ref person))
            {
                return person;
            }
            else
            {
                return null;
            }
        }
        public static bool IsExist(int personID)
        {
            return PersonDataLayer.IsExist(personID);
        }
        public static bool IsExist(string nationalNo)
        {
            return PersonDataLayer.IsExist(nationalNo);
        }
        public static bool DeletePerson(int personID)
        {
            return PersonDataLayer.DeletePerson(personID);
        }
    }
}
