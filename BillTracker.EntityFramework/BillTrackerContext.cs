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


    }
}
