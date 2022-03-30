using HospitalSystem.Models;
using HospitalSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalSystem.Repository
{
    public class MasterCodeRepository: IMasterCodeRepository
    {
        private readonly HospitalManagementEntities db = new HospitalManagementEntities();

        public List<MasterCodeViewModel> GetMasterDataByCode()
        {
            List<MasterCodeViewModel> masterCodeViewModels = new List<MasterCodeViewModel>();
            //List<MasterData> master = db.MasterDatas.ToList();
            List<ReadMasterCode_Result> master = db.ReadMasterCode().ToList();
            foreach (var item in master)
            {
                MasterCodeViewModel mvm = new MasterCodeViewModel();
                mvm = BindMasterDatabyCode(item);
                masterCodeViewModels.Add(mvm);
            }
            return masterCodeViewModels;
        }

        private MasterCodeViewModel BindMasterDatabyCode(ReadMasterCode_Result masterData)
        {
            MasterCodeViewModel mvm = new MasterCodeViewModel();
            mvm.CodeID = masterData.CodeID;
            mvm.CodeName = masterData.CodeName;
            mvm.CodeText = masterData.CodeText;
            return mvm;
        }
    }
}