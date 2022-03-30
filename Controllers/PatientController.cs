using HospitalSystem.Repository;
using HospitalSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalSystem.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        private readonly PatientRepository _patientRepository;
        public PatientController()
        {
            _patientRepository = new PatientRepository();
        }
        public PatientController(PatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AllPatients(int id=0)
        {
            var hospital = _patientRepository.GetPatientList(id);
            return View(hospital);
        }
        [HttpGet]
        public ActionResult Insert()
        {
            PatientViewModel patientViewModel = new PatientViewModel();
             patientViewModel.patientViews = _patientRepository.GetPatientList();
            return View(patientViewModel);
        }
        [HttpPost]
        public JsonResult Insert(PatientViewModel patientViewModel)
        {
            HandleException handleException = _patientRepository.Insert(patientViewModel);
            return Json(handleException);

        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            PatientViewModel patientView = new PatientViewModel();
            patientView = _patientRepository.GetPatientByID(id);
            return View(patientView);
        }
       [HttpPost]
        public JsonResult Update(PatientViewModel patientViewModel)
        {
            HandleException handle = _patientRepository.Update(patientViewModel);
            return Json(handle, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Details(int id)
         {
            var patient = _patientRepository.Details(id);
            return View(patient);
        }
        [HttpGet]
       public ActionResult Delete(int id)
        {
            PatientViewModel patientView = new PatientViewModel();
            patientView = _patientRepository.Delete(id);
            return View(patientView);
        }
        [HttpPost]
        public JsonResult Delete(PatientViewModel patientViewModel)
        {
            HandleException handleException = _patientRepository.Delete(patientViewModel);
            return Json(handleException, JsonRequestBehavior.AllowGet);
        }
        public ActionResult PatientProfile()
        {
            return View();
        }
    }
}