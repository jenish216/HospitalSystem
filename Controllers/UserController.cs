using HospitalSystem.Repository;
using HospitalSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalSystem.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        private readonly UserRepository _userRepository;
        public UserController()
        {
            _userRepository = new UserRepository();
        }
        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserList()
        {
            var user = _userRepository.UserList();
            return View(user);
        }
        [HttpGet]
        public ActionResult Register()
        {
            UserViewModel userViewModel = new UserViewModel();
            userViewModel.Users = _userRepository.UserList();
            return View(userViewModel);
        }

        [HttpPost]
        public JsonResult Register(UserViewModel userViewModel)
        {
            HandleException handleException = _userRepository.Register(userViewModel);
            return Json(handleException, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Login()
        {
            UserViewModel userViewModel = new UserViewModel();
            userViewModel.Users = _userRepository.UserList();
            return View(userViewModel);
        }

        [HttpPost]
        public JsonResult Login(UserViewModel userViewModel)
        {
            HandleException handleException = _userRepository.Login(userViewModel);
            return Json(handleException, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Details(int id)
        {
            var user = _userRepository.Details(id);
            return View(user);
        }

        public ActionResult Delete(int id)
        {
            // var user = _userRepository.Delete(id);
            return RedirectToAction("UserList");
        }
    }
}