using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalSystem.ViewModels
{
    public class RoomViewModel
    {
        public List<RoomViewModel> Rooms { get; set; }
        public int RoomID { get; set; }
        public string RoomType { get; set; }
        public string Charge { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string TotalRoom { get; set; }
    }
}