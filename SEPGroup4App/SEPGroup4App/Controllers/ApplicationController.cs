using SEPGroup4App.ViewModels;
using System;
using SEPGroup4App.FileManager;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using SEPGroup4App.Models;
using System.Data.Entity.Validation;
using SEPGroup4App.Helpers;

namespace SEPGroup4App.Controllers
{
    public class ApplicationController : Controller
    {
        public ApplicationDBEntities ApplicationData
        {
            get
            {
                return HttpContext.GetOwinContext().Get<ApplicationDBEntities>();
            }
        }

        // GET: Application
        public ActionResult Index()
        {
            // Create new application
            Application app = new Application()
            {
            };

            // Add to context
            ApplicationData.Applications.Add(app);

            // Save changes to save it to the database
            ApplicationData.SaveChanges();

            // Navigate to the Applicant Details screen to begin entering data for the application
            return RedirectToAction("ApplicantDetails", new { applicationId = app.ApplicationId });
        }

        public ActionResult Submitted()
        {
            return View();
        }

        /// <summary>
        /// Show ApplicantDetails form with data from database
        /// </summary>
        /// <param name="applicationId">Related application id to view applicant details for</param>
        /// <returns>ApplicantDetails view</returns>
        public ActionResult ApplicantDetails(int? applicationId)
        {
            Application application = GetApplication(applicationId, "applicant details");

            // Decide whether required to create applicant details or get current details
            if (application.ApplicantDetails == null)
            {
                // Create a new applicant details section for the application
                application.ApplicantDetails = new ApplicantDetails()
                {
                    // Prefill applicant details with current user details
                };

                // Create a new application
                ApplicationData.Entry(application).State = System.Data.Entity.EntityState.Modified;
                ApplicationData.SaveChanges();
            }

            // Get values for view model from the applicant details section in database
            ApplicantDetailsViewModel model = new ApplicantDetailsViewModel()
            {
                ApplicantType = application.ApplicantDetails.ApplicantType,
                ApplicationId = application.ApplicantDetails.ApplicationId,
                Email = application.ApplicantDetails.Email,
                FirstApplicationThisYear = application.ApplicantDetails.FirstApplicationThisYear,
                FirstName = application.ApplicantDetails.FirstName,
                LastName = application.ApplicantDetails.LastName,
                PhoneNumber = application.ApplicantDetails.PhoneNumber,
                SchoolUnit = application.ApplicantDetails.SchoolUnit,
                Supervisor = application.ApplicantDetails.Supervisor
            };

            return View(model);
        }

