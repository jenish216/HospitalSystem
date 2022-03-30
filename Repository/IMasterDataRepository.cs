using HospitalSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Repository
{
    public interface IMasterDataRepository
    {
        List<MasterDataViewModel> GetList(int id = 0);
        HandleException Insert(MasterDataViewModel masterClassViewModel);      
        List<MasterDataViewModel> GetMasterDataByCode(int id);
        HandleException Edit(MasterDataViewModel masterClassViewModel);
        MasterDataViewModel Edit(int id);
        MasterDataViewModel Details(int id);
        HandleException Delete(MasterDataViewModel masterClassViewModel);
        MasterDataViewModel Delete(int id = 0);

    }
}
