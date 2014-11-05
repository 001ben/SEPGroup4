using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SEPGroup4App.ViewModels
{
    public class UserCreateViewModel
    {
        [RegularExpression(@"\d{1,10}", ErrorMessage="ID has to only contain numbers and be less than 10 characters.")]
        [Display(Name = "UTS ID")]
        [Required]
        public string StaffStudentID { get; set; }
        [Display(Name = "User Name")]
        [Required]
        public string UserName { get; set; }
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [RegularExpression(@"[A-Za-z]+", ErrorMessage = "Names must only contain letters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [RegularExpression(@"[A-Za-z]+", ErrorMessage = "Names must only contain letters.")]
        public string Surname { get; set; }
        [Display(Name = "School Unit")]
        public string SchoolUnit { get; set; }
        public string Supervisor { get; set; }

        [Phone]
        [RegularExpression(@"^\({0,1}((0|\+61)(2|4|3|7|8)){0,1}\){0,1}(\ |-){0,1}[0-9]{2}(\ |-){0,1}[0-9]{2}(\ |-){0,1}[0-9]{1}(\ |-){0,1}[0-9]{3}$", ErrorMessage = "Please enter a valid Australian phone number.")]
        public string Phone { get; set; }
    }
}