using HospitalSystem.Models;
using HospitalSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HospitalSystem.Repository
{
    public class FileCaseRepository : IFileRepository
    {
        private readonly HospitalManagementEntities db = new HospitalManagementEntities();
        HandleException handleException = new HandleException();

        public List<FileCaseViewModel> GetFileList(int id = 0)
        {
            List<FileCaseViewModel> HospitalList = new List<FileCaseViewModel>();
            List<ReadFileCase_Result> files = db.ReadFileCase(id).ToList();
            foreach (var item in files)
            {
                FileCaseViewModel svm = new FileCaseViewModel();
                svm = BindHospitalData(item);
                HospitalList.Add(svm);
            }
            return HospitalList;
        }

        private FileCaseViewModel BindHospitalData(ReadFileCase_Result readFileCase)
        {

            FileCaseViewModel hvm = new FileCaseViewModel();
        

                hvm.CaseID = readFileCase.CaseID;
                hvm.RoomID = (int)readFileCase.RoomID;
                hvm.RoomType = readFileCase.RoomType;
                hvm.PatientID = (int)readFileCase.PatientID;
                hvm.PatientNames = readFileCase.PatientNames;
                hvm.Contact = readFileCase.Contact;
                hvm.AlternateNumber = readFileCase.AlternateNumber;
                hvm.DiseaseID = (int)readFileCase.DiseaseID;
                hvm.DiseaseName = readFileCase.DiseaseName;
                hvm.Relative_Name = readFileCase.Relative_Name;
                hvm.Relative_Relation = (int)readFileCase.Relative_Relation; 
                hvm.RelativeName = readFileCase.RelativeName;
                hvm.Symptoms = readFileCase.Symptoms;
                hvm.Status = (int)readFileCase.Status;
                hvm.StatusName = readFileCase.StatusName;
                hvm.IsActive = readFileCase.IsActive;
            
        
            return hvm;
        }


        public HandleException Insert(FileCaseViewModel fileCaseViewModel)
        {
            HandleException handleException = new HandleException();
            try
            {
                var result = db.CreateFileCase(fileCaseViewModel.CaseID,
                                               fileCaseViewModel.PatientID,                                            
                                               fileCaseViewModel.Contact,
                                               fileCaseViewModel.AlternateNumber,
                                               fileCaseViewModel.DiseaseID,
                                               fileCaseViewModel.RelativeName,
                                               fileCaseViewModel.Relative_Relation,
                                               fileCaseViewModel.RoomID,
                                               fileCaseViewModel.Symptoms,
                                               fileCaseViewModel.Status,
                                               fileCaseViewModel.IsActive);

                if (result != null)
                {
                    handleException.IsSuccess = true;
                    handleException.Message = "Successful";
                }
                else
                {
                    handleException.IsSuccess = true;
                    handleException.Message = "Error while inserting Case";
                }
            }
            catch (Exception ex)
            {
                handleException.Message = ex.Message;
            }
            return handleException;
        }
        public FileCaseViewModel GetFileCaseByID(int id)
        {
            ReadFileCase_Result fileCase_Result = db.ReadFileCase(id).FirstOrDefault();
            FileCaseViewModel fileCaseView = new FileCaseViewModel();
            fileCaseView = BindHospitalData(fileCase_Result);

            return fileCaseView;
        }
        public HandleException Edit(FileCaseViewModel fileCaseViewModel)
        {
            HandleException handleException = new HandleException();
            try
            {
                var result = db.UpdateFileCase(fileCaseViewModel.CaseID,
                                               fileCaseViewModel.PatientID,
                                               fileCaseViewModel.Contact,
                                               fileCaseViewModel.AlternateNumber,
                                               fileCaseViewModel.DiseaseID,
                                               fileCaseViewModel.RelativeName,
                                               fileCaseViewModel.Relative_Relation,
                                               fileCaseViewModel.RoomID,
                                               fileCaseViewModel.Symptoms,
                                               fileCaseViewModel.Status);

                if (result != null)
                {
                    handleException.IsSuccess = true;
                    handleException.Message = "Successful";
                }
                else
                {
                    handleException.IsSuccess = true;
                    handleException.Message = "Error while inserting Case";
                }
            }
            catch (Exception ex)
            {
                handleException.Message = ex.Message;
            }
            return handleException;
        }
        public FileCaseViewModel Details(int id)
        {
            var fvm = new FileCaseViewModel();
            ReadFileCase_Result readFile = db.ReadFileCase(id).FirstOrDefault();
            fvm = BindHospitalData(readFile);
            return fvm;
        }
        public FileCaseViewModel Delete(int id=0)
        {
            ReadFileCase_Result readFileCase = db.ReadFileCase(id).FirstOrDefault();
            FileCaseViewModel fileCaseView = new FileCaseViewModel();
            fileCaseView = BindHospitalData(readFileCase);

            return fileCaseView;
        }
        public HandleException Delete(FileCaseViewModel fileCaseView)
        {
            HandleException handleException = new HandleException();
            try
            {
                var a = db.DeleteFileCase(fileCaseView.CaseID);

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