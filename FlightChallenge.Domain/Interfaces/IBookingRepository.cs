using FlightChallenge.Domain.Entities;

namespace FlightChallenge.Domain.Interfaces
{
    public interface IBookingRepository
    {
        Task<Booking> CreateBookingAsync(int flightId, int passengerId, string seatNumber);
        Task<IEnumerable<Booking>> GetBookingsForFlightAsync(int flightId);
    }
}
