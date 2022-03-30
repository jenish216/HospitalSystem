using HospitalSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Repository
{
   public interface IDoctorRepository
    {
        List<DoctorViewModel> DoctorList(int id=0);
        HandleException Insert(DoctorViewModel doctorViewModel);
        DoctorViewModel GetDoctorByID(int id);
        HandleException Update(DoctorViewModel doctorViewModel);
        DoctorViewModel Details(int id);
        DoctorViewModel Delete(int id);
        HandleException Delete(DoctorViewModel doctorViewModel);
    }
}
