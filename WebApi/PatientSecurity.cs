using PatientDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi
{
    public class PatientSecurity
    {
        public static bool Login(String Username , String Password )
        {
            using (PatientDBContext patientDBContext = new PatientDBContext())
            {
                return patientDBContext.Tbl_Users.Any(user => user.User_Name.Equals(Username, StringComparison.OrdinalIgnoreCase) && user.Password == Password);
            }
        }
    }
}