using FlightChallenge.Domain.Entities;
using FlightChallenge.Domain.Interfaces;

namespace FlightChallenge.Infrastructure.Repositories
{
    public class BokkingRepository : IBookingRepository
    {
        public Task AddBookingAsync(Booking booking)
        {
            throw new NotImplementedException();
        }

        public Task DeleteBookingAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Booking> GetBookingByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Booking>> GetBookingsByFlightIdAsync(int flightId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Booking>> GetBookingsByPassengerIdAsync(int passengerId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBookingAsync(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}