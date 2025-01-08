using Serilog;

namespace FlightChallenge.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log request details
            var requestDetails = $"Method: {context.Request.Method}, Path: {context.Request.Path}, QueryString: {context.Request.QueryString}";
            Log.Information("Request: {Details}", requestDetails);

            // Call the next middleware in the pipeline
            await _next(context);

            // Log response details
            Log.Information("Response Status Code: {StatusCode}", context.Response.StatusCode);
        }
    }

}
