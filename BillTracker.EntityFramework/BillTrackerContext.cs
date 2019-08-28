using BillTracker.Domain;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Linq;

namespace BillTracker.EntityFramework
{
    public class BillTrackerContext : DbContext
    {
        public BillTrackerContext(DbContextOptions<BillTrackerContext> options) : base(options)
        {
        }

        protected BillTrackerContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // equivalent of modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                entityType.Relational().TableName = entityType.DisplayName();

                // equivalent of modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                // and modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }


            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Income> Incomes { get; set; }

        public virtual DbSet<IncomeCalendar> IncomeCalendars { get; set; }

        public virtual DbSet<Expense> Expenses { get; set; }

        public virtual DbSet<EspenseCalendar> EspenseCalendars { get; set; }

        public virtual DbSet<ExpenseCategory> ExpenseCategories { get; set; }

        public virtual DbSet<AccountBank> AccountsBanks { get; set; }

        public virtual DbSet<Bill> Bills { get; set; }

        public virtual DbSet<BillItems> BillItems { get; set; }

    }
}
