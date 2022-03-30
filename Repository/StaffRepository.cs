using HospitalSystem.Models;
using HospitalSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalSystem.Repository
{
    public class StaffRepository: IStaffRepository
    {
        private readonly HospitalManagementEntities db = new HospitalManagementEntities();
        HandleException handleException = new HandleException();
        public List<StaffViewModel> GetStaffList(int id = 0)
        {
            List<StaffViewModel> StaffList = new List<StaffViewModel>();
            List<ReadStaff_Result> readStaffs = db.ReadStaff(id,true).ToList();
            foreach(var item in readStaffs)
            {
                StaffViewModel staffViewModel = new StaffViewModel();
                staffViewModel = BindStaffData(item);
                StaffList.Add(staffViewModel);
            }
            return StaffList;
        }

        private StaffViewModel BindStaffData(ReadStaff_Result item)
        {
            StaffViewModel staffView = new StaffViewModel();
            try
            {
                staffView.StaffID = item.StaffID;
                staffView.Name = item.Name;
                staffView.IsActive = item.IsActive;
            }
            catch (Exception ex)
            {
                handleException.Message = ex.Message;
            }
            return staffView;
        }

    }
}