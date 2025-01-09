using FlightChallenge.Application.Dtos;
using FlightChallenge.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FlightChallenge.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly IPassengerService _passengerService;

        public PassengerController(IPassengerService passengerService)
        {
            _passengerService = passengerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPassengers([FromQuery] int page = 1, [FromQuery] int count = 10)
        {
            var response = await _passengerService.GetPassengersAsync(page, count);
            if (!response.Success)
            {
                return BadRequest(response.Errors);
            }
            return Ok(response.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPassenger(int id)
        {
            var response = await _passengerService.GetPassengerByIdAsync(id);
            if (!response.Success)
            {
                return NotFound(response.Errors);
            }
            return Ok(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> AddPassenger([FromBody] PassengerCreateDto passengerDto)
        {
            var response = await _passengerService.AddPassengerAsync(passengerDto);
            if (!response.Success)
            {
                return BadRequest(response.Errors);
            }
            return CreatedAtAction(nameof(GetPassenger), new { id = response.Data.Id }, response.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePassenger(int id, [FromBody] PassengerUpdateDto passengerUpdateDto)
        {
            var response = await _passengerService.UpdatePassengerAsync(id, passengerUpdateDto);
            if (!response.Success)
            {
                return BadRequest(response.Errors);
            }
            return Ok(response.Data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassenger(int id)
        {
            var response = await _passengerService.DeletePassengerAsync(id);
            if (!response.Success)
            {
                return NotFound(response.Errors);
            }
            return NoContent();
        }
    }

}
