using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEPGroup4App.Models
{
    public class Applicant : User
    {
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string SchoolUnit { get; set; }
        public string Supervisor { get; set; }
        public string Phone { get; set; }

    }
}