using FlightChallenge.Domain.Entities;

namespace FlightChallenge.Domain.Interfaces
{
    public interface IBookingRepository
    {
        Task<Booking> GetBookingByIdAsync(int id);  
        Task<IEnumerable<Booking>> GetBookingsByFlightIdAsync(int flightId); 
        Task<IEnumerable<Booking>> GetBookingsByPassengerIdAsync(int passengerId);  
        Task AddBookingAsync(Booking booking);  
        Task UpdateBookingAsync(Booking booking); 
        Task DeleteBookingAsync(int id);  
    }
}
