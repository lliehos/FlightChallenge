using FlightChallenge.Application.Dtos;
using FlightChallenge.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace FlightChallenge.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("by-flight/{flightId}")]
        [SwaggerOperation(Summary = "Get a booking by FlightId", Description = "Fetches booking details using the flightId.")]

        public async Task<IActionResult> GetBookingsByFlightIdAsync(int flightId, [FromQuery] int page = 1, [FromQuery] int count = 10)
        {
            var bookings = await _bookingService.GetBookingsByFlightIdAsync(flightId, page, count);
            return Ok(bookings);
        }

        [HttpGet("by-passenger/{passengerId}")]
        [SwaggerOperation(Summary = "Get a booking by passengerId", Description = "Fetches booking details using the passengerId.")]

        public async Task<IActionResult> GetBookingsByPassengerIdAsync(int passengerId, [FromQuery] int page = 1, [FromQuery] int count = 10)
        {
            var bookings = await _bookingService.GetBookingsByPassengerIdAsync(passengerId, page, count);
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get a booking by its ID", Description = "Fetches booking details using the unique booking ID.")]
        public async Task<IActionResult> GetBookingByIdAsync(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null)
            {
                return NotFound(new { message = "Booking not found." });
            }
            return Ok(booking);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new booking", Description = "Creates a new booking and returns the created booking details.")]
        public async Task<IActionResult> AddBookingAsync([FromBody] BookingCrateDto bookingDto)
        {
            var result = await _bookingService.AddBookingAsync(bookingDto);
            if (!result.Success)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result.Data);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update an existing booking", Description = "Updates an existing booking by its ID with the provided details.")]
        public async Task<IActionResult> UpdateBookingAsync(int id, [FromBody] BookingUpdateDto bookingDto)
        {
            var result = await _bookingService.UpdateBookingAsync(id, bookingDto);
            if (!result.Success)
            {
                return NotFound(new { message = "Booking not found or could not be updated." });
            }
            return Ok(result.Data);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a booking", Description = "Deletes a booking by its ID.")]
        public async Task<IActionResult> DeleteBookingAsync(int id)
        {
            var result = await _bookingService.DeleteBookingAsync(id);
            if (!result.Success)
            {
                return NotFound(new { message = "Booking not found or could not be deleted." });
            }
            return NoContent();
        }
    }

}
