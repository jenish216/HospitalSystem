using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalSystem.ViewModels
{
    public class MasterCodeViewModel
    {
        public int CodeID { get; set; }
        public string CodeText { get; set; }
        public string CodeName { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}