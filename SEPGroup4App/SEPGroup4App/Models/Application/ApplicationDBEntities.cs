using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SEPGroup4App.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace SEPGroup4App.Models
{
    public class ApplicationDBEntities : DbContext
    {
        public ApplicationDBEntities()
            :base("ApplicationDBEntities")
        {}

        public static ApplicationDBEntities Create()
        {
            return new ApplicationDBEntities();
        }

        public virtual DbSet<ApplicantDetails> ApplicantDetails { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<FundingDetails> FundingDetails { get; set; }
        public virtual DbSet<TravelDetails> TravelDetails { get; set; }
    }

}