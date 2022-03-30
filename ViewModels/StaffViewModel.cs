using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalSystem.ViewModels
{
    public class StaffViewModel
    {
        public int StaffID { get; set; }
        public Nullable<int> UserID { get; set; }
        public string Name { get; set; }
        public Nullable<int> DegreeID { get; set; }
        public Nullable<int> PositionID { get; set; }
        public Nullable<int> ShiftID { get; set; }
        public Nullable<int> ExpertiseID { get; set; }
        public Nullable<int> TypeID { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}