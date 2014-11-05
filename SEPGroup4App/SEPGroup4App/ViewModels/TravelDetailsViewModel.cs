﻿using SEPGroup4App.Models;
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
        [Required]
        public PaperType? PaperType { get; set; }
        [Display(Name = "Travel Departure Date")]
        [Required]
        public DateTime? DepartureDate { get; set; }
        [Display(Name = "Travel Return Date")]
        [Required]
        public DateTime? ReturnDate { get; set; }
        
        [DataType(DataType.MultilineText)]
        [Required]
        [Display(Name = "Justification For Travel")]
        public string JustificationForTravel { get; set; }
        [Display(Name = "PEP Arrangements?")]
        [Required]
        public bool PEPArrangements { get; set; }
        [Display(Name = "PEP Start Date")]
        public DateTime? PEPStartDate { get; set; }
        [Display(Name = "PEP End Date")]
        public DateTime? PEPEndDate { get; set; }

        // Conference Information
        [DataType(DataType.MultilineText)]
        [Display(Name="Conference Name and Details")]
        [Required]
        public string ConferenceNameDetails { get; set; }
        [Display(Name = "Conference URL")]
        public string ConferenceURL { get; set; }
        [Display(Name = "Conference Start Date")]
        [Required]
        public DateTime? ConferenceStartDate { get; set; }
        [Display(Name = "Conference End Date")]
        [Required]
        public DateTime? ConferenceEndDate { get; set; }
        [Display(Name = "Conference Country")]
        [Required]
        public string Country { get; set; }
        [Display(Name = "Conference Region")]
        [Required]
        public string Region { get; set; }
        [Display(Name = "Conference City")]
        [Required]
        public string City { get; set; }
        [Display(Name = "Conference Quality")]
        [Required]
        public ConferenceQuality? Quality { get; set; }
        [Display(Name = "Conference Special Duties")]
        public SpecialDuties? SpecialDuties { get; set; }

        // Paper Information
        [Display(Name = "Title of Paper")]
        [Required]
        public string PaperTitle { get; set; }
        [Display(Name = "Paper Accepted")]
        [Required]
        public bool PaperAccepted { get; set; }
        [Display(Name = "Attached Documents")]
        
        public AttachedDocuments? AttachedDocuments { get; set; }
        [Display(Name = "HERDC Points Awarded?")]
        [Required]
        public bool HERDCPoints { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Importance and Quality of Publication")]
        [Required]
        public string PublicationImportanceAndQuality { get; set; }
    }
}