using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SEPGroup4App.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace SEPGroup4App.Models
{
    public class ApplicationDBEntities : DbContext
    {
        public ApplicationDBEntities()
            :base("ApplicationDBEntities")
        {

        }

        public virtual DbSet<ApplicantDetails> ApplicantDetails { get; set; }
        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<FundingDetails> FundingDetails { get; set; }
        public virtual DbSet<TravelDetails> TravelDetails { get; set; }
    }

}