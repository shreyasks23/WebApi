using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PatientDataAccess;

namespace WebApi.Controllers
{
    public class PatientDetailsController : ApiController
    {
        public IEnumerable<Tbl_Patient_Details> Get()
        {
            try
            {
                using ( PatientDBContext patientDBContext = new PatientDBContext())
                {
                    return patientDBContext.Tbl_Patient_Details.ToList();
                }
            }
            catch(Exception e)
            {
               Console.Write("error", e);

                return null;
            }
        }

        public Tbl_Patient_Details Get(int id)
        {
            using (PatientDBContext patientDBContext = new PatientDBContext())
            {
                return patientDBContext.Tbl_Patient_Details.FirstOrDefault(e => e.Patient_ID == id);
            }
        }
    }
}
