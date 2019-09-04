using BillTracker.Infraestructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BillTracker.Web.Core.Filters
{
    public class ResultFilter : IResultFilter
    {
        private readonly IServiceProvider _serviceProvider;

        public void OnResultExecuted(ResultExecutedContext context)
        {
            //No Action
        }

        public ResultFilter(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var objectResult = context.Result as ObjectResult;

            if (!(objectResult.Value is AjaxResponseBase))
            {
                objectResult.Value = new AjaxResponse(objectResult.Value);
                if (!objectResult.Formatters.Any(f => f is JsonOutputFormatter))
                {
                    objectResult.Formatters.Add(
                        new JsonOutputFormatter(
                            _serviceProvider.GetRequiredService<IOptions<MvcJsonOptions>>().Value.SerializerSettings,
                            _serviceProvider.GetRequiredService<ArrayPool<char>>()
                        )
                    );
                }
            }

        }
    }
}
