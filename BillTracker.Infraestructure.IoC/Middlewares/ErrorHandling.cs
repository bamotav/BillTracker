using BillTracker.Infraestructure;
using BillTracker.Infraestructure.Logging;
using BillTracker.Infraestructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BillTracker.Web.Core.Middlewares
{
    public class ErrorHandling
    {
        private readonly RequestDelegate next;
        protected readonly ILogger _log = ApplicationLogging.CreateLogger<ErrorHandling>();

        public ErrorHandling(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {   
                await next(context);
            }
            catch (Exception exceptionObj)
            {
                await HandleExceptionAsync(context, exceptionObj);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string result = null;

            context.Response.ContentType = "application/json";

            if (exception is BillTrackerException)
            {
                var httpException = exception as BillTrackerException;

                var httpStatusCode = (HttpStatusCode)httpException.HttpCode;

                context.Response.StatusCode = httpException.HttpCode;
                var responseResult = new AjaxResponse(new ErrorInfo(httpException.Message), httpStatusCode == HttpStatusCode.Unauthorized || httpStatusCode == HttpStatusCode.Forbidden);
                responseResult.Error.Code = httpException.Code;

                result = responseResult.ToString();

                _log.LogWarning($"BillTrackerException - {exception.ToString()} - {result}");
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var responseResult = new AjaxResponse(new ErrorInfo(exception.Message), false);

                result = responseResult.ToString();

                _log.LogError($"BillTrackerException - Error {exception.ToString()} - {result}");
            }

            return context.Response.WriteAsync(result);
        }
    }


}
