using HospitalSystem.Models;
using HospitalSystem.Repository;
using HospitalSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalSystem.Controllers
{
    public class MasterController : Controller
    {
        // GET: Master
        private readonly HospitalManagementEntities db = new HospitalManagementEntities();
        private readonly MasterDataRepository _masterRepository;
        private readonly MasterCodeRepository _masterCodeRepository;
        public ActionResult Index()
        {
            return View();
        }
     
        public MasterController()
        {
            _masterRepository = new MasterDataRepository();
            _masterCodeRepository = new MasterCodeRepository();
        }
        public MasterController(MasterDataRepository masterRepository, MasterCodeRepository masterCodeRepository)
        {
            _masterRepository = masterRepository;
            _masterCodeRepository = masterCodeRepository;
        }
        public ActionResult GetList()
        {
            var room = _masterRepository.GetList();

            return View(room);
        }
        public ActionResult GetCodeList()
        {
            var cod = _masterCodeRepository.GetMasterDataByCode();
            return View(cod);
        }
        [HttpGet]
        public ActionResult Insert()
        {
            MasterDataViewModel masterClassViewModel = new MasterDataViewModel();
            masterClassViewModel.masterCodes = _masterCodeRepository.GetMasterDataByCode();
            masterClassViewModel.Masters = _masterRepository.GetList();
            return View(masterClassViewModel);
        }
        [HttpPost]
        public JsonResult Insert(MasterDataViewModel masterClassViewModel)
        {
            HandleException handleException = _masterRepository.Insert(masterClassViewModel);
            return Json(handleException, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var mas = _masterRepository.Details(id);


            return View(mas);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            MasterDataViewModel masterClassViewModel = new MasterDataViewModel();
            masterClassViewModel = _masterRepository.Edit(id);
            masterClassViewModel.masterCodes = _masterCodeRepository.GetMasterDataByCode();

            return View(masterClassViewModel);
        }
        [HttpPost]
        public JsonResult Edit(MasterDataViewModel masterClassViewModel)
        {
            HandleException handleException = _masterRepository.Edit(masterClassViewModel);
            return Json(handleException, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            MasterDataViewModel masterClassViewModel = new MasterDataViewModel();
            masterClassViewModel = _masterRepository.Delete(id);
            return View(masterClassViewModel);
        }

        [HttpPost]
        public JsonResult Delete(MasterDataViewModel masterClassViewModel)
        {
            HandleException handleException = _masterRepository.Delete(masterClassViewModel);
            return Json(handleException, JsonRequestBehavior.AllowGet);
        }
    }
}