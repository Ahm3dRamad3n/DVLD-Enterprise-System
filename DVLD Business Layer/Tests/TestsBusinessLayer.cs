using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DVLD_DTOs;
using DVLD_Data_Access_Layer;
namespace DVLD_Business_Layer
{
    public class TestsBusinessLayer
    {
        public static DataTable GetAllTestTypes()
        {
            return TestTypesDataLayer.GetAllTestTypes();
        }
        public static bool UpdateTestType(int TestTypeID, string TestTypeTitle, string TestTypeDescription, int TestTypeFees)
        {
            return TestTypesDataLayer.UpdateTestType(TestTypeID, TestTypeTitle, TestTypeDescription, TestTypeFees);
        }
        public static int GetTestTypeFeesByID(int TestTypeID)
        {
            return TestTypesDataLayer.GetTestTypeFeesByID(TestTypeID);
        }
        public static bool UpdateAppointmentDateByID(int appointmentId, DateTime newDate)
        {
            return TestsDataLayer.UpdateAppointmentDateByID(appointmentId, newDate);
        }
        public static DataRow GetTestInfoByAppointmentID(int appointmentId)
        {
            return TestsDataLayer.GetTestInfoByAppointmentID(appointmentId);
        }
        public static bool LockTestAppointmentByID(int appointmentId)
        {
            return TestsDataLayer.LockTestAppointmentByID(appointmentId);
        }
        public static bool SaveTestResult(clsTests test)
        {
            return TestsDataLayer.SaveTestResult(test);
        }
        public static int GetTrialNumberByALIdANDTestTypeId(int alId, int testTypeId)
        {
            return TestsDataLayer.GetTrialNumberByALIdANDTestTypeId(alId, testTypeId);
        }
        public static bool HasTestAppointmentUnlocked(int appLID, int testTypeID)
        {
            return TestsDataLayer.IsHasVisionTestAppointmentUnlocked(appLID, testTypeID);
        }
        public static bool AddTestAppointment(int testTypeID, int AppLID, int paidFees, DateTime testDate)
        {
            return TestsDataLayer.AddTestAppointment(testTypeID, AppLID, paidFees, testDate);
        }
        public static DataTable LoadTestAppointmentsByALIdANDTestTypeId(int alId, int testTypeId)
        {
            return TestsDataLayer.LoadTestAppointmentsByALIdANDTestTypeId(alId,testTypeId);
        }
        public static int GetPassedCountBy_ALId(int ldlId)
        {
            return TestsDataLayer.GetPassedCount(ldlId);
        }
    }
}
