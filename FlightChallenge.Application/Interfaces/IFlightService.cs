using FlightChallenge.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightChallenge.Application.Interfaces
{
    public interface IFlightService
    {
        Task<FlightDto> GetFlightByIdAsync(int id);
        Task<IEnumerable<FlightDto>> GetFlightsAsync(string? origin, string? destination, DateTime? departureDate);
        Task<ServiceResponse<FlightDto>> AddFlightAsync(FlightCreateDto flight);
        Task<ServiceResponse<FlightDto>> UpdateFlightAsync(int id, FlightUpdateDto flight);
        Task<bool> DeleteFlightAsync(int id);
    }
}
