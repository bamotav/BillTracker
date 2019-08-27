using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BillTracker.Model
{
    public abstract class BaseModel
    {
        [Key]
        public virtual int Id { get; set; }
    }
}
