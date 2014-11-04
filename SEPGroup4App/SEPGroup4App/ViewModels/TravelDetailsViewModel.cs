using SEPGroup4App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SEPGroup4App.ViewModels
{
 
    public class TravelDetailsViewModel
    {
        // Related application Id
        public int? ApplicationId { get; set; }

        // Travel Information
        [Display(Name="Paper Type")]
        public PaperType? PaperType { get; set; }
        [Display(Name = "Travel Departure Date")]
        public DateTime? DepartureDate { get; set; }
        [Display(Name = "Travel Return Date")]
        public DateTime? ReturnDate { get; set; }
        
        [DataType(DataType.MultilineText)]
        [Display(Name = "Justification For Travel")]
        public string JustificationForTravel { get; set; }
        [Display(Name = "PEP Arrangements?")]
        public bool PEPArrangements { get; set; }
        [Display(Name = "PEP Start Date")]
        public DateTime? PEPStartDate { get; set; }
        [Display(Name = "PEP End Date")]
        public DateTime? PEPEndDate { get; set; }

        // Conference Information
        [DataType(DataType.MultilineText)]
        [Display(Name="Conference Name and Details")]
        public string ConferenceNameDetails { get; set; }
        [Display(Name = "Conference URL")]
        public string ConferenceURL { get; set; }
        [Display(Name = "Conference Start Date")]
        public DateTime? ConferenceStartDate { get; set; }
        [Display(Name = "Conference End Date")]
        public DateTime? ConferenceEndDate { get; set; }
        [Display(Name = "Conference Country")]
        public string Country { get; set; }
        [Display(Name = "Conference Region")]
        public string Region { get; set; }
        [Display(Name = "Conference City")]
        public string City { get; set; }
        [Display(Name = "Conference Quality")]        
        public ConferenceQuality? Quality { get; set; }
        [Display(Name = "Conference Special Duties")]        
        public SpecialDuties? SpecialDuties { get; set; }

        // Paper Information
        [Display(Name = "Title of Paper")]
        public string PaperTitle { get; set; }
        [Display(Name = "Paper Accepted")]
        public bool PaperAccepted { get; set; }
        [Display(Name = "Attached Documents")]
        public AttachedDocuments? AttachedDocuments { get; set; }
        [Display(Name = "HERDC Points Awarded?")]
        public bool HERDCPoints { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Importance and Quality of Publication")]
        public string PublicationImportanceAndQuality { get; set; }
    }
}