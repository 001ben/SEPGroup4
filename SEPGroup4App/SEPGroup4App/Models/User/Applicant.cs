using SEPGroup4App.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEPGroup4App.Models.User
{
    public class Applicant : User
    {
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string SchoolUnit { get; set; }
        public string Supervisor { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

    }
}