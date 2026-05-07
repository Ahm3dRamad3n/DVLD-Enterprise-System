using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DVLD_DTOs
{
    public class clsTests
    {
        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public bool IsPassed { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }
        public clsTests()
        {
            TestID = -1;
            TestAppointmentID = -1;
            IsPassed = false;
            Notes = string.Empty;
            CreatedByUserID = -1;
        }

    }
}
