using HospitalSystem.Models;
using HospitalSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalSystem.Repository
{
    public class RoomRepository: IRoomRepository
    {
        private readonly HospitalManagementEntities db = new HospitalManagementEntities();
        HandleException handleException = new HandleException();

        public List<RoomViewModel> GetRoomList(int id=0)
        {
            List<RoomViewModel> HospitalList = new List<RoomViewModel>();
            List<ReadRoom_Result> rooms = db.ReadRoom(id).ToList();
            foreach (var item in rooms)
            {
                RoomViewModel svm = new RoomViewModel();
                svm = BindHospitalData(item);
                HospitalList.Add(svm);
            }
            return HospitalList;
        }

        private RoomViewModel BindHospitalData(ReadRoom_Result readRoom)
        {

            RoomViewModel rvm = new RoomViewModel();
            try
            {
                rvm.RoomID = readRoom.RoomID;
                rvm.RoomType = readRoom.RoomType;
                rvm.Charge = readRoom.Charge;
                rvm.TotalRoom = readRoom.TotalRoom;
            }
            catch (Exception ex)
            {
                handleException.Message = ex.Message;
            }
            return rvm;
        }
        public HandleException Insert(RoomViewModel roomViewModel)
        {
            HandleException handleException = new HandleException();
            try
            {
                var result = db.CreateRoom(roomViewModel.RoomID,
                                           roomViewModel.RoomType,
                                           roomViewModel.Charge,
                                           roomViewModel.TotalRoom,
                                           roomViewModel.IsActive
                                          );

                if (result != null)
                {
                    handleException.IsSuccess = true;
                    handleException.Message = "Successful";
                }
                else
                {
                    handleException.IsSuccess = false;
                    handleException.Message = "Error while inserting Room";
                }
            }
            catch (Exception ex)
            {
                handleException.Message = ex.Message;
            }
            return handleException;
        }
        public RoomViewModel Edit(int id = 0)
        {
            ReadRoom_Result room = db.ReadRoom(id).FirstOrDefault();

            RoomViewModel rmc = new RoomViewModel();
            rmc = BindHospitalData(room);
            return rmc;
        }
        public HandleException Edit(RoomViewModel roomViewModel)
        {
            HandleException handleException = new HandleException();
            try
            {
                var rmc = db.UpdateRoom(roomViewModel.RoomID, roomViewModel.RoomType, roomViewModel.TotalRoom, roomViewModel.Charge);
                if (rmc != null)
                {
                    handleException.IsSuccess = true;
                    handleException.Message = "Successful";
                }
                else
                {
                    handleException.IsSuccess = false;
                    handleException.Message = "Error while inserting Room";
                }
            }
            catch (Exception ex)
            {
                handleException.Message = ex.Message;
            }
            return handleException;
        }
        public RoomViewModel Details(int id)
        {
            var rmc = new RoomViewModel();
            ReadRoom_Result readRoom_Result = db.ReadRoom(id).FirstOrDefault();
            rmc = BindHospitalData(readRoom_Result);
            return rmc;

        }
        public RoomViewModel Delete(int id = 0)
        {
            ReadRoom_Result room = db.ReadRoom(id).FirstOrDefault();

            RoomViewModel rmc = new RoomViewModel();
            rmc = BindHospitalData(room);
            return rmc;
        }
        public HandleException Delete(RoomViewModel roomViewModel)
        {
            HandleException handleException = new HandleException();
            try
            {
                var rmc = db.DeleteRoom(roomViewModel.RoomID);
                if (rmc != null)
                {
                    handleException.IsSuccess = true;
                    handleException.Message = "Successful";
                }
                else
                {
                    handleException.IsSuccess = false;
                    handleException.Message = "Error while inserting Room";
                }
            }
            catch (Exception ex)
            {
                handleException.Message = ex.Message;
            }
            return handleException;
        }
    }
}