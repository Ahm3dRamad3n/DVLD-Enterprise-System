using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DVLD_DTOs;
using DVLD_Data_Access_Layer;

namespace DVLD_Business_Layer
{
    public class CountryBusinessLayer
    {
        public static string GetCountryNameByID(int countryID)
        {
            return CountryDataLayer.GetCountryNameByID(countryID);
        }
        public static DataTable List()
        {
            return CountryDataLayer.List();
        }
    }
}
