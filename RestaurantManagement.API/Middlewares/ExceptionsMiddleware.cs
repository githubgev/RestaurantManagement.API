using RM.Entities;
using System.Text;

namespace RM.API.Middlewares
{
    public class ExceptionsMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILogger<ExceptionsMiddleware> _logger;

        public ExceptionsMiddleware(RequestDelegate next, ILogger<ExceptionsMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (GenericException ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, GenericException exception)
        {
            var bytes = Encoding.UTF8.GetBytes(exception.Message);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)exception.StatusCode;

            await context.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = context.Response.StatusCode,
                Message = Encoding.Default.GetString(bytes),
            }.ToString());
        }
    }
}
