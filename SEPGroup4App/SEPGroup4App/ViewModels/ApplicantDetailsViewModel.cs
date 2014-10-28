using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SEPGroup4App.ViewModels
{
    public enum ApplicantType {
        ResearchStudent = 0, Staff = 1
    }

    public class ApplicantDetailsViewModel
    {
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
        [Display(Name = "Application Type")]
        public ApplicantType? ApplicantType { get; set; }
        [Display(Name = "Is this your first application this year?")]
        public bool? FirstApplicationThisYear { get; set; }
    }
}