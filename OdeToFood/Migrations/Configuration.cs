namespace OdeToFood.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<OdeToFood.Models.OdeToFoodDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "OdeToFood.Models.OdeToFoodDb";
        }

        protected override void Seed(OdeToFood.Models.OdeToFoodDb context)
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

            context.Restaurants.AddOrUpdate(r => r.Name,
                new Restaurant { Name = "Sabatino's", City = "Baltimore", Country = "USA" },
                new Restaurant { Name = "Great Lakes", City = "Chicago", Country = "United States of America" },
                new Restaurant
                {
                    Name = "Smaka",
                    City = "Gothenberg",
                    Country = "The Sweedish Republic",
                    Reviews =
                    new List<RestaurantReview>
                    {
                        new RestaurantReview {Rating = 9, Body = "Great Food, and Waitresses!!", ReviewerName = "Milinda" }
                    }
                });

            for (int i = 0; i < 1000; i++)
            {
                context.Restaurants.AddOrUpdate(r => r.Name,
                            new Restaurant { Name = i.ToString(), City = "Nowhere", Country = "USA" });
            }

            //SeedMembership();

            //context.Reviews.AddOrUpdate(r => r.Id,
            //                            new RestaurantReview
            //                            {
            //                                Rating = 9,
            //                                Body = "Great Food, and Waitresses!!",
            //                                ReviewerName = "Milinda"
            //                            });
        }

        private void SeedMembership()
        {
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfiles", "UserId", "UseraName", autoCreateTables: true);

            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("Admin"))
            {
                roles.CreateRole("Admin");
            }
            if (membership.GetUser("milinda", false) == null)
            {
                membership.CreateUserAndAccount("milinda", "!Qaz12345");
            }
            if (!roles.GetRolesForUser("milinda").Contains("Admin"))
            {
                roles.AddUsersToRoles(new[] { "milinda" }, new[] { "Admin" });
            }
        }
    }
}
