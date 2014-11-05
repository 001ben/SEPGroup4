namespace SEPGroup4App.AuthMigrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using SEPGroup4App.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SEPGroup4App.Models.AuthenticationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"AuthMigrations";
        }

        protected override void Seed(SEPGroup4App.Models.AuthenticationDbContext context)
        {
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

            var appUserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(new AuthenticationDbContext()));

            var password = "Pass@word1";
            var passwordHash = appUserManager.PasswordHasher.HashPassword(password);

            var appUser = new ApplicationUser
            {
                UserName = "000000",
                PasswordHash = passwordHash
            };

            context.Users.AddOrUpdate(
                u => u.UserName,
                appUser);

            var result = appUserManager.UpdateSecurityStampAsync(appUser.Id);
            result.Wait();
        }
    }
}
