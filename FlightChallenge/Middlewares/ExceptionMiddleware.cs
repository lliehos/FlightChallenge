using Serilog;

namespace FlightChallenge.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // درخواست به Middleware بعدی ارسال می‌شود
                await _next(context);
            }
            catch (Exception ex)
            {
                // لاگ گرفتن خطا با استفاده از Serilog
                Log.Error(ex, "An unexpected error occurred");

                // پاسخ خطا به صورت JSON
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                var errorResponse = new
                {
                    message = "An unexpected error occurred.",
                    details = _env.IsDevelopment() ? ex.ToString() : null
                };

                await context.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }

}
