namespace FlightChallenge.Application.Dtos
{
    public class BookingCrateDto
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public int PassengerId { get; set; }
        public DateTime BookingDate { get; set; }
        public decimal Price { get; set; }
    }
}
