using HospitalSystem.Models;
using HospitalSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalSystem.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly HospitalManagementEntities db = new HospitalManagementEntities();

        public object item { get; private set; }

        public List<UserViewModel> UserList(int id = 0)
        {
            List<UserViewModel> readusers_Results = new List<UserViewModel>();
            List<ReadUsers_Result> readUsers = db.ReadUsers(id).ToList();

            foreach (var item in readUsers)
            {
                UserViewModel uvm = new UserViewModel();
                uvm = BindUserList(item);
                readusers_Results.Add(uvm);
            }
            return readusers_Results;
        }

        private UserViewModel BindUserList(ReadUsers_Result item)
        {
            UserViewModel uvm = new UserViewModel();
            uvm.UserID = (int)item.UserID;
            uvm.UserName = item.UserName;
            uvm.Password = item.Password;
            uvm.EmailAddress = item.EmailAddress;

            return uvm;
        }

        public HandleException Register(UserViewModel userViewModel)
        {
            HandleException handleException = new HandleException();
            try
            {
                var result = db.CreateUsers(userViewModel.UserID, userViewModel.UserName, userViewModel.Password, userViewModel.EmailAddress, userViewModel.IsActive);

                if (result != null)
                {

                    handleException.IsSuccess = true;
                    handleException.Message = "Successful";
                }
                else
                {
                    handleException.IsSuccess = false;
                    handleException.Message = "Error while inserting Case";
                }
            }
            catch (Exception ex)
            {
                handleException.Message = ex.Message;

            }
            return handleException;
        }

        public HandleException Login(UserViewModel userViewModel)
        {
            HttpContext.Current.Session["UserName"] = userViewModel.UserName;
            HandleException handleException = new HandleException();
            try
            {
                var result = db.ValidateUser(userViewModel.UserName, userViewModel.Password);


                if (result.FirstOrDefault() == "true")
                {
                    handleException.IsSuccess = true;
                    handleException.Message = "Successful";
                }
                else
                {
                    handleException.IsSuccess = false;
                    handleException.Message = "Error while inserting Case";
                }
            }
            catch (Exception ex)
            {
                handleException.Message = ex.Message;

            }
            return handleException;
        }


        public UserViewModel Details(int id)
        {
            var uvm = new UserViewModel();
            ReadUsers_Result readUsers = db.ReadUsers(id).FirstOrDefault();
            uvm = BindUserList(readUsers);
            return uvm;
        }
    }
}