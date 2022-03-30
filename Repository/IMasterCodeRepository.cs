using HospitalSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Repository
{
    interface IMasterCodeRepository
    {
        List<MasterCodeViewModel> GetMasterDataByCode();
    }
}