        /// <summary>
        /// Update the applicant details section in the database if view model is valid
        /// </summary>
        /// <param name="model">Model class for the applicant details view model</param>
        /// <returns>The applicant details view, or redirects to travel details if successful</returns>
        [HttpPost]
        public ActionResult ApplicantDetails(ApplicantDetailsViewModel model)
        {
            // Only add to database if the model is valid (otherwise show form again with the validation errors
            if (ModelState.IsValid)
            {
                try
                {
                    // Get the applicant details section from the database
                    ApplicantDetails applicantDetails = ApplicationData
                        .ApplicantDetails
                        .Where(a => a.ApplicationId == model.ApplicationId)
                        .FirstOrDefault();

                    // Update the applicant details section
                    applicantDetails.Email = model.Email;
                    applicantDetails.FirstApplicationThisYear = model.FirstApplicationThisYear;
                    applicantDetails.FirstName = model.FirstName;
                    applicantDetails.LastName = model.LastName;
                    applicantDetails.PhoneNumber = model.PhoneNumber;
                    applicantDetails.SchoolUnit = model.SchoolUnit;
                    applicantDetails.Supervisor = model.Supervisor;

                    // Update Application Data
                    ApplicationData.Entry(applicantDetails).State = System.Data.Entity.EntityState.Modified;
                    ApplicationData.SaveChanges();

                    // Redirect to the Travel Details section
                    return RedirectToAction("TravelDetails", new { applicationId = applicantDetails.ApplicationId });
                }
                catch(DbEntityValidationException e)
                {
                    foreach(var error in e.EntityValidationErrors.SelectMany(ev => ev.ValidationErrors))
                    {
                        ModelState.AddModelError("", error.ErrorMessage);
                    }
                }
                catch(Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }

            // Return this view with errors
            return View(model);
        }

        /// <summary>
        /// Show the Travel Details view with data from the database
        /// </summary>
        /// <param name="applicationId">Related application Id to view travel details for</param>
        /// <returns>TravelDetails view</returns>
        public ActionResult TravelDetails(int? applicationId)
        {
            // Retrieve the application from the database
            Application application = GetApplication(applicationId, "travel details");

            // Decide whether required to create applicant details or get current details
            if (application.TravelDetails == null)
            {
                // Create new travel details section
                application.TravelDetails = new TravelDetails();

                // Create the travel details section in the database
                ApplicationData.Entry(application).State = System.Data.Entity.EntityState.Modified;
                ApplicationData.SaveChanges();
            }

            // Create the view model with database data
            TravelDetailsViewModel model = new TravelDetailsViewModel()
            {
                ApplicationId = application.ApplicationId,
                AttachedDocuments = application.TravelDetails.AttachedDocuments,
                City = application.TravelDetails.City,
                ConferenceEndDate = application.TravelDetails.ConferenceEndDate,
                ConferenceNameDetails = application.TravelDetails.ConferenceNameDetails,
                ConferenceStartDate = application.TravelDetails.ConferenceStartDate,
                ConferenceURL = application.TravelDetails.ConferenceURL,
                Country = application.TravelDetails.Country,
                DepartureDate = application.TravelDetails.DepartureDate,
                HERDCPoints = application.TravelDetails.HERDCPoints,
                JustificationForTravel = application.TravelDetails.JustificationForTravel,
                PaperAccepted = application.TravelDetails.PaperAccepted,
                PaperTitle = application.TravelDetails.PaperTitle,
                PaperType = application.TravelDetails.PaperType,
                PEPArrangements = application.TravelDetails.PEPArrangements,
                PEPEndDate = application.TravelDetails.PEPEndDate,
                PEPStartDate = application.TravelDetails.PEPStartDate,
                PublicationImportanceAndQuality = application.TravelDetails.PublicationImportanceAndQuality,
                SpecialDuties = application.TravelDetails.SpecialDuties,
                Quality = application.TravelDetails.Quality,
                Region = application.TravelDetails.Region,
                ReturnDate = application.TravelDetails.ReturnDate,
            };

            // Return view with model
            return View(model);
        }

        /// <summary>
        /// Update the travel details section in the database if view model is valid
        /// </summary>
        /// <param name="model">Travel Details View model containing the submitted information</param>
        /// <returns>Redirects to the funding details action</returns>
        [HttpPost]
        public ActionResult TravelDetails(TravelDetailsViewModel model, AttachedDocuments[] AttachedDocuments)
        {
            // Check that the model is valid and return the view with the validation errors if not
            if (ModelState.IsValid)
            {
                // Get the travel details section from the database
                TravelDetails travelDetails = ApplicationData
                    .TravelDetails
                    .Where(a => a.ApplicationId == model.ApplicationId)
                    .FirstOrDefault();

                // Update the travel details section
                travelDetails.AttachedDocuments = AttachedDocuments != null ? AttachedDocuments.Aggregate((a,b) => a | b) : default(AttachedDocuments?);
                travelDetails.City = model.City;
                travelDetails.ConferenceEndDate = model.ConferenceEndDate;
                travelDetails.ConferenceNameDetails = model.ConferenceNameDetails;
                travelDetails.ConferenceStartDate = model.ConferenceStartDate;
                travelDetails.ConferenceURL = model.ConferenceURL;
                travelDetails.Country = model.Country;
                travelDetails.DepartureDate = model.DepartureDate;
                travelDetails.HERDCPoints = model.HERDCPoints;
                travelDetails.JustificationForTravel = model.JustificationForTravel;
                travelDetails.PaperAccepted = model.PaperAccepted;
                travelDetails.PaperTitle = model.PaperTitle;
                travelDetails.PaperType = model.PaperType;
                travelDetails.PEPArrangements = model.PEPArrangements;
                travelDetails.PEPEndDate = model.PEPEndDate;
                travelDetails.PEPStartDate = model.PEPStartDate;
                travelDetails.PublicationImportanceAndQuality = model.PublicationImportanceAndQuality;
                travelDetails.SpecialDuties = model.SpecialDuties;
                travelDetails.Quality = model.Quality;
                travelDetails.Region = model.Region;
                travelDetails.ReturnDate = model.ReturnDate;

                // Update travel details section in database
                ApplicationData.Entry(travelDetails).State = System.Data.Entity.EntityState.Modified;
                ApplicationData.SaveChanges();

                FileManagerClient fileClient = new FileManagerClient();
                string result = fileClient.UploadFiles(new ApplicationFileCollection {
                    Files = GetFiles().ToArray(),
                    ApplicationId = travelDetails.ApplicationId
                });

                return RedirectToAction("FundingDetails", new { applicationId = travelDetails.ApplicationId });
            }

            // Return view with errors
            return View(model);
        }

        private IEnumerable<ApplicationFile> GetFiles()
        {
            foreach(string inputName in Request.Files)
            {
                var f = Request.Files.Get(inputName);
                byte[] data = new byte[f.ContentLength];
                f.InputStream.Read(data, 0, f.ContentLength);

                yield return new ApplicationFile()
                {
                    Data = data,
                    FileName = f.FileName,
                    MimeType = f.ContentType
                };
            }
        }

        /// <summary>
        /// Show the Funding Details view with data from the database
        /// </summary>
        /// Related application Id to view travel details for
        /// <returns>FundingDetails view</returns>
        public ActionResult FundingDetails(int? applicationId)
        {
            // Get data from database
            // Retrieve the application from the database
            Application application = GetApplication(applicationId, "funding details");

            // Decide whether required to create applicant details or get current details
            if (application.FundingDetails == null)
            {
                // Create new travel details section
                application.FundingDetails = new FundingDetails();

                // Create the travel details section in the database
                ApplicationData.Entry(application).State = System.Data.Entity.EntityState.Modified;
                ApplicationData.SaveChanges();
            }

            // Copy funding details from database to view model
            FundingDetailsViewModel model = new FundingDetailsViewModel()
            {
                ApplicationId = application.ApplicationId,
                Accomodation = application.FundingDetails.Accomodation,
                Airfare = application.FundingDetails.Airfare,
                AppliedtoVCFund = application.FundingDetails.AppliedtoVCFund,
                CarMileage = application.FundingDetails.CarMileage,
                ConferenceFees = application.FundingDetails.ConferenceFees,
                LocalFares = application.FundingDetails.LocalFares,
                Meals = application.FundingDetails.Meals,
                Other = application.FundingDetails.Other,
                ResearchGrant = application.FundingDetails.ResearchGrant,
                ResearchStrength = application.FundingDetails.ResearchStrength,
                ResearchStudent = application.FundingDetails.ResearchStudent,
                Stage = application.FundingDetails.Stage,
                StrengthSupport = application.FundingDetails.StrengthSupport,
                SupervisorGrant = application.FundingDetails.SupervisorGrant,
                TotalExpenses = application.FundingDetails.TotalExpenses,
                VCFundGrantAmount = application.FundingDetails.VCFundGrantAmount,
            };

            // Return the funding details view
            return View(model);
        }

        /// <summary>
        /// Update the travel details section in the database if view model is valid
        /// </summary>
        /// <param name="model">Funding Details View model containing the submitted information</param>
        /// <returns>A redirect to the application submission confirmation page</returns>
        [HttpPost]
        public ActionResult FundingDetails(FundingDetailsViewModel model)
        {
            if(ModelState.IsValid)
            {
                // Get the funding details section from the database
                FundingDetails fundingDetails = ApplicationData
                    .FundingDetails
                    .Where(a => a.ApplicationId == model.ApplicationId)
                    .FirstOrDefault();

                // Update the funding details section
                fundingDetails.Accomodation = model.Accomodation;
                fundingDetails.Airfare = model.Airfare;
                fundingDetails.AppliedtoVCFund = model.AppliedtoVCFund;
                fundingDetails.CarMileage = model.CarMileage;
                fundingDetails.ConferenceFees = model.ConferenceFees;
                fundingDetails.LocalFares = model.LocalFares;
                fundingDetails.Meals = model.Meals;
                fundingDetails.Other = model.Other;
                fundingDetails.ResearchGrant = model.ResearchGrant;
                fundingDetails.ResearchStrength = model.ResearchStrength;
                fundingDetails.ResearchStudent = model.ResearchStudent;
                fundingDetails.Stage = model.Stage;
                fundingDetails.StrengthSupport = model.StrengthSupport;
                fundingDetails.SupervisorGrant = model.SupervisorGrant;
                fundingDetails.TotalExpenses = model.TotalExpenses;
                fundingDetails.VCFundGrantAmount = model.VCFundGrantAmount;

                // Update funding details section in database
                ApplicationData.Entry(fundingDetails).State = System.Data.Entity.EntityState.Modified;
                ApplicationData.SaveChanges();

                // Redirect to FundingDetails view until logic is added for application submission
                return RedirectToAction("Submitted");
            }

            // Show Funding Details view with errors
            return View(model);
        }


        #region Non action methods

        public bool IsDebug
        {
            get { 
                #if(DEBUG)
                    return true;
                #else
                    return false;
                #endif
            }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            if(!IsDebug) 
            {
                string message = filterContext.Exception is ShowMessageException ? filterContext.Exception.Message : null;

                filterContext.ExceptionHandled = true;

                filterContext.Result = RedirectToAction("ApplicationError", new { message = message });
            }

            base.OnException(filterContext);
        }

        [AllowAnonymous]
        public ActionResult ApplicationError(string message)
        {
            return View(message);
        }

        private Application GetApplication(int? id, string detailType)
        {
            // Get the application being edited
            var application = ApplicationData.Applications.Find(id);

            // If no application found, return error
            if (application == null)
            {
                throw new ShowMessageException("Error: can't access {0} without an applicationId", detailType);
            }
            else
            {
                return application;
            }
        }
        #endregion
    }
}