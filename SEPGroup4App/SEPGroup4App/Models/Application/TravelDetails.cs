using SEPGroup4App.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SEPGroup4App.Models
{
    public enum PaperType
    {
        [Display(Name="Conference Paper")]
        ConferencePaper, 
        [Display(Name="Journal Paper")]
        JournalPaper
    }

    public enum ConferenceQuality
    {
        A, B, Other
    }

    public enum SpecialDuties
    {
        [Display(Name="Special invitation to conference received")]
        SpecialInvitation, 
        [Display(Name="Will perform special duties above just presenting the paper")]
        AboveJustPresenting
    }

    // http://stackoverflow.com/questions/1030090/how-do-you-pass-multiple-enum-values-in-c
    [Flags]
    public enum AttachedDocuments
    {
        [Display(Name="Conference Email")]
        ConferenceEmail = 1,
        [Display(Name = "Peer Reviews")]
        PeerReviews = 2,
        [Display(Name = "Paper Copy")]
        PaperCopy = 4
    }

    public class TravelDetails
    {
        //Properties

        //ID
        [Required]
        [Key, ForeignKey("Application"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ApplicationId { get; set; }

        public virtual Application Application { get; set; }

        #region Departure Info
        //Holds basic travel details
        public PaperType? PaperType { get; set; }
        public DateTime? DepartureDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string JustificationForTravel { get; set; }
        #endregion

        #region PEPArrangements
        //Holds all the relevant information about PEP Arrangement
        public bool PEPArrangements { get; set; }
        public DateTime? PEPStartDate { get; set; }
        public DateTime? PEPEndDate { get; set; }
        #endregion

        #region Conference Details
        //Holds all the details about the conference.
        public string ConferenceNameDetails { get; set; }
        public string ConferenceURL { get; set; }
        public DateTime? ConferenceStartDate { get; set; }
        public DateTime? ConferenceEndDate { get; set; }

        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public ConferenceQuality? Quality { get; set; }
        public SpecialDuties? SpecialDuties { get; set; }
        #endregion

        #region Paper Information
        //Holds all the information regarding the paper.
        public string PaperTitle { get; set; }
        public bool PaperAccepted { get; set; }
        public AttachedDocuments? AttachedDocuments { get; set; }
        public bool HERDCPoints { get; set; }
        public string PublicationImportanceAndQuality { get; set; }
        #endregion
    }
}