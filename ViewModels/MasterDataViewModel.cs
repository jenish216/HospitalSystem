using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalSystem.ViewModels
{
    public class MasterDataViewModel
    {
        public List<MasterDataViewModel> Masters { get; set; }
        public List<MasterCodeViewModel> masterCodes { get; set; }
        public int ID { get; set; }
        public string DisplayText { get; set; }
        public int MasterCodeID { get; set; }
        public string MasterCodeName { get; set; }
        public string MasterCodeText { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}