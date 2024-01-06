using Entities.ErrorModels;
using Interfaces.Managers;
using System.Net;

namespace web_Api.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerManager _loggerManager;
        public ExceptionHandlerMiddleware(RequestDelegate next, ILoggerManager loggerManager)
        {
            _next = next;
            _loggerManager = loggerManager;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                await HandlerExceptionMessageAsync(httpContext, ex, _loggerManager);
            }
        }
        private static async Task HandlerExceptionMessageAsync(HttpContext httpContext, Exception exception, ILoggerManager logger)
        {
            int statusCode = (int)HttpStatusCode.InternalServerError;


            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;

            logger.LogError("Something went wrong " + exception.Message);

            await httpContext.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = statusCode,
                Message = "Internal Server error!"

            }.ToString());
        }
    }
}
