using FlightChallenge.Application.Dtos;
using FlightChallenge.Application.Interfaces;
using FlightChallenge.Application.Validators;
using FlightChallenge.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FlightChallenge.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get a flight by its ID", Description = "Fetches flight details using the unique flight ID.")]
        public async Task<IActionResult> GetFlight(int id)
        {
            var flight = await _flightService.GetFlightByIdAsync(id);
            if (flight == null)
                return NotFound();
            else
                return Ok(flight);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all flights", Description = "Fetches a list of flights based on the provided filters.")]
        public async Task<IActionResult> GetFlights([FromQuery] string? origin, [FromQuery] string? destination, [FromQuery] DateTime? departureDate, int page = 1, int count = 10)
        {
            var flights = await _flightService.GetFlightsAsync(origin, destination, departureDate,page,count);
            return Ok(flights);
        }
        [HttpPost]
        [SwaggerOperation(Summary = "Get all flights", Description = "Fetches a list of flights based on the provided filters.")]
        public async Task<IActionResult> CreateFlight([FromBody] FlightCreateDto flight)
        {
            var createdFlight = await _flightService.AddFlightAsync(flight);
            if (createdFlight.Success)
            {
                return Ok(createdFlight);
            }
            return BadRequest(createdFlight.Errors);
        }
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update an existing flight", Description = "Updates an existing flight by its ID with the provided details.")]
        public async Task<IActionResult> UpdateFlight(int id, [FromBody] FlightUpdateDto flight)
        {
            var updatedFlight = await _flightService.UpdateFlightAsync(id, flight);
            if (updatedFlight == null)
            {
                return NotFound();
            }
            if (updatedFlight.Success)
            {
                return NoContent();
            }
            return BadRequest(updatedFlight.Errors);
        }
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a flight", Description = "Deletes a flight by its ID. Returns an error if there are bookings associated.")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            var result = await _flightService.DeleteFlightAsync(id);

            if (result == null)
                return NotFound($"Flight with id {id} not found.");

            if (!result.Value)
                return BadRequest($"Cannot delete flight with id {id} because it has related bookings.");

            return NoContent();
        }
    }
}
