﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SEPGroup4App.ViewModels
{
    public class UserCreateViewModel
    {

        [Display(Name = "UTS ID")]
        public string StaffStudentID { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        
    }
}