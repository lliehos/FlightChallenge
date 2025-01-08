
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
namespace FlightChallenge.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment _env;

        public ExceptionFilter(IWebHostEnvironment env)
        {
            _env = env;
        }

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            // لاگ گرفتن خطا با استفاده از Serilog
            Log.Error(exception, "An error occurred in the controller");

            // ایجاد پاسخ خطا به صورت JSON
            context.Result = new JsonResult(new
            {
                message = "An unexpected error occurred.",
                details = _env.IsDevelopment() ? exception.ToString() : null
            })
            {
                StatusCode = 500
            };
        }
    }

}
