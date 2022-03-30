using HospitalSystem.Models;
using HospitalSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace HospitalSystem.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly HospitalManagementEntities db = new HospitalManagementEntities();


        public List<PatientViewModel> GetPatientList(int id = 0)
        {

            List<PatientViewModel> HospitalList = new List<PatientViewModel>();
            List<ReadPatient_Result> patient_Results = db.ReadPatient(id).ToList();
            foreach (var item in patient_Results)
            {
                PatientViewModel svm = new PatientViewModel();
                svm = BindHospitalData(item);
                HospitalList.Add(svm);
            }
            return HospitalList;
        }
        public PatientViewModel GetPatientByID(int id = 0)
        {

            ReadPatient_Result patient_Results = db.ReadPatient(id).FirstOrDefault();

            PatientViewModel svm = new PatientViewModel();
            svm = BindHospitalData(patient_Results);

            return svm;
        }
        public PatientViewModel Delete(int id)
        {
            ReadPatient_Result patient_Result = db.ReadPatient(id).FirstOrDefault();
            PatientViewModel svm = new PatientViewModel();
            svm = BindHospitalData(patient_Result);

            return svm;
        }
        private PatientViewModel BindHospitalData(ReadPatient_Result readPatient)
        {

            PatientViewModel hvm = new PatientViewModel();
            hvm.PatientID = (int)readPatient.PatientID;
            hvm.PatientName = readPatient.PatientName;
            hvm.DOB = readPatient.DOB;
            hvm.Gender = readPatient.Gender;
            hvm.Email = readPatient.Email;
            hvm.Age = readPatient.Age;
            hvm.Contact = readPatient.Contact;
            hvm.Address = readPatient.Address;
            hvm.IsActive = readPatient.IsActive;

            return hvm;
        }

        public HandleException Insert(PatientViewModel patientViewModel)
        {
            HandleException handleException = new HandleException();
            try
            {
                var result = db.CreatePatient(patientViewModel.PatientID,
                                              patientViewModel.PatientName,
                                              patientViewModel.DOB,
                                              patientViewModel.Gender,
                                              patientViewModel.Email,
                                              patientViewModel.Age,
                                              patientViewModel.Contact,
                                              patientViewModel.Address,
                                              patientViewModel.IsActive
                                              );

                if (result != null)
                {
                    handleException.IsSuccess = true;
                    handleException.Message = "Successful";
                }
                else
                {
                    handleException.IsSuccess = false;
                    handleException.Message = "Error while Inserting Data";
                }

            }
            catch (Exception ex)
            {
                handleException.Message = ex.Message;
            }
            return handleException;
        }
        public PatientViewModel Details(int id)
        {
            var pvm = new PatientViewModel();
            ReadPatient_Result readPatientBy = db.ReadPatient(id).FirstOrDefault();
            pvm = BindHospitalData(readPatientBy);
            return pvm;
        }
      
        public HandleException Update(PatientViewModel patientViewModel)
        {
            HandleException handleException = new HandleException();
            try
            {
                var u = db.UpdatePatient(patientViewModel.PatientID,
                                         patientViewModel.PatientName,
                                         patientViewModel.DOB,
                                         patientViewModel.Gender,
                                         patientViewModel.Email,
                                         patientViewModel.Age,
                                         patientViewModel.Contact,
                                         patientViewModel.Address);
                if (u != null)
                {
                    handleException.IsSuccess = true;
                    handleException.Message = "Successful";
                }
                else
                {
                    handleException.IsSuccess = false;
                    handleException.Message = "Error while Updating Data";
                }
            }
            catch (Exception ex)
            {
                handleException.Message = ex.Message;
            }
            return handleException;
        }

        public HandleException Delete(PatientViewModel patientView)
        {
            HandleException handleException = new HandleException();
            try
            {
                var s = db.DeletePatient(patientView.PatientID);

                if(s!= null)
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