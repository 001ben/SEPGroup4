using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SEPGroup4App.ViewModels
{
    public class UserCreateViewModel
    {

        [Display(Name = "UTS ID")]
        [Required]
        public string StaffStudentID { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string Surname { get; set; }
        [Display(Name = "School Unit")]
        public string SchoolUnit { get; set; }
        public string Supervisor { get; set; }
        public string Phone { get; set; }
    }
}