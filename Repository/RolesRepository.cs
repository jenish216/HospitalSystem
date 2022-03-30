using HospitalSystem.Models;
using HospitalSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalSystem.Repository
{
    public class RolesRepository
    {
        private readonly HospitalManagementEntities db = new HospitalManagementEntities();

        public List<RolesViewModel> GetRoleList(int id = 0)
        {
            List<RolesViewModel> roleViewModels = new List<RolesViewModel>();
            List<ReadRole_Result> role = db.ReadRole(0).ToList();
            foreach (var item in role)
            {
                RolesViewModel rvm = new RolesViewModel();
                rvm = BindRole(item);
                roleViewModels.Add(rvm);
            }
            return roleViewModels;
        }



        private RolesViewModel BindRole(ReadRole_Result readRole_Result)
        {
            RolesViewModel rvm = new RolesViewModel();
            rvm.RoleID = readRole_Result.RoleID;
            rvm.RoleName = readRole_Result.RoleName;
            return rvm;
        }
    }
}