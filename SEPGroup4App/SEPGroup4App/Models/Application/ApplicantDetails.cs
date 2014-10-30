using SEPGroup4App.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SEPGroup4App.Models
{
    public class ApplicantDetails
    {
        [Key, ForeignKey("Application"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ApplicationId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SchoolUnit { get; set; }
        public string Supervisor { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ApplicantType? ApplicantType { get; set; }
        public bool? FirstApplicationThisYear { get; set; }

        [Required]
        public virtual Application Application { get; set; }
    }
}