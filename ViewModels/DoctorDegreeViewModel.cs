using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalSystem.ViewModels
{
    public class DoctorDegreeViewModel
    {
        public int DegreeID { get; set; }
        public string DegreeName { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}