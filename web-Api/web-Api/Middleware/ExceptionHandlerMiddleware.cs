using System.Net;
using System.Text.Json;

namespace web_Api.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                await HandlerExceptionMessageAsync(httpContext, ex);
            }
        }
        private static async Task HandlerExceptionMessageAsync(HttpContext httpContext, Exception exception)
        {
            int statusCode = (int)HttpStatusCode.InternalServerError;

            var result = JsonSerializer.Serialize(new
            {
                StatusCode = statusCode,
                ErrorMesage = exception.Message
            });

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;

            await httpContext.Response.WriteAsync(result);
        }
    }
}
