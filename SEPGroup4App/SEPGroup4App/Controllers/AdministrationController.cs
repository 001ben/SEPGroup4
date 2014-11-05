using SEPGroup4App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using SEPGroup4App.Models;
using SEPGroup4App.ViewModels;

namespace SEPGroup4App.Controllers
{
    public class AdministrationController : Controller
    {
        public UserDBEntities UserData
        {
            get
            {
                return HttpContext.GetOwinContext().Get<UserDBEntities>();
            }
        }
        // GET: Administration
        public ActionResult Index()
        {
            //Create new user
            IEnumerable<UserListViewModel> model
                = UserData.Users.Select(u => new UserListViewModel
                {
                    Email = u.Email,
                    StaffStudentID = u.StaffStudentID,
                    UserID = u.UserID,
                    UserName = u is Applicant ? 
                    (u as Applicant).FirstName + " " + (u as Applicant).Surname : 
                    u.UserName
                });

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}