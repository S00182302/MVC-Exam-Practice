namespace MVCbhenning.Migrations.MVCContext
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MVCbhenning.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Business.DomainClasses.bhenning;
    using Business.DomainClasses.bhenning.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCbhenning.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\MVCContext";
        }

        protected override void Seed(MVCbhenning.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var manager =
                new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(context));

            var roleManager =
                new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));

            SetUserRoles(context);
            SeedCustomerUsers(context, manager);
        }

        private void SetUserRoles(ApplicationDbContext context)
        {
            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "Bank Manager" }
                );
            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "Data Clerk" }
                );
            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "Customer" }
                );
            context.SaveChanges();
        }

        private void SeedCustomerUsers(ApplicationDbContext context, UserManager<ApplicationUser> manager)
        {
            PasswordHasher ps = new PasswordHasher();

            using (ClassContext modelContext = new ClassContext())
            {
                var customers = modelContext.Customers.Select(c => c).ToList();

                foreach (Customer customer in customers)
                {
                    context.Users.AddOrUpdate(u => u.UserName,
                        new ApplicationUser
                        {
                            UserName = "customer" + customer.ID + "@email.com",
                            Email = "customer" + customer.ID + "@email.com",
                            EmailConfirmed = true,
                            SecurityStamp = Guid.NewGuid().ToString(),
                            PasswordHash = ps.HashPassword("Pass$1")
                        }
                    );

                    context.SaveChanges();

                    ApplicationUser customerUser = manager.FindByEmail("customer" + customer.ID + "@email.com");
                    if (customerUser != null)
                    {
                        manager.AddToRoles(customerUser.Id, new string[] { "Customer" });
                    }
                    context.SaveChanges();
                }
            }
        }

        private void SeedBankManager(ApplicationDbContext context, UserManager<ApplicationUser> manager)
        {
            PasswordHasher ps = new PasswordHasher();

            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "bank.manager@bob.com",
                    Email = "bank.manager@bob.com",
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    PasswordHash = ps.HashPassword("TheBoss$1")
                });
            context.SaveChanges();

            ApplicationUser admin = manager.FindByEmail("bank.manager@bob.com");
            if (admin != null)
            {
                manager.AddToRoles(admin.Id, new string[] { "Bank Manager" });
            }
            context.SaveChanges();
        }

    }
}
