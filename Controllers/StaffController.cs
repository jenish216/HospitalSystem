using HospitalSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalSystem.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        private readonly StaffRepository _staffRepository;
        public StaffController()
        {
            _staffRepository = new StaffRepository();
        }
        public StaffController(StaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AllStaff()
        {
            var staffs = _staffRepository.GetStaffList();
            return View(staffs);
        }
    }
}