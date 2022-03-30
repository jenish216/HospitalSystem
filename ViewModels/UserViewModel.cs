using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HospitalSystem.ViewModels
{
    public class UserViewModel
    {
        public List<UserViewModel> Users { get; set; }
        public int UserID { get; set; }
        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Enter EmailId")]
        public string EmailAddress { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}