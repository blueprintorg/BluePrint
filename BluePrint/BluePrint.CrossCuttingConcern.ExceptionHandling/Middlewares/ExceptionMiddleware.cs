using BluePrint.Common.Rest;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace BluePrint.CrossCuttingConcern.ExceptionHandling.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await this.next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string message = "Internal Server Error";
            if (e.GetType() == typeof(ValidationException))
            {
                message = e.Message;
            }
            var result = new ServiceResult<Task>(message.ToString(), httpContext.Response.StatusCode);

            return httpContext.Response.WriteAsync(JsonSerializer.Serialize(result));

        }
    }
}

