using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DVLD_DTOs;
using DVLD_Data_Access_Layer;

namespace DVLD_Business_Layer
{
    public class DriversBusinessLayer
    {
        public static DataTable LoadAllDrivers()
        {
            return DriversDataLayer.LoadAllDrivers();
        }
        public static int AddNewDriver(int personID, int createdByUserID)
        {
            return DriversDataLayer.AddNewDriver(personID, createdByUserID);
        }
        public static int GetDriverIDByPersonID(int personID)
        {
            return DriversDataLayer.GetDriverIDByPersonID(personID);
        }
        public static bool CheckDriverExistsByPersonID(int personID)
        {
            return DriversDataLayer.CheckDriverExistsByPersonID(personID);
        }
    }
}
