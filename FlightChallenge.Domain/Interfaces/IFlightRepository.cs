using FlightChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightChallenge.Domain.Interfaces
{
    public interface IFlightRepository
    {
        Task<Flight> GetFlightByIdAsync(int id);
        Task<IEnumerable<Flight>> GetFlightsAsync(string? origin, string? destination, DateTime? departureDate, int page = 1, int count = 10);
        Task<Flight> AddFlightAsync(Flight flight);
        Task<Flight> UpdateFlightAsync(Flight flight);
        Task<bool> DeleteFlightAsync(int id);
    }

}
