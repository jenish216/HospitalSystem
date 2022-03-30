using HospitalSystem.Repository;
using HospitalSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalSystem.Controllers
{
    public class UserRoleController : Controller
    {
        // GET: UserRole
        private UserRoleRepository _userRoleRepository;
        private RolesRepository _rolesRepository;
        private UserRepository _userRepository;

        public UserRoleController()
        {
            _userRoleRepository = new UserRoleRepository();
            _rolesRepository = new RolesRepository();
            _userRepository = new UserRepository();
        }

        public UserRoleController(UserRoleRepository userRoleRepository, RolesRepository rolesRepository, UserRepository userRepository)
        {
            userRoleRepository = new UserRoleRepository();
            rolesRepository = new RolesRepository();
            userRepository = new UserRepository();
        }
        public ActionResult GetUserRoleList()
        {
            var userrole = _userRoleRepository.GetUserRoleList(0);
            return View(userrole);
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult AddUserRole()
        {
            UserRoleViewModel userRoleViewModel = new UserRoleViewModel();
            userRoleViewModel.Users = _userRepository.UserList(0);
            userRoleViewModel.Roles = _rolesRepository.GetRoleList(0);
            userRoleViewModel.UserRoles = _userRoleRepository.GetUserRoleList(0);
            return View(userRoleViewModel);
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public JsonResult AddUserRole(UserRoleViewModel userRoleViewModel)
        {
            HandleException handleException = _userRoleRepository.AddUserRole(userRoleViewModel);
            return Json(handleException, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult UpdateUserRole(int id = 0)
        {
            UserRoleViewModel userRoleViewModel = new UserRoleViewModel();
            userRoleViewModel = _userRoleRepository.UpdateUserRole(id);
            userRoleViewModel.Users = _userRepository.UserList(0);
            userRoleViewModel.Roles = _rolesRepository.GetRoleList(0);
            return View(userRoleViewModel);
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public JsonResult UpdateUserRole(UserRoleViewModel userRoleViewModel)
        {
            HandleException handleException = _userRoleRepository.UpdateUserRole(userRoleViewModel);
            return Json(handleException, JsonRequestBehavior.AllowGet);
        }
        //  [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Details(int id)
        {
            var userrole = _userRoleRepository.GetUserRoleId(id);
            return View(userrole);
        }

        //[Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            UserRoleViewModel userRoleViewModel = new UserRoleViewModel();
            userRoleViewModel = _userRoleRepository.DeleteUserRole(id);
            return View(userRoleViewModel);
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public JsonResult Delete(UserRoleViewModel userRoleViewModel)
        {
            HandleException handleException = _userRoleRepository.DeleteUserRole(userRoleViewModel);
            return Json(handleException, JsonRequestBehavior.AllowGet);
        }
    }
}