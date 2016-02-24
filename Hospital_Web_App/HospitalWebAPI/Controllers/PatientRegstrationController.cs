
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CommanUtilities;
using HospitalWebAPI.Models;
using System.Data;
using Newtonsoft.Json;

namespace HospitalWebAPI.Controllers
{
    public class PatientRegstrationController : ApiController
    {

        MSAccessDataUtility du = new MSAccessDataUtility();
        List<Patient> Patients = new List<Patient>();

        PatientRegstrationController()
        {
            GetPatientList();
        }
        private void GetPatientList()
        {

            var PatientList = GetDataRow().Tables[0].AsEnumerable().Select(r =>
            new Patient
            {
                //AddDate = r.Field<DateTime>("AddDate"),
                PatientID = r.Field<string>("PatientID"),
                Name = r.Field<string>("name"),
 
            }).ToList();

            foreach (Patient patient in PatientList)
            {
                Patients.Add(patient);
            }
        }
        private DataSet GetDataRow()
        {
            return GetPatientList("PatientRegstration");
        }

        public DataSet GetPatientList(string TableName)
        {
            return du.GetTable(TableName);
        }
        public DataSet GetPatient(string TableName, string PatientID)
        {
            String condition = PatientID == "" ? "" : " PatientID='" + PatientID + "'";
            return du.GetTable(TableName, condition);
        }
        public bool AddPatient(Patient patient)
        {
            return du.AddRow(@"insert into PatientRegstration(ID,PatientID,Name) 
            values(" + patient.Id + ",'" + patient.PatientID + "', '" + patient.Name + "')"  );
        }
        public bool DeleteParrty(Patient patient)
        {
            return du.DeleteRow(@"update PatientRegstration set DeleteFlag = 1 where PatientID ='" + patient.PatientID + "')");
        }
        public IEnumerable<Patient> GetAllPatient()
        {
            return Patients;
        }

        public IHttpActionResult GetPatient(string PatientID)
        {
            var patient = Patients.FirstOrDefault((p) => p.PatientID == PatientID);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }
    }
}
