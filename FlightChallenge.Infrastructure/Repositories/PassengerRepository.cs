using FlightChallenge.Domain.Entities;
using FlightChallenge.Domain.Interfaces;

namespace FlightChallenge.Infrastructure.Repositories
{
    public class PassengerRepository : IPassengerRepository
    {
        public Task AddPassengerAsync(Passenger passenger)
        {
            throw new NotImplementedException();
        }

        public Task DeletePassengerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Passenger> GetPassengerByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Passenger>> GetPassengersAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdatePassengerAsync(Passenger passenger)
        {
            throw new NotImplementedException();
        }
    }
}