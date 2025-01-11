using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FlightChallenge.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(Summary = "Get the application health status", Description = "Returns the current health status of the application.")]
        public IActionResult GetServerStatus()
        {
            var serverStatus = new
            {
                status = "Server is up and running", 
                currentTime = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"),
                message = "Server is healthy and available for requests." 
            };
            return Ok(serverStatus); 
        }
    }
}
