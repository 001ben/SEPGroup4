using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SEPGroup4App.ViewModels
{
    public enum Stage
    {
        Stage1,Stage2,Stage3
    }
    public class FundingDetailsViewModel
    {
        //Research information
        [Display(Name="Is this a research fund?")]
        public bool? ResearchGrant { get; set;}
        [Display(Name="Are you a research Student?")]
        public bool? ResearchStudent { get; set;}
        [Display(Name="Research Strength:")]
        public string ResearchStrength { get; set;}
        [Display(Name="Support for strength?")]
        [DataType(DataType.MultilineText)]
        public bool? StrengthSupport { get; set;}
        [Display(Name="Stage:")]
        public Stage? Stage { get; set;}
        [Display(Name = "Does your supervisor have a grant?")]
        public bool? SupervisorGrant { get; set;}
        [Display(Name="Have you applied to VC Conference fund?")]
        public bool? AppliedtoVCFund { get; set;}

        //Funding information
        [Display(Name = "Air Fare Costs")]
        public double? Airfare { get; set; }
        [Display(Name = "Accomodation Costs")]
        public double? Accomodation { get; set; }
        [Display(Name = "Conference Fees")]
        public double? ConferenceFees { get; set; }
        [Display(Name = "Meals costs")]
        public double? Meals { get; set; }
        [Display(Name = "Local Fares")]
        public double? LocalFares { get; set; }
        [Display(Name = "Car Mileage")]
        public double? CarMileage { get; set; }
        [Display(Name = "Other Costs")]
        public double? Other { get; set; }
        [Display(Name = "Total Expenses")]
        public double? TotalExpenses { get; set; }
    }
}