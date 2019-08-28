using BillTracker.Domain.shared;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillTracker.Domain
{
    [Table("AccountsBanks")]
    public class AccountBank : Entity<int>
    {
        
        public string NameAccount { get; set; }

        [Required]
        public string NumberAccount { get; set; }

        [Column(TypeName = "TEXT")]
        [Required]
        public Bank Bank { get; set; }
    }


    public enum Bank
    {
        [Description("Banco BHDLeon")]
        BhdLeon,
        [Description("Banco Popular")]
        Popular,
        [Description("Banco BanReservas")]
        BanReservas
    }
}
