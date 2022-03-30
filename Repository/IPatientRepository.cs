using HospitalSystem.Models;
using HospitalSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace HospitalSystem.Repository
{
    public interface IPatientRepository
    {
        List<PatientViewModel> GetPatientList(int id=0);
        HandleException Update(PatientViewModel patientView);
        HandleException Insert(PatientViewModel patientViewModel);
         PatientViewModel Details(int id);
        PatientViewModel Delete(int id);
        HandleException Delete(PatientViewModel patientView);
        PatientViewModel GetPatientByID(int id = 0);
    }
}