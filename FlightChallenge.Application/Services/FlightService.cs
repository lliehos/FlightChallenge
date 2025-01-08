using AutoMapper;
using FlightChallenge.Application.Dtos;
using FlightChallenge.Application.Interfaces;
using FlightChallenge.Domain.Entities;
using FlightChallenge.Domain.Interfaces;

namespace FlightChallenge.Application.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IMapper _mapper;

        public FlightService(IFlightRepository flightRepository, IMapper mapper)
        {
            _flightRepository = flightRepository;
            _mapper = mapper;
        }

        public async Task<FlightDto> GetFlightByIdAsync(int id)
        {
            var flight = await _flightRepository.GetFlightByIdAsync(id);
            return _mapper.Map<FlightDto>(flight);
        }

        public async Task<IEnumerable<FlightDto>> GetFlightsAsync(string? origin, string? destination, DateTime? departureDate)
        {
            var flights = await _flightRepository.GetFlightsAsync(origin, destination, departureDate);
            return _mapper.Map<IEnumerable<FlightDto>>(flights);
        }

        public async Task<FlightDto> AddFlightAsync(FlightCreateDto flight)
        {
            var flightEntity = _mapper.Map<Flight>(flight);
            var addedFlight = await _flightRepository.AddFlightAsync(flightEntity);
            return _mapper.Map<FlightDto>(addedFlight);
        }

        public async Task<FlightDto> UpdateFlightAsync(int id, FlightUpdateDto flight)
        {
            var flightEntity = await _flightRepository.GetFlightByIdAsync(id);
            if (flightEntity == null)
                return null;

            _mapper.Map(flight, flightEntity);
            var updatedFlight = await _flightRepository.UpdateFlightAsync(flightEntity);
            return _mapper.Map<FlightDto>(updatedFlight);
        }

        public async Task<bool> DeleteFlightAsync(int id)
        {
            return await _flightRepository.DeleteFlightAsync(id);
        }
    }
}
