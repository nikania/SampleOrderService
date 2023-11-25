using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SampleOrderService.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SampleOrderService.Middleware
{
    internal sealed class ExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) => _logger = logger;

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                await HandleExceptionAsync(context, e);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";

            int status_code;

            if (exception is BadRequestException)
            {
                status_code = StatusCodes.Status400BadRequest;
            }
            else if(exception is NotFoundException)
            {
                status_code = StatusCodes.Status404NotFound;
            }
            else
            {
                status_code = StatusCodes.Status500InternalServerError;
            }
            
            httpContext.Response.StatusCode = status_code;

            var response = new
            {
                error = exception.Message
            };

            await httpContext.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
