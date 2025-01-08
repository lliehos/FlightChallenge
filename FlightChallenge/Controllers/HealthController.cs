using Microsoft.AspNetCore.Mvc;

namespace FlightChallenge.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
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
