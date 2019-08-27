using BillTracker.Model.shared;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillTracker.Model
{
    [Table("Incomes")]
    public class Income : Entity<int>
    {
        [Required]
        public decimal Amount { get; set; }

        public string Description { get; set; }

        public int? AccountBankId { get; set; }

        [ForeignKey("AccountBankId")]
        public virtual AccountBank AccountBank { get; set; }

        [Required]
        public DateTime IncomeCreateDate { get; set; }
    }


  
}
