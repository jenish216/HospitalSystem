using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalSystem.ViewModels
{
    public class DoctorViewModel
    {
        public List<DoctorDegreeViewModel> DoctorDegrees { get; set; }
        public List<DoctorViewModel> Doctors { get; set; }
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }
        public Nullable<int> DoctorDegree { get; set; }
        public string DegreeName { get; set; }
        public string DoctorExpertise { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}