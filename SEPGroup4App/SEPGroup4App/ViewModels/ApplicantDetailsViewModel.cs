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
        [Required]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
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
        [Phone]
        [Required]
        public string PhoneNumber { get; set; }
        [Display(Name = "Applicant Type")]
        [Required]
        public ApplicantType? ApplicantType { get; set; }
        [Display(Name = "Is this your first application this year?")]
        public bool FirstApplicationThisYear { get; set; }
    }
}