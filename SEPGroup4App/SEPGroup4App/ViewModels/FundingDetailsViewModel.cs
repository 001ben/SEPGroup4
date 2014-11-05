using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SEPGroup4App.Models;

namespace SEPGroup4App.ViewModels
{
    public class FundingDetailsViewModel
    {
        // Related application Id
        public int? ApplicationId { get; set; }


        //Research information
        [Display(Name="Is this a research fund?")]
        [Required]
        public bool? ResearchGrant { get; set;}
        [Display(Name="Are you a research Student?")]
        [Required]
        public bool? ResearchStudent { get; set;}
        [Display(Name="Research Strength")]
        [DataType(DataType.MultilineText)]
        public string ResearchStrength { get; set;}
        [Display(Name="Is there Travel support for the research strength?")]
        public bool? StrengthSupport { get; set;}
        [Display(Name="Stage")]
        [Required]
        public Stage? Stage { get; set;}
        [Display(Name = "Does your supervisor have a grant?")]
        [Required]
        public bool? SupervisorGrant { get; set;}
        [Display(Name="Have you applied to VC Conference fund?")]
        [Required]
        public bool? AppliedtoVCFund { get; set;}
        [Display(Name = "Amount granted from VC conference fund")]
        public decimal? VCFundGrantAmount { get; set; }

        //Funding information
        [Display(Name = "Air Fare Costs")]
        [Required]
        public decimal? Airfare { get; set; }
        [Display(Name = "Accomodation Costs")]
        [Required]
        public decimal? Accomodation { get; set; }
        [Display(Name = "Conference Fees")]
        [Required]
        public decimal? ConferenceFees { get; set; }
        [Display(Name = "Meals costs")]
        [Required]
        public decimal? Meals { get; set; }
        [Display(Name = "Local Fares")]
        [Required]
        public decimal? LocalFares { get; set; }
        [Display(Name = "Car Mileage")]
        [Required]
        public decimal? CarMileage { get; set; }
        [Display(Name = "Other Costs")]
        [Required]
        public decimal? Other { get; set; }
        [Display(Name = "Total Expenses")]
        public decimal? TotalExpenses { get; set; }
    }
}