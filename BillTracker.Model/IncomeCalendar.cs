using BillTracker.Model.shared;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillTracker.Model
{
    [Table("IncomeCalendars")]
    public class IncomeCalendar : Entity<int>
    {
        [Required]
        public decimal Amount { get; set; }

        public string Description { get; set; }

        public int? AccountBankId { get; set; }

        [ForeignKey("AccountBankId")]
        public virtual AccountBank AccountBank { get; set; }

        [Column(TypeName = "TEXT")]
        [Required]
        public IncomeType IncomeType { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? DayOfWeekIncome { get; set; }

        [Required]
        public bool State { get; set; }

    }


    public enum IncomeType
    {
        [Description("Quincenal")]
        Biweekly = 15,
        [Description("Mensual")]
        Month = 30,
    }



}
