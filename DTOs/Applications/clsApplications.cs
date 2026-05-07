using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DTOs
{
    public class clsApplications
    {
        public enum ApplicationStatusEnum
        {
            New = 1,
            Cancelled = 2,
            Completed = 3,
        }
        public int ApplicationID { get; set; }
        public int ApplicationPersonID { get; set; }
        public int ApplicationTypeID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public ApplicationStatusEnum ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public int PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public clsApplications()
        {
            ApplicationID = -1;
            ApplicationPersonID = -1;
            ApplicationTypeID = -1;
            ApplicationDate = DateTime.Now;
            ApplicationStatus = ApplicationStatusEnum.New;
            LastStatusDate = DateTime.Now;
            PaidFees = 0;
            CreatedByUserID = -1;
        }
    }
}
