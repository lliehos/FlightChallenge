using FlightChallenge.Domain.Entities;

namespace FlightChallenge.Domain.Interfaces
{
    public interface IPassengerRepository
    {
        Task<Passenger> GetPassengerByIdAsync(int id); 
        Task<IEnumerable<Passenger>> GetPassengersAsync(); 
        Task AddPassengerAsync(Passenger passenger);  
        Task UpdatePassengerAsync(Passenger passenger); 
        Task DeletePassengerAsync(int id); 
    }

}
