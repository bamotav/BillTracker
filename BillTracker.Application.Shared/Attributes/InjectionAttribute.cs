using System;
using System.Collections.Generic;
using System.Text;

namespace BillTracker.Application.Shared.Attributes
{
    
    public class InjectionSingletonAttribute : Attribute
    {
        public InjectionSingletonAttribute()
        {
        }
    }

    public class InjectionTransientLifetimeAttribute : Attribute
    {
        public InjectionTransientLifetimeAttribute()
        {
        }
    }

    public class InjectionScopedLifetimeAttribute : Attribute
    {
        public InjectionScopedLifetimeAttribute()
        {
        }
    }
}
