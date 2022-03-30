using HospitalSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Repository
{
    public interface IDoctorDegree
    {
        List<DoctorDegreeViewModel> GetDoctorDegree(int id=0);
    }
}
