using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DVLD_DTOs
{
    public class clsLocalLicense
    {
        public int LicenseID { get; set; }  
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public int PaidFees { get; set; }
        public int IssueReasonID { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public clsLocalLicense()
        {
            LicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            LicenseClassID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            Notes = string.Empty;
            IssueReasonID = -1;
            PaidFees = -1;
            IsActive = true;
            CreatedByUserID = -1;
        }
        
    }
}
