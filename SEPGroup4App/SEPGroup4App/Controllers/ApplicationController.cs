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
            return View();
        }

        public ActionResult ApplicantDetails()
        {
            // Get data from database

            ApplicantDetailsViewModel model = new ApplicantDetailsViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Section1(ApplicantDetailsViewModel model)
        {
            return RedirectToAction("Section2");
        }

        public ActionResult FundingDetails()
        {
            FundingDetailsViewModel model = new FundingDetailsViewModel();
            return View(model);
        }
    }
}