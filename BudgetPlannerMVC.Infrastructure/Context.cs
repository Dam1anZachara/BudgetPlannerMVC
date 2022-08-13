using BudgetPlannerMVC.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlannerMVC.Infrastructure
{
    public class Context : IdentityDbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Amount> Amounts { get; set; }
        public DbSet<Assign> Assigns { get; set; }
        public DbSet<BudgetUser> BudgetUsers { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<ContactDetailType> ContactDetailTypes { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<PlanType> PlanTypes { get; set; }
        public DbSet<Domain.Model.Type> Types { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Default Data

            builder.Entity<Assign>()
                .HasData(new Assign { Id = 1, Name = "Expense" } , new Assign { Id = 2, Name = "Income"});

            builder.Entity<Domain.Model.Type>()
                .HasData(
                new Domain.Model.Type { Id = 1, AssignId = 1, Name = "General Expenses" },
                new Domain.Model.Type { Id = 2, AssignId = 2, Name = "General Incomes" }
                );

            builder.Entity<BudgetUser>()
                .HasData(new BudgetUser { Id = 1, FirstName = "Not assigned", ProfileCreated = true });

            builder.Entity<ContactDetailType>()
                .HasData(
                new ContactDetailType { Id = 1, Name = "Mail" },
                new ContactDetailType { Id = 2, Name = "Phone Number" }
                );

            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole { Id = "Admin", Name = "Admin", NormalizedName = "ADMIN"},
                new IdentityRole { Id = "User", Name = "User", NormalizedName = "USER"},
                new IdentityRole { Id = "PreUser", Name = "PreUser", NormalizedName = "PREUSER"},
                new IdentityRole { Id = "Banned", Name = "Banned", NormalizedName = "BANNED"}
                );
        }
    }
}
