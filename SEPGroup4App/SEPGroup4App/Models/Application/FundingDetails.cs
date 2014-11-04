using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SEPGroup4App.Models
{
    public enum Stage
    {
        Stage1, Stage2, Stage3
    }

    public class FundingDetails
    {
        [Required]
        [Key, ForeignKey("Application"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ApplicationId { get; set; }

        public bool? ResearchGrant { get; set; }
        public bool? ResearchStudent { get; set; }     
        public string ResearchStrength { get; set; }      
        public bool? StrengthSupport { get; set; }
        public Stage? Stage { get; set; }
        public bool? SupervisorGrant { get; set; }
        public bool? AppliedtoVCFund { get; set; }
        public decimal? VCFundGrantAmount { get; set; }
        public decimal? Airfare { get; set; }        
        public decimal? Accomodation { get; set; }        
        public decimal? ConferenceFees { get; set; }       
        public decimal? Meals { get; set; }       
        public decimal? LocalFares { get; set; }        
        public decimal? CarMileage { get; set; }
        public decimal? Other { get; set; }        
        public decimal? TotalExpenses { get; set; }

        public virtual Application Application { get; set; }
    }
}