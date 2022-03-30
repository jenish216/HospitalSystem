using HospitalSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace HospitalSystem.ViewModels
{
    public class FileCaseViewModel
    {
        public List<MasterDataViewModel> Diseasetype { get; set; }
        public List<MasterDataViewModel> StatusNames { get; set; }
        public List<MasterDataViewModel> relative_names { get; set; }
        public List<PatientViewModel> patientnames { get; set; }
        public List<RoomViewModel> Roomtypes { get; set; }
        public List<FileCaseViewModel> FileCases { get; set;}
        public int CaseID { get; set; }
        public Nullable<int> PatientID { get; set; }
        public string PatientNames { get; set; }
        public string Contact { get; set; }
        public string AlternateNumber { get; set; }
        public Nullable<int> DiseaseID { get; set; }
        public string DiseaseName { get; set; }
        public string Relative_Name { get; set; }
        public string RelativeName { get; set; }
        public Nullable<int> Relative_Relation { get; set; }
        public Nullable<int> RoomID { get; set; }
        public string RoomType { get; set; }
        public string Symptoms { get; set; }
        public Nullable<int> Status { get; set; }
        public string StatusName { get; set; }
        public Nullable<bool> IsActive { get; set; }

    }
}