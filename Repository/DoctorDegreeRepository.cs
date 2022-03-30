using HospitalSystem.ViewModels;
using HospitalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalSystem.Repository
{
    public class DoctorDegreeRepository: IDoctorDegree
    {
        private readonly HospitalManagementEntities db = new HospitalManagementEntities();
        public List<DoctorDegreeViewModel> GetDoctorDegree(int id = 0)
        {
            List<DoctorDegreeViewModel> DegreeList = new List<DoctorDegreeViewModel>();
            List<ReadDoctorDegree_Result> readDoctorDegrees = db.ReadDoctorDegree(id).ToList();
            foreach(var item in readDoctorDegrees)
            {
                DoctorDegreeViewModel doctorDegreeView = new DoctorDegreeViewModel();
                doctorDegreeView = BindDegreeData(item);
                DegreeList.Add(doctorDegreeView);
            }
            return DegreeList;
        }

        private DoctorDegreeViewModel BindDegreeData(ReadDoctorDegree_Result item)
        {
            DoctorDegreeViewModel doctorDegree = new DoctorDegreeViewModel();
            doctorDegree.DegreeID = item.DegreeID;
            doctorDegree.DegreeName = item.DegreeName;

            return doctorDegree;
        }
       

    }
}