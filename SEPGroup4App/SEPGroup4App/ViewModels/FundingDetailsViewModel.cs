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
        //Research information
        [Display(Name="Is this a research fund?")]
        public bool? ResearchGrant { get; set;}
        [Display(Name="Are you a research Student?")]
        public bool? ResearchStudent { get; set;}
        [Display(Name="Research Strength:")]
        [DataType(DataType.MultilineText)]
        public string ResearchStrength { get; set;}
        [Display(Name="Is there support for the research strength?")]
        public bool? StrengthSupport { get; set;}
        [Display(Name="Stage:")]
        public Stage? Stage { get; set;}
        [Display(Name = "Does your supervisor have a grant?")]
        public bool? SupervisorGrant { get; set;}
        [Display(Name="Have you applied to VC Conference fund?")]
        public bool? AppliedtoVCFund { get; set;}
        [Display(Name = "Amount granted from VC conference fund")]
        public decimal? VCFundGrantAmount { get; set; }

        //Funding information
        [Display(Name = "Air Fare Costs")]
        public decimal? Airfare { get; set; }
        [Display(Name = "Accomodation Costs")]
        public decimal? Accomodation { get; set; }
        [Display(Name = "Conference Fees")]
        public decimal? ConferenceFees { get; set; }
        [Display(Name = "Meals costs")]
        public decimal? Meals { get; set; }
        [Display(Name = "Local Fares")]
        public decimal? LocalFares { get; set; }
        [Display(Name = "Car Mileage")]
        public decimal? CarMileage { get; set; }
        [Display(Name = "Other Costs")]
        public decimal? Other { get; set; }
        [Display(Name = "Total Expenses")]
        public decimal? TotalExpenses { get; set; }
    }
}