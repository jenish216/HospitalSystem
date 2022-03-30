using HospitalSystem.Repository;
using HospitalSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalSystem.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        private readonly DoctorRepository _doctorRepository;
        private readonly DoctorDegreeRepository _doctordegreeRepository;
        public DoctorController()
        {
            _doctordegreeRepository = new DoctorDegreeRepository();
            _doctorRepository = new DoctorRepository();
        }
        public DoctorController(DoctorDegreeRepository doctorDegreeRepository,DoctorRepository doctorRepository)
        {
            _doctordegreeRepository = doctorDegreeRepository;
            _doctorRepository = doctorRepository;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DegreeList()
        {
            var degree = _doctordegreeRepository.GetDoctorDegree();
            return View(degree);
        }
        public ActionResult AllDoctor(int id=0)
        {
            var degree = _doctorRepository.DoctorList(id);
            return View(degree);
        }
        [HttpGet]
        public ActionResult Insert()
        {
            DoctorViewModel doctorView = new DoctorViewModel();
            doctorView.DoctorDegrees = _doctordegreeRepository.GetDoctorDegree(0);
            doctorView.Doctors = _doctorRepository.DoctorList(0);
            return View(doctorView);
        }
        [HttpPost]
        public JsonResult Insert(DoctorViewModel doctorViewModel)
        {
            HandleException handleException = _doctorRepository.Insert(doctorViewModel);
            return Json(handleException, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult EditDoctor(int id)                       
        {
            DoctorViewModel doctorView = new DoctorViewModel();
            doctorView = _doctorRepository.GetDoctorByID(id);
            doctorView.DoctorDegrees = _doctordegreeRepository.GetDoctorDegree();      
          
            return View(doctorView);
        }
        [HttpPost]
        public JsonResult EditDoctor(DoctorViewModel doctorViewModel)
        {
            HandleException handleException = _doctorRepository.Update(doctorViewModel);
            return Json(handleException, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var doctors = _doctorRepository.Details(id);
            return View(doctors);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var doctor = _doctorRepository.Delete(id);
            return View(doctor);
        }
        [HttpPost]
        public JsonResult Delete(DoctorViewModel doctorViewModel)
        {
            HandleException handleException = _doctorRepository.Delete(doctorViewModel);
            return Json(handleException, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DoctorProfile()
        {
            return View();
        }
    }
}