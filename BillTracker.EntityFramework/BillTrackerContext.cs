using BillTracker.Model;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;


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
