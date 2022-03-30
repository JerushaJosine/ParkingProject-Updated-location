namespace authpark.Migrations
{
    using System;
    using authpark.Models;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;

    internal sealed class Configuration : DbMigrationsConfiguration<authpark.Models.ApplicationDbContext>
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(authpark.Models.ApplicationDbContext context)
        {
        //    var roles = new List<IdentityRole>
        //{
        //    new IdentityRole{     Name= "Admin",},
        //    new IdentityRole{     Name= "User",},
        //    new IdentityRole{     Name= "Police",},

        //};

        //    roles.ForEach(s => context.Roles.Add(s));
        //    context.SaveChanges();
        //    var User = new List<ApplicationUser>
        //{
        //    new ApplicationUser {  Email = "admin@admin.com",
        //        UserName = "admin",PasswordHash="admin"},
            
        //};
        //    User.ForEach(s => context.Users.Add(s));
        //    context.SaveChanges();

        //    string id = (from i in db.Users.First().ToString() select i).ToString();
        //    string role = (from r in db.Roles.First().ToString() select r).ToString();

        //    var urole = new List<IdentityUserRole>
        //{
        //    new IdentityUserRole {  UserId = id,
        //        RoleId = role,},

        //};
        //    urole.ForEach(s => context.UserRoles.Add(s));
        //    context.SaveChanges();

        }
    }
}
