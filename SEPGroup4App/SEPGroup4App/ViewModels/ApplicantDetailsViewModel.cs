using SEPGroup4App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SEPGroup4App.ViewModels
{
    public class ApplicantDetailsViewModel
    {
        // Related application Id
        public int? ApplicationId { get; set; }

        [Display(Name="First Name")]
        [RegularExpression(@"[A-Za-z]+", ErrorMessage="Names must only contain letters.")]
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [RegularExpression(@"[A-Za-z]+", ErrorMessage="Names must only contain letters.")]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "School/Unit")]
        [Required]
        public string SchoolUnit { get; set; }
        [Required]
        public string Supervisor { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\({0,1}((0|\+61)(2|4|3|7|8)){0,1}\){0,1}(\ |-){0,1}[0-9]{2}(\ |-){0,1}[0-9]{2}(\ |-){0,1}[0-9]{1}(\ |-){0,1}[0-9]{3}$", ErrorMessage="Please enter a valid Australian phone number.")]
        [Phone]
        [Required]
        public string PhoneNumber { get; set; }
        [Display(Name = "Applicant Type")]
        
        [Required]
        public ApplicantType? ApplicantType { get; set; }
        [Display(Name = "Is this your first application this year?")]
        [Required]
        public bool FirstApplicationThisYear { get; set; }
    }
}