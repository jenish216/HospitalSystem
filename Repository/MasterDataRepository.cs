using HospitalSystem.Models;
using HospitalSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalSystem.Repository
{
    public class MasterDataRepository : IMasterDataRepository
    {
        private readonly HospitalManagementEntities db = new HospitalManagementEntities();
        HandleException handleException = new HandleException();
        public List<MasterDataViewModel> GetList(int id = 0)
        {
            List<MasterDataViewModel> Masterlist = new List<MasterDataViewModel>();
            List<ReadMasterData_Result> getMasterData_Results = db.ReadMasterData(id).ToList();
            // List<ReadMasterCode_Result> readMasterCode_Result = db.ReadMasterCode().ToList();
            foreach (var item in getMasterData_Results)
            {
                MasterDataViewModel msc = new MasterDataViewModel();
                msc = BindMasterdata(item);
                Masterlist.Add(msc);
            }
            return Masterlist;
        }
        public List<MasterDataViewModel> GetMasterDataByCode(int id=0)
        {
            List<MasterDataViewModel> masterDataViewModels = new List<MasterDataViewModel>();
            //List<MasterData> master = db.MasterDatas.ToList();
            List<GetMasterDataById_Result> master = db.GetMasterDataById(id).ToList();
            foreach (var item in master)
            {
                MasterDataViewModel mvm = new MasterDataViewModel();
                mvm = BindMasterDatabyCode(item);
                masterDataViewModels.Add(mvm);
            }
            return masterDataViewModels;
        }
        public List<MasterDataViewModel> GetMasterData(int id)
        {
            List<MasterDataViewModel> masterDataViewModels = new List<MasterDataViewModel>();
            
            List<GetMasterData_Result> master = db.GetMasterData(id).ToList();
            foreach (var item in master)
            {
                MasterDataViewModel mvm = new MasterDataViewModel();
                mvm = BindMasterDataby(item);
                masterDataViewModels.Add(mvm);
            }
            return masterDataViewModels;
        }

        private MasterDataViewModel BindMasterDataby(GetMasterData_Result item)
        {
            MasterDataViewModel mvm = new MasterDataViewModel();
            mvm.ID = item.ID;
            mvm.MasterCodeName = item.MasterCodeName;
      
            return mvm;
        }

        private MasterDataViewModel BindMasterDatabyCode(GetMasterDataById_Result masterData)
        {
            MasterDataViewModel mvm = new MasterDataViewModel();
            mvm.ID = masterData.ID;
            mvm.DisplayText = masterData.DisplayText;
            mvm.MasterCodeID = (int)masterData.MasterCodeId;
            return mvm;
        }
        private MasterDataViewModel BindMasterdata(ReadMasterData_Result readMasterData_Result)
        {
            MasterDataViewModel msc = new MasterDataViewModel();
            msc.ID = readMasterData_Result.ID;
            msc.DisplayText = readMasterData_Result.DisplayText;
            msc.MasterCodeID = (int)readMasterData_Result.MasterCodeId;
            msc.MasterCodeText = readMasterData_Result.MasterCodeText;
            msc.IsActive = readMasterData_Result.IsActive;
            //msc.IsActive = readMasterData_Result.

            return msc;
        }
        public HandleException Insert(MasterDataViewModel MasterDataViewModel)
        {
            try
            {
                var result = db.CreateMasterData(MasterDataViewModel.ID, MasterDataViewModel.DisplayText, MasterDataViewModel.MasterCodeID, MasterDataViewModel.IsActive);

                if (result != null)
                {
                    handleException.IsSuccess = true;
                    handleException.Message = "Successful";
                }
                else
                {
                    handleException.IsSuccess = false;
                    handleException.Message = "Error";
                }
                handleException.IsSuccess = true;
                handleException.Message = "Successful";
            }
            catch (Exception ex)
            {
                handleException.Message = ex.Message;
            }
            return handleException;
        }
        public MasterDataViewModel Edit(int id)
        {
            ReadMasterData_Result masterData = db.ReadMasterData(id).FirstOrDefault();

            MasterDataViewModel pvm = new MasterDataViewModel();
            pvm = BindMasterdata(masterData);
            return pvm;
        }
        public HandleException Edit(MasterDataViewModel MasterDataViewModel)
        {
            try
            {
                var result = db.UpdateMasterData(MasterDataViewModel.ID, MasterDataViewModel.DisplayText, MasterDataViewModel.MasterCodeID);

                if (result != null)
                {
                    handleException.IsSuccess = true;
                    handleException.Message = "Successful";
                }
                else
                {
                    handleException.IsSuccess = false;
                    handleException.Message = "Error";
                }
                handleException.IsSuccess = true;
                handleException.Message = "Successful";
            }
            catch (Exception ex)
            {
                handleException.Message = ex.Message;
            }
            return handleException;
        }


        public HandleException Delete(MasterDataViewModel MasterDataViewModel)
        {
            try
            {
                var result = db.DeleteMasterData(MasterDataViewModel.ID);

                if (result != null)
                {
                    handleException.IsSuccess = true;
                    handleException.Message = "Successful";
                }
                else
                {
                    handleException.IsSuccess = false;
                    handleException.Message = "Error";
                }
                handleException.IsSuccess = true;
                handleException.Message = "Successful";
            }
            catch (Exception ex)
            {
                handleException.Message = ex.Message;
            }
            return handleException;
        }
        public MasterDataViewModel Delete(int id = 0)
        {
            ReadMasterData_Result masterData = db.ReadMasterData(id).FirstOrDefault();

            MasterDataViewModel pvm = new MasterDataViewModel();
            pvm = BindMasterdata(masterData);
            return pvm;
        }
        public MasterDataViewModel Details(int id)
        {
            var rmc = new MasterDataViewModel();
            ReadMasterData_Result readMasterData_Result = db.ReadMasterData(id).FirstOrDefault();
            rmc = BindMasterdata(readMasterData_Result);
            return rmc;
        }
    }
}