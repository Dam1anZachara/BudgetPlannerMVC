﻿using BudgetPlannerMVC.Domain.Model;
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
        public DbSet<Amount> Amounts { get; set; }
        public DbSet<Assign> Assigns { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<ContactDetailType> ContactDetailTypes { get; set; }
        public DbSet<Domain.Model.Type> Types { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppUserPersonalData> AppUserPersonalData { get; set; }

        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
                .HasOne(a => a.AppUserPersonalData).WithOne(b => b.AppUser)
                .HasForeignKey<AppUserPersonalData>(p => p.UserRef);
        }
    }
}