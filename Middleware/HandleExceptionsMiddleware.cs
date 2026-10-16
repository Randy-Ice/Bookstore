namespace Bookstore.Middleware
{
    public class HandleExceptionsMiddleware
    {
        private readonly ILogger<HandleExceptionsMiddleware> _logger;
        private readonly RequestDelegate _next;
        public HandleExceptionsMiddleware(ILogger<HandleExceptionsMiddleware> logger,
            RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.");
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync("An error occurred while processing your request.");
            }
        }


    }
}
