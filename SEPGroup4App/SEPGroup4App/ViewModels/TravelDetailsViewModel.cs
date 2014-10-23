using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SEPGroup4App.ViewModels
{
    public enum PaperType 
    {
        ConferencePaper, JournalPaper
    }

    public enum ConferenceQuality
    {
        A, B, Other
    }

    public enum SpecialDuties
    {
        SpecialInvitation, AboveJustPresenting
    }

    // http://stackoverflow.com/questions/1030090/how-do-you-pass-multiple-enum-values-in-c
    [Flags]
    public enum AttachedDocuments
    {
        ConferenceEmail = 1, 
        PeerReviews = 2, 
        PaperCopy = 4
    }

    public class TravelDetailsViewModel
    {
        // Travel Information
        [Display(Name="Paper Type")]
        public PaperType? PaperType { get; set; }
        public DateTime? DepartureDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        
        [DataType(DataType.MultilineText)]
        public string JustificationForTravel { get; set; }

        public bool? PEPArrangements { get; set; }
        public DateTime? PEPStartDate { get; set; }
        public DateTime? PEPEndDate { get; set; }

        // Conference Information
        [DataType(DataType.MultilineText)]
        public string ConferenceNameDetails { get; set; }
        public string ConferenceURL { get; set; }
        public DateTime? ConferenceStartDate { get; set; }
        public DateTime? ConferenceEndDate { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public ConferenceQuality? Quality { get; set; }
        public SpecialDuties? SpecialDuties { get; set; }

        // Paper Information
        public string PaperTitle { get; set; }
        public bool? PaperAccepted { get; set; }
        public AttachedDocuments? AttachedDocuments { get; set; }
        public bool? HERDCPoints { get; set; }

        [DataType(DataType.MultilineText)]
        public string PublicationImportanceAndQuality { get; set; }
    }
}