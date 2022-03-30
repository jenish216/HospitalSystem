using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalSystem.ViewModels
{
    public class RolesViewModel
    {
        public List<RolesViewModel> Roles { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }
}