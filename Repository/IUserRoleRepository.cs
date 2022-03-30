using HospitalSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Repository
{
    interface IUserRoleRepository
    {
        List<UserRoleViewModel> GetUserRoleList(int id = 0);
        HandleException AddUserRole(UserRoleViewModel userRoleViewModel);
        HandleException UpdateUserRole(UserRoleViewModel userRoleViewModel);
        UserRoleViewModel GetUserRoleId(int id);
        HandleException DeleteUserRole(UserRoleViewModel userRoleViewModel);
        UserRoleViewModel DeleteUserRole(int id = 0);
    }
}
