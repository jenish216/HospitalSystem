using HospitalSystem.Repository;
using HospitalSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalSystem.Controllers
{
    public class HomeController : Controller
    {

        private readonly FileCaseRepository _fileCaseRepository;
        private readonly MasterDataRepository _masterDataRepository;
        private readonly MasterCodeRepository _masterCodeRepository;
        private readonly PatientRepository _patientRepository;
        private readonly RoomRepository _roomRepository;
        public HomeController()
        {

            _fileCaseRepository = new FileCaseRepository();
            _masterDataRepository = new MasterDataRepository();
            _patientRepository = new PatientRepository();
            _roomRepository = new RoomRepository();
            _masterCodeRepository = new MasterCodeRepository();
        }
        public HomeController(FileCaseRepository fileCaseRepository, MasterDataRepository masterDataRepository, PatientRepository patientRepository, RoomRepository roomRepository,MasterCodeRepository masterCodeRepository)
        {

            _fileCaseRepository = fileCaseRepository;
            _masterDataRepository = masterDataRepository;
            _patientRepository = patientRepository;
            _roomRepository = roomRepository;
            _masterCodeRepository = masterCodeRepository;
        }
        public ActionResult GetFileList(int id=0)
        {

            var files = _fileCaseRepository.GetFileList(id);
            return View(files);
        }
            
        [HttpGet]
        public ActionResult Insert()
        {
            FileCaseViewModel fileCaseViewModel = new FileCaseViewModel();
            fileCaseViewModel.Diseasetype = _masterDataRepository.GetMasterData(1);
            fileCaseViewModel.StatusNames = _masterDataRepository.GetMasterData(3);
            fileCaseViewModel.relative_names = _masterDataRepository.GetMasterData(2);
            fileCaseViewModel.patientnames = _patientRepository.GetPatientList(0);
            fileCaseViewModel.Roomtypes = _roomRepository.GetRoomList(0);
            fileCaseViewModel.FileCases = _fileCaseRepository.GetFileList(0);

            return View(fileCaseViewModel);
        }
        [HttpPost]
        public JsonResult Insert(FileCaseViewModel fileCaseViewModel)
        {
            //HandleException handleException = _fileCaseRepository.Insert(fileCaseViewModel);
            var file = _fileCaseRepository.Insert(fileCaseViewModel);
            return Json(file, JsonRequestBehavior.AllowGet);
        }
        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    FileCaseViewModel fileCaseView = new FileCaseViewModel();
        //    fileCaseView = _fileCaseRepository.GetFileCaseByID(id);
        //    fileCaseView.Diseasetype = _masterDataRepository.GetMasterData(id);
        //    fileCaseView.StatusNames = _masterDataRepository.GetMasterData(id);
        //    fileCaseView.relative_names = _masterDataRepository.GetMasterData(id);
        //    fileCaseView.patientnames = _patientRepository.GetPatientByID(id);
        //    fileCaseView.Roomtypes = _roomRepository.Edit(id);
        //    return View(fileCaseView);
        //}
        [HttpPost]
        public JsonResult Edit(FileCaseViewModel fileCaseViewModel)
        {
            HandleException handleException = _fileCaseRepository.Edit(fileCaseViewModel);
            return Json(handleException, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Details(int id)
        {
            var student = _fileCaseRepository.Details(id);
            return View(student);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            
            var files = _fileCaseRepository.Delete(id);
            return View(files);
        }
        [HttpPost]
        public JsonResult Delete(FileCaseViewModel fileCaseViewModel)
        {
            HandleException handleException = _fileCaseRepository.Delete(fileCaseViewModel);
            return Json(handleException, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetMasterDataList(int id = 0)
        {
            var data = _masterDataRepository.GetList(id);
            return View(data);
        }
        public ActionResult GetMasterCodeList()
        {
            var code = _masterCodeRepository.GetMasterDataByCode();
            return View(code);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Homepage()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Calendar()
        {
            return View();
        }
        public ActionResult Register()
        {
            ViewBag.Message = "Your Register page.";
            return View();
        }
        public ActionResult Login()
        {
            ViewBag.Message = "Your Login page.";
            return View();
        }
        public ActionResult Recover()
        {
            return View();
        }
    }
}