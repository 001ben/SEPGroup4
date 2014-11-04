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
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "School/Unit")]
        public string SchoolUnit { get; set; }
        public string Supervisor { get; set; }
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Applicant Type")]
        public ApplicantType? ApplicantType { get; set; }
        [Display(Name = "Is this your first application this year?")]
        public bool FirstApplicationThisYear { get; set; }
    }
}