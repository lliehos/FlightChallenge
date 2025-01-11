using AutoMapper;
using FlightChallenge.Application.Dtos;
using FlightChallenge.Application.Interfaces;
using FlightChallenge.Domain.Entities;
using FlightChallenge.Domain.Interfaces;
using FluentValidation;
using Microsoft.Extensions.Caching.Memory;

public class FlightService : IFlightService
{
    private readonly IFlightRepository _flightRepository;
    private readonly IBookingRepository _bookingRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<FlightCreateDto> _createFlightValidator;
    private readonly IValidator<FlightUpdateDto> _updateFlightValidator;
    private readonly IMemoryCache _cache;

    public FlightService(IFlightRepository flightRepository, IMapper mapper, IValidator<FlightCreateDto> createFlightValidator, IValidator<FlightUpdateDto> updateFlightValidator, IBookingRepository bookingRepository, IMemoryCache cache)
    {
        _flightRepository = flightRepository;
        _mapper = mapper;
        _createFlightValidator = createFlightValidator;
        _updateFlightValidator = updateFlightValidator;
        _bookingRepository = bookingRepository;
        _cache = cache;
    }

    public async Task<FlightDto> GetFlightByIdAsync(int id)
    {
        var cacheKey = $"flight_{id}";
        if (!_cache.TryGetValue(cacheKey, out FlightDto flight))
        {
            var flightEntity = await _flightRepository.GetFlightByIdAsync(id);
            flight = _mapper.Map<FlightDto>(flightEntity);
            _cache.Set(cacheKey, flight, TimeSpan.FromMinutes(10));
        }
        return flight;
    }

    public async Task<IEnumerable<FlightDto>> GetFlightsAsync(string? origin, string? destination, DateTime? departureDate, int page = 1, int count = 10)
    {
        var cacheKey = $"flights_{origin}_{destination}_{departureDate}_{page}_{count}";
        if (!_cache.TryGetValue(cacheKey, out IEnumerable<FlightDto> flights))
        {
            var flightEntities = await _flightRepository.GetFlightsAsync(origin, destination, departureDate, page, count);
            flights = _mapper.Map<IEnumerable<FlightDto>>(flightEntities);
            _cache.Set(cacheKey, flights, TimeSpan.FromMinutes(10));
        }

        return flights;
    }

    public async Task<ServiceResponse<FlightDto>> AddFlightAsync(FlightCreateDto flight)
    {
        var result = await _createFlightValidator.ValidateAsync(flight);
        if (result.IsValid)
        {
            var flightEntity = _mapper.Map<Flight>(flight);
            var addedFlight = await _flightRepository.AddFlightAsync(flightEntity);
            _cache.Remove($"flights_{flight.Origin}_{flight.Destination}_{flight.DepartureTime.Date}");
            return new ServiceResponse<FlightDto>() { Success = true, Data = _mapper.Map<FlightDto>(addedFlight) };
        }
        else
        {
            return new ServiceResponse<FlightDto>() { Success = false, Errors = result.Errors.Select(e => e.ErrorMessage).ToList() };
        }
    }

    public async Task<ServiceResponse<FlightDto>> UpdateFlightAsync(int id, FlightUpdateDto flight)
    {
        var flightEntity = await _flightRepository.GetFlightByIdAsync(id);
        if (flightEntity == null)
            return null;

        flight.Id = id;
        var result = await _updateFlightValidator.ValidateAsync(flight);
        if (result.IsValid)
        {
            _mapper.Map(flight, flightEntity);
            var updatedFlight = await _flightRepository.UpdateFlightAsync(flightEntity);
            _cache.Remove($"flight_{id}");
            _cache.Remove($"flights_{flight.Origin}_{flight.Destination}_{flight.DepartureTime.Date}");

            return new ServiceResponse<FlightDto>() { Success = true, Data = _mapper.Map<FlightDto>(updatedFlight) };
        }
        else
        {
            return new ServiceResponse<FlightDto>() { Success = false, Errors = result.Errors.Select(e => e.ErrorMessage).ToList() };
        }
    }

    public async Task<bool?> DeleteFlightAsync(int id)
    {
        var flight = await _flightRepository.GetFlightByIdAsync(id);
        if (flight == null)
            return null;

        var hasBookings = await _bookingRepository.AnyBookingForFlightAsync(id);
        if (hasBookings)
            return false;

        await _flightRepository.DeleteFlightAsync(id);
        _cache.Remove($"flight_{id}");
        _cache.Remove($"flights_{flight.Origin}_{flight.Destination}_{flight.DepartureTime.Date}");

        return true;
    }
}
