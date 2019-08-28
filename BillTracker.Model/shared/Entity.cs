using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BillTracker.Domain.shared
{
    public interface IEntity<out TId> where TId : IEquatable<TId>
    {
        TId Id { get; }
    }

    public class Entity<TId> : IEntity<TId> where TId : IEquatable<TId>
    {
        [Key]
        public virtual TId Id { get; set; }

        [Required]
        public DateTime DateCreate{ get; set; }

        public DateTime? DateModification { get; set; }


    }

}
