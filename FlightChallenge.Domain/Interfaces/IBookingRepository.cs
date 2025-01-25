using FlightChallenge.Domain.Entities;

namespace FlightChallenge.Domain.Interfaces
{
    public interface IBookingRepository
    {
        Task<Booking> AddBookingAsync(Booking booking);
        Task<Booking> UpdateBookingAsync(Booking booking);
        Task<bool> DeleteBookingAsync(int id);
        Task<Booking?> GetBookingByIdAsync(int id);
        Task<IEnumerable<Booking>> GetBookingsByFlightIdAsync(int flightId, int page = 1, int count = 10);
        Task<IEnumerable<Booking>> GetBookingsByPassengerIdAsync(int passengerId, int page = 1, int count = 10);
        Task<bool> AnyBookingForFlightAsync(int flightId);
    }
}
