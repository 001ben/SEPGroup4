using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SEPGroup4App.Models
{
    public class UserDBEntities : DbContext
    {
        public UserDBEntities()
            :base("UserDBEntities")
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<SystemAdmin> SystemAdmins { get; set; }

    }
}