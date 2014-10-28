using SEPGroup4App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SEPGroup4App.Controllers
{
    public class ApplicationController : Controller
    {
        // GET: Application
        public ActionResult Index()
        {
            return RedirectToAction("ApplicantDetails");
        }

        public ActionResult ApplicantDetails()
        {
            // Get data from database

            ApplicantDetailsViewModel model = new ApplicantDetailsViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult ApplicantDetails(ApplicantDetailsViewModel model)
        {
            return RedirectToAction("TravelDetails");
        }

        public ActionResult TravelDetails()
        {
            TravelDetailsViewModel model = new TravelDetailsViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult TravelDetails(TravelDetailsViewModel model)
        {
            return RedirectToAction("FundingDetails");
        }

        public ActionResult FundingDetails()
        {
            // Get data from database

            FundingDetailsViewModel model = new FundingDetailsViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult FundingDetails(FundingDetailsViewModel model)
        {
            return View(model);
        }
    }
}