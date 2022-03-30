using HospitalSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Repository
{
    public interface IRoomRepository
    {
        List<RoomViewModel> GetRoomList(int id=0);
        HandleException Insert(RoomViewModel roomViewModel);
        RoomViewModel Details(int id);
        RoomViewModel Edit(int id = 0);
        HandleException Edit(RoomViewModel roomViewModel);
        RoomViewModel Delete(int id);
        HandleException Delete(RoomViewModel roomViewModel);
    }
}
