using HospitalSystem.Models;
using HospitalSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalSystem.Repository
{
    public class UserRoleRepository: IUserRoleRepository
    {
        private readonly HospitalManagementEntities db = new HospitalManagementEntities();

        public List<UserRoleViewModel> GetUserRoleList(int Id = 0)
        {
            List<UserRoleViewModel> userRoleViewModels = new List<UserRoleViewModel>();
            List<ReadUserRole_Result> userrole = db.ReadUserRole(0).ToList();
            foreach (var item in userrole)
            {
                UserRoleViewModel urvm = new UserRoleViewModel();
                urvm = BindUserRole(item);
                userRoleViewModels.Add(urvm);
            }
            return userRoleViewModels;
        }
        public HandleException AddUserRole(UserRoleViewModel userRoleViewModel)
        {
            HandleException handleException = new HandleException();
            try
            {
                var result = db.CreateUserRole(userRoleViewModel.UserRoleID, userRoleViewModel.UserID, userRoleViewModel.RoleID, userRoleViewModel.IsActive);
                if (result != null)
                {
                    handleException.IsSuccess = true;
                    handleException.Message = "Successfull";
                }
                else
                {
                    handleException.IsSuccess = false;
                    handleException.Message = "Error while inserting UserRole";
                }
            }
            catch (Exception ex)
            {
                handleException.Message = ex.Message;
            }
            return handleException;
        }

        public HandleException UpdateUserRole(UserRoleViewModel userRoleViewModel)
        {
            HandleException handleException = new HandleException();
            try
            {
                var result = db.UpdateUserRole(userRoleViewModel.UserRoleID, userRoleViewModel.UserID, userRoleViewModel.RoleID);
                if (result != null)
                {
                    handleException.IsSuccess = true;
                    handleException.Message = "SuccessFul";
                }
                else
                {
                    handleException.IsSuccess = false;
                    handleException.Message = "Error while inserting userrole";
                }
            }
            catch (Exception ex)
            {

                handleException.Message = ex.Message;
            }
            return handleException;
        }

        public UserRoleViewModel UpdateUserRole(int id)
        {
            ReadUserRole_Result userrole = db.ReadUserRole(id).FirstOrDefault();
            UserRoleViewModel urvm = new UserRoleViewModel();
            urvm = BindUserRole(userrole);
            return urvm;
        }
        public UserRoleViewModel GetUserRoleId(int id)
        {
            var urvm = new UserRoleViewModel();
            ReadUserRole_Result readUserRole = db.ReadUserRole(id).FirstOrDefault();
            urvm = BindUserRole(readUserRole);
            return urvm;
        }

        public HandleException DeleteUserRole(UserRoleViewModel userRoleViewModel)
        {
            HandleException handleException = new HandleException();
            try
            {
                var result = db.DeleteUserRole(userRoleViewModel.UserRoleID);
                if (result != null)
                {
                    handleException.IsSuccess = true;
                    handleException.Message = "SuccessFul";
                }
                else
                {
                    handleException.IsSuccess = false;
                    handleException.Message = "Error while inserting userrole";
                }
            }
            catch (Exception ex)
            {

                handleException.Message = ex.Message;
            }
            return handleException;
        }

        public UserRoleViewModel DeleteUserRole(int id = 0)
        {
            ReadUserRole_Result userrole = db.ReadUserRole(id).FirstOrDefault();
            UserRoleViewModel urvm = new UserRoleViewModel();
            urvm = BindUserRole(userrole);
            return urvm;
        }
        private UserRoleViewModel BindUserRole(ReadUserRole_Result userrole)
        {
            UserRoleViewModel urvm = new UserRoleViewModel();
            urvm.UserRoleID = userrole.UserRoleID;
            urvm.UserNames = userrole.UserNames;
            urvm.RoleNames = userrole.RoleNames;
            return urvm;

        }
    }
}