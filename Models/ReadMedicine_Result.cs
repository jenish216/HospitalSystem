//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HospitalSystem.Models
{
    using System;
    
    public partial class ReadMedicine_Result
    {
        public int MedicineID { get; set; }
        public string MedicineName { get; set; }
        public string Code { get; set; }
        public string Brand { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> Priceperunit { get; set; }
        public Nullable<int> UnitStock { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}