using BudgetPlannerMVC.Domain.Model;
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
                .HasData(new Domain.Model.Type { Id = 1, AssignId = 1, Name = "General Expenses" });
            builder.Entity<Domain.Model.Type>()
                .HasData(new Domain.Model.Type { Id = 2, AssignId = 2, Name = "General Incomes" });


            //builder.Entity<Amount>()
            //    .HasOne(a => a.Type).WithMany(t => t.Amounts)
            //    .HasForeignKey(at => at.TypeId);
            //builder.Entity<Domain.Model.Type>()
            //    .HasOne(ta => ta.Assign).WithMany(tp => tp.Types)
            //    .HasForeignKey(ai => ai.AssignId);
        }
    }
}
