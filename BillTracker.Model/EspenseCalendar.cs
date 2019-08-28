
using BillTracker.Domain.shared;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillTracker.Domain
{
    [Table("EspenseCalendars")]
    public class EspenseCalendar : Entity<int>
    {
        [Required]
        public decimal Amount { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? DayOfWeekIncome { get; set; }

        [Required]
        public bool State { get; set; }

        [Required]
        public int ExpenseCategoryId { get; set; }

        [ForeignKey("ExpenseCategoryId")]
        public virtual ExpenseCategory ExpenseCategory { get; set; }

    }

}
