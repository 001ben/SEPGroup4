using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SEPGroup4App.Models.User
{
    public abstract class User
    {
        [Key]
        public int UserID { get; set; }
        public string StaffStudentID { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

    }
}