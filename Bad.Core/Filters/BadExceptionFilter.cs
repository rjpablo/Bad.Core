using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net;

namespace Bad.Core.Filters
{
    public class BadExceptionFilter : Attribute, IExceptionFilter
    {
        private readonly ILogger<BadExceptionFilter> _logger;

        public BadExceptionFilter(ILogger<BadExceptionFilter> logger)
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            var exceptionType = context.Exception.GetType();

            if (exceptionType == typeof(UnauthorizedAccessException))
            {
                status = HttpStatusCode.Unauthorized;
            }
            else if (exceptionType == typeof(NotImplementedException))
            {
                status = HttpStatusCode.NotImplemented;
            }
            else if (exceptionType == typeof(KeyNotFoundException))
            {
                status = HttpStatusCode.NotFound;
            }
            else
            {
                status = HttpStatusCode.InternalServerError;
            }

            _logger.LogError(context.Exception, "Unhandled exception encountered.");
            var result = new JsonResult(
                new { message = "An unexpected error occurred" },
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
            result.StatusCode = (int)status;
            context.Result = result;
            context.ExceptionHandled = true;
        }
    }
}
