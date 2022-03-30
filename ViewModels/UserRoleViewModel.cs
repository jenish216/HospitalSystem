using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalSystem.ViewModels
{
    public class UserRoleViewModel
    {
        public List<RolesViewModel> Roles { get; set; }
        public List<UserViewModel> Users { get; set; }
        public List<UserRoleViewModel> UserRoles { get; set; }
        public int UserRoleID { get; set; }
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string UserNames { get; set; }
        public string RoleNames { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}