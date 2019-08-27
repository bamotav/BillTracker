using BillTracker.Model.shared;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillTracker.Model
{
    [Table("AccountsBanks")]
    public class AccountBank : Entity<int>
    {
        
        public string NameAccount { get; set; }

        [Required]
        public string NumberAccount { get; set; }

        [Column(TypeName = "nvarchar(50)")]
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
