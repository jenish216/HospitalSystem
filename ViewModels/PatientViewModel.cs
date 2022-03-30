
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalSystem.ViewModels
{
    public class PatientViewModel
    {    
        
        public List<PatientViewModel> patientViews { get; set; }
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public Nullable<int> Age { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}