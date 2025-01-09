namespace FlightChallenge.Application.Dtos
{
    public class BookingUpdateDto
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public int PassengerId { get; set; }
        public DateTime BookingDate { get; set; }
        public decimal Price { get; set; }
        public int SeatNumber { get; set; }
    }
}
