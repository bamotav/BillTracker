using BillTracker.Domain.shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillTracker.Domain
{
    [Table("Bills")]
    public class Bill : Entity<long>
    {
        [Required]
        public string BillNumber { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public decimal Itbis { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        [Required]
        public DateTime BillDate { get; set; }

        [Required]
        public virtual ICollection<BillItems> BillItems { get; set; }
    }

    [Table("BillItems")]
    public class BillItems : Entity<long>
    {
        public string Description { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public decimal Itbis { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }
    }

}
