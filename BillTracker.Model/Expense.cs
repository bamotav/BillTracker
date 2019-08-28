using BillTracker.Domain.shared;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillTracker.Domain
{
    [Table("Expenses")]
    public class Expense : Entity<int>
    {
        [Required]
        public decimal Amount { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime ExpenseCreateDate { get; set; }

       
        public long? BillId { get; set; }

        [ForeignKey("BillId")]
        public virtual Bill Bill { get; set; }
    }

    [Table("ExpenseCategories")]
    public class ExpenseCategory : Entity<int>
    {
        [Required]
        public string Name { get; set; }
    }

}
