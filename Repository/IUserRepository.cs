using HospitalSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Repository
{
   public interface IUserRepository
    {
        List<UserViewModel> UserList(int id = 0);
        HandleException Register(UserViewModel userViewModel);
        HandleException Login(UserViewModel userViewModel);
        UserViewModel Details(int id);
    }
}
