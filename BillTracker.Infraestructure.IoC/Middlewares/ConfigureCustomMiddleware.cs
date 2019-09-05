using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillTracker.Web.Core.Middlewares
{
    public static class ConfigureCustomMiddleware
    {
        public static void ConfigureErrorHandling(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandling>();
        }
    }
}
