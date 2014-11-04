namespace SEPGroup4App.UserMigrations
{
    using SEPGroup4App.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SEPGroup4App.Models.UserDBEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"UserMigrations";
        }

        protected override void Seed(UserDBEntities context)
        {
            context.SystemAdmins.AddOrUpdate(
                s => s.StaffStudentID,
                new SystemAdmin()
                {
                    StaffStudentID = "000000",
                    UserName = "Magician",
                    Email = "magic.rules@uts.edu.au"
                }

                );
            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
