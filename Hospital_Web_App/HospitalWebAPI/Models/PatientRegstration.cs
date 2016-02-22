using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalWebAPI.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string PatientID { get; set; }
        public string Name { get; set; } 
        public string AttendentName { get; set; }
        public string Sex { get; set; }
    }
}