using SEPGroup4App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using SEPGroup4App.ViewModels;
using System.Threading.Tasks;

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

        public ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().Get<ApplicationUserManager>();
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

        [HttpPost]
        public async Task<ActionResult> Create(UserCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Applicant applicant = new Applicant
                {
                    StaffStudentID = model.StaffStudentID,
                    UserName = model.UserName,
                    FirstName = model.FirstName,
                    Surname = model.Surname,
                    Email = model.Email,
                    SchoolUnit = model.SchoolUnit,
                    Supervisor = model.Supervisor,
                    Phone = model.Phone
                };

                UserData.Applicants.Add(applicant);
                await UserData.SaveChangesAsync();

                await UserManager.CreateAsync(new ApplicationUser
                    {
                        UserName = model.StaffStudentID
                    }, model.Password);

                return RedirectToAction("Index", "Administration");
            }

            return View(model);
        }
    }
}