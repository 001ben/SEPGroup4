using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SEPGroup4App.Models
{
    public class Application
    {
        [Key]
        public int ApplicationId { get; set; }
        public bool Submitted { get; set; }

        public DateTime? SubmittedOn { get; set; }
        public string StaffStudentId { get; set; }

        public virtual ApplicantDetails ApplicantDetails { get; set; }
        public virtual TravelDetails TravelDetails { get; set; }
        public virtual FundingDetails FundingDetails { get; set; }
    }
}