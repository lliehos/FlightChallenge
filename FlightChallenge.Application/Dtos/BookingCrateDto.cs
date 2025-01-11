using Swashbuckle.AspNetCore.Annotations;

namespace FlightChallenge.Application.Dtos
{
    [SwaggerSchema("Dto For new booking")]
    public class BookingCrateDto
    {
        public int FlightId { get; set; }
        public int PassengerId { get; set; }
        public DateTime BookingDate { get; set; }
        public decimal Price { get; set; }
        public int SeatNumber { get; set; }

    }
}
