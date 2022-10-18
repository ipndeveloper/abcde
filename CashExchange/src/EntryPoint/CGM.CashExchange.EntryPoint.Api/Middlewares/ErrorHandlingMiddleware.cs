using CGM.CashExchange.Core.Application.Contracts.Response;
using CGM.CashExchange.Core.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace CGM.CashExchange.EntryPoint.Api.Middlewares
{
    public class ErrorHandlingMiddleware
    {

        private readonly IDictionary<Type, Func<Exception, Response>> _exceptionHandlers;
        private readonly RequestDelegate next;
        public bool IsDevelopment { get; private set; }
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _exceptionHandlers = new Dictionary<Type, Func<Exception, Response>>
            {
                { typeof(ValidationException), HandleValidationException},

            };
            this.next = next;
        }

        public async Task Invoke(HttpContext context, IWebHostEnvironment env)
        {
            try
            {
                IsDevelopment = env.IsDevelopment();
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, env);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex, IWebHostEnvironment env)
        {


            Type type = ex.GetType();
            Response errorHandler = null;
            if (_exceptionHandlers.ContainsKey(type))
            {
                errorHandler = _exceptionHandlers[type].Invoke(ex);
            }
            else
            {
                errorHandler = HandleUnknownException(ex);
            }

            context.Response.ContentType = "application/problem+json";
            context.Response.StatusCode = errorHandler.Status;

            var result = JsonConvert.SerializeObject(errorHandler);
            return context.Response.WriteAsync(result);
        }
        private Response HandleValidationException(Exception ex)
        {
            var exception = ex as ValidationException;
            var type = "https://tools.ietf.org/html/rfc7231#section-6.5.1";
            var title = "One or more validation errors occurred.";
            return FailResponse.Fail(exception.Errors , StatusCodes.Status400BadRequest , title,type);

        }
        private Response HandleUnknownException(Exception ex)
        {
            var title = IsDevelopment ? ex.Message : "An error occurred while processing your request.";
            var type = "https://tools.ietf.org/html/rfc7231#section-6.6.1";
            var detail = IsDevelopment ? ex.StackTrace : "Contactar a soporte.";
            return FailResponse.Fail(detail, StatusCodes.Status500InternalServerError, title, type);
        }
    }
}
