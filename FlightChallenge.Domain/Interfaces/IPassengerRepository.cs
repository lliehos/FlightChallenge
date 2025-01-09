using FlightChallenge.Domain.Entities;

namespace FlightChallenge.Domain.Interfaces
{
    public interface IPassengerRepository
    {
        Task<Passenger> GetPassengerByIdAsync(int id);
        Task<IEnumerable<Passenger>> GetPassengersAsync(int page, int count);
        Task<Passenger> AddPassengerAsync(Passenger passenger);
        Task<Passenger> UpdatePassengerAsync(Passenger passenger);
        Task<bool> DeletePassengerAsync(int id);
    }
}
