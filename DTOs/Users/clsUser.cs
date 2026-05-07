using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DTOs
{
    public class clsUser
    {
        public int UserID { get; set; }
        public clsPerson Person { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int permissions { get; set; }
        public clsUser()
        {
            Person = new clsPerson();
            UserID = -1;
            UserName = string.Empty;
            Password = string.Empty;
            IsActive = false;
            permissions = -1; // Full permissions by default
        }
    }
}
