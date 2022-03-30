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
    public class RoomController : Controller
    {
        // GET: Room
        private HospitalManagementEntities db = new HospitalManagementEntities();
        public RoomRepository _roomRepository;
        public RoomController()
        {
            _roomRepository = new RoomRepository();
        }
        public RoomController(RoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AllotedRooms()
        {
            var rooms = _roomRepository.GetRoomList();
            return View(rooms);
        }
        [HttpGet]
        public ActionResult AddRoom()
        {
            RoomViewModel roomViewModel = new RoomViewModel();
            roomViewModel.Rooms = _roomRepository.GetRoomList();
            return View(roomViewModel);
        }
        [HttpPost]
        public JsonResult AddRoom(RoomViewModel roomViewModel)
        {
            HandleException handleException = _roomRepository.Insert(roomViewModel);
            return Json(handleException, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult EditRoom(int id)
        {
            RoomViewModel roomViewModel = new RoomViewModel();
            roomViewModel = _roomRepository.Edit(id);
            return View(roomViewModel);
        }
        [HttpPost]
        public JsonResult EditRoom(RoomViewModel roomViewModel)
        {
            HandleException handleException = _roomRepository.Edit(roomViewModel);
            return Json(handleException, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Details(int id)
        {
            var room = _roomRepository.Details(id);

            return View(room);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            RoomViewModel roomViewModel = new RoomViewModel();
            roomViewModel = _roomRepository.Delete(id);
            return View(roomViewModel);
        }
        [HttpPost]
        public JsonResult Delete(RoomViewModel roomViewModel)
        {
            HandleException handleException = _roomRepository.Delete(roomViewModel);
            return Json(handleException, JsonRequestBehavior.AllowGet);

        }
    }
}