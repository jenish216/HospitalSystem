using HospitalSystem.ViewModels;
using HospitalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalSystem.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly HospitalManagementEntities db = new HospitalManagementEntities();
        public List<DoctorViewModel> DoctorList(int id = 0)
        {
            List<DoctorViewModel> doctors = new List<DoctorViewModel>();
            List<ReadDoctor_Result> doctor_Results = db.ReadDoctor(id).ToList();
            foreach (var item in doctor_Results)
              {
                DoctorViewModel doctorView = new DoctorViewModel();
                doctorView = BindDoctorData(item);
                doctors.Add(doctorView);
            }
            return doctors;
        }

        private DoctorViewModel BindDoctorData(ReadDoctor_Result item)
        {
            DoctorViewModel doctorView = new DoctorViewModel();
            doctorView.DoctorID = (int)item.DoctorID;
            doctorView.DoctorName = item.DoctorName;
            doctorView.DoctorExpertise = item.DoctorExpertise;
            doctorView.DoctorDegree = item.DoctorDegree;
            doctorView.DegreeName = item.DegreeNames;
            doctorView.IsActive = item.IsActive;
            return doctorView;
        }

        public HandleException Insert(DoctorViewModel doctorViewModel)
        {
            HandleException handleException = new HandleException();
            try
            {
                var result = db.CreateDoctor(doctorViewModel.DoctorID, doctorViewModel.DoctorName, doctorViewModel.DoctorDegree, doctorViewModel.DoctorExpertise, doctorViewModel.IsActive);
                if (result != null)
                {
                    handleException.IsSuccess = true;
                    handleException.Message = "Successful";
                }
                else
                {
                    handleException.IsSuccess = false;
                    handleException.Message = "Error while inserting Case";
                }
            }
            catch (Exception ex)
            {
                handleException.Message = ex.Message;
            }
            return handleException;
        }

        public DoctorViewModel GetDoctorByID(int id)
        {
            ReadDoctor_Result doctor_Result = db.ReadDoctor(id).FirstOrDefault();
            DoctorViewModel dvm = new DoctorViewModel();
            dvm = BindDoctorData(doctor_Result);

            return dvm;
        }
        public HandleException Update(DoctorViewModel doctorViewModel)
        {
            HandleException handleException = new HandleException();
            try
            {
                var result = db.UpdateDoctor(doctorViewModel.DoctorID, doctorViewModel.DoctorName, doctorViewModel.DoctorDegree, doctorViewModel.DoctorExpertise);
                if (result != null)
                {
                    handleException.IsSuccess = true;
                    handleException.Message = "Successful";
                }
                else
                {
                    handleException.IsSuccess = false;
                    handleException.Message = "Error while inserting Case";
                }
            }
            catch (Exception ex)
            {
                handleException.Message = ex.Message;
            }
            return handleException;
        }
       public DoctorViewModel Details(int id)
        {
            var dvm = new DoctorViewModel();
            ReadDoctor_Result readDoctor = db.ReadDoctor(id).FirstOrDefault();
            dvm = BindDoctorData(readDoctor);
            return dvm;
        }
        public DoctorViewModel Delete(int id)
        {
            ReadDoctor_Result doctor_Result = db.ReadDoctor(id).FirstOrDefault();
            DoctorViewModel doctorView = new DoctorViewModel();
            doctorView = BindDoctorData(doctor_Result);

            return doctorView;
        }
       public HandleException Delete(DoctorViewModel doctorViewModel)
        {
            HandleException handleException = new HandleException();
            try
            {
                var a = db.DeleteDoctor(doctorViewModel.DoctorID);

                if (a != null)
                {
                    handleException.IsSuccess = true;
                    handleException.Message = "Successful";
                }
                else
                {
                    handleException.IsSuccess = false;
                    handleException.Message = "Error while Delete Data";
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
