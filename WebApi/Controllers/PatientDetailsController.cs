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

        //Get all patient details 
        //@Path: api/patientdetails/
        public IEnumerable<Tbl_Patients> Get()
        {
            try
            {
                using ( PatientDBContext patientDBContext = new PatientDBContext())
                {
                    return patientDBContext.Tbl_Patients.ToList();
                }
            }
            catch(Exception e)
            {
               Console.Write("error", e);

                return null;
            }
        }


        //Get particular patient details using Patient_ID 
        //@Path: api/patientdetails/{id}
        public HttpResponseMessage Get(int id)
        {
            try {
                using (PatientDBContext patientDBContext = new PatientDBContext())
                {
                    var entities = patientDBContext.Tbl_Patients.FirstOrDefault(e => e.Patient_ID == id);

                    if (entities != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.OK, entities);
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient with ID: " + id + "is not found");
                    }
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //Insert new patient details
        //@Path: api/patientdetails/
        public HttpResponseMessage Post([FromBody]Tbl_Patients patient_Details)
        {
            try
            {
                using (PatientDBContext patientDBContext = new PatientDBContext())
                {
                    patientDBContext.Tbl_Patients.Add(patient_Details);
                    patientDBContext.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, patient_Details);
                    message.Headers.Location = new Uri(Request.RequestUri + patient_Details.Patient_ID.ToString());

                    return message;
                }
            }
            catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }
        }

        //update existing patient details
        //@Path: api/patientdetails/{id}
        public HttpResponseMessage Put(Tbl_Patients patient_Details)
        {
            try
            {
                using (PatientDBContext patientDBContext = new PatientDBContext())
                {
                   var entity = patientDBContext.Tbl_Patients.FirstOrDefault(e => e.Patient_ID == patient_Details.Patient_ID);

                    if(patient_Details != null)
                    {
                        entity.Age = patient_Details.Age;
                        entity.BloodPressure = patient_Details.BloodPressure;
                        entity.BMI = patient_Details.BMI;
                        entity.BodyFat = patient_Details.BodyFat;
                        entity.BodyWater = patient_Details.BodyWater;
                        entity.BoneMass = patient_Details.BoneMass;
                        entity.ECG = patient_Details.ECG;
                        entity.EyeTest = patient_Details.EyeTest;
                        entity.Gender = patient_Details.Gender;
                        entity.HaemoglobinCount = patient_Details.HaemoglobinCount;
                        entity.MuscleMass = patient_Details.MuscleMass;
                        entity.Hip = patient_Details.Hip;
                        entity.Height = patient_Details.Height;
                        entity.ECG = patient_Details.ECG;
                        entity.IdealBodyWeight = patient_Details.IdealBodyWeight;
                        entity.Patient_Location = patient_Details.Patient_Location;
                        entity.Patient_Name = patient_Details.Patient_Name;
                        entity.ExaminedOn = patient_Details.ExaminedOn;
                        entity.SkinTest = patient_Details.SkinTest;
                        entity.SPO2 = patient_Details.SPO2;
                        entity.VaccinationHB = patient_Details.VaccinationHB;
                        entity.VaccinationTyphoid = patient_Details.VaccinationTyphoid;
                        entity.Waist = patient_Details.Waist;
                        entity.WaistHeightRatio = patient_Details.WaistHeightRatio;
                        entity.WaistHipRatio = patient_Details.WaistHipRatio;

                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                    else
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Patient with ID: " + patient_Details.Patient_ID + "not found to update");
                    }
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,ex);
            }
        }

        //Delete patients of particular ID
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (PatientDBContext patientDBContext = new PatientDBContext())
                {
                    var entity =patientDBContext.Tbl_Patients.FirstOrDefault(e => e.Patient_ID == id);

                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with ID = " + id + "not found");
                    }

                    else
                    {
                        patientDBContext.Tbl_Patients.Remove(entity);
                        patientDBContext.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }

            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
