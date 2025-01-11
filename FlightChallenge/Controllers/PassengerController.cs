using FlightChallenge.Application.Dtos;
using FlightChallenge.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(Summary = "Get all passengers", Description = "Fetches a list of passengers based on provided filters.")]
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
        [SwaggerOperation(Summary = "Get a passenger by its ID", Description = "Fetches passenger details using the unique passenger ID.")]
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
        [SwaggerOperation(Summary = "Create a new passenger", Description = "Creates a new passenger and returns the created passenger details.")]
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
        [SwaggerOperation(Summary = "Update an existing passenger", Description = "Updates an existing passenger by its ID with the provided details.")]
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
        [SwaggerOperation(Summary = "Delete a passenger", Description = "Deletes a passenger by its ID.")]

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
