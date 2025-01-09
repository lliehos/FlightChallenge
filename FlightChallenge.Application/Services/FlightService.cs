using AutoMapper;
using FlightChallenge.Application.Dtos;
using FlightChallenge.Application.Interfaces;
using FlightChallenge.Application.Validators;
using FlightChallenge.Domain.Entities;
using FlightChallenge.Domain.Interfaces;
using FlightChallenge.Infrastructure.Repositories;
using FluentValidation;
using System;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FlightChallenge.Application.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<FlightCreateDto> _createFlightValidator;
        private readonly IValidator<FlightUpdateDto> _updateFlightValidator;

        public FlightService(IFlightRepository flightRepository, IMapper mapper, IValidator<FlightCreateDto> createFlightValidator, IValidator<FlightUpdateDto> updateFlightValidator)
        {
            _flightRepository = flightRepository;
            _mapper = mapper;
            _createFlightValidator = createFlightValidator;
            _updateFlightValidator = updateFlightValidator;
        }

        public async Task<FlightDto> GetFlightByIdAsync(int id)
        {
            var flight = await _flightRepository.GetFlightByIdAsync(id);
            return _mapper.Map<FlightDto>(flight);
        }

        public async Task<IEnumerable<FlightDto>> GetFlightsAsync(string? origin, string? destination, DateTime? departureDate, int page = 1, int count = 10)
        {
            var flights = await _flightRepository.GetFlightsAsync(origin, destination, departureDate,page,count);
            return _mapper.Map<IEnumerable<FlightDto>>(flights);
        }

        public async Task<ServiceResponse<FlightDto>> AddFlightAsync(FlightCreateDto flight)
        {
            var result = await _createFlightValidator.ValidateAsync(flight);
            if (result.IsValid)
            {
                var flightEntity = _mapper.Map<Flight>(flight);
                var addedFlight = await _flightRepository.AddFlightAsync(flightEntity);
                return new ServiceResponse<FlightDto>() { Success = true, Data = _mapper.Map<FlightDto>(addedFlight) };
            }
            else
            {
                return new ServiceResponse<FlightDto>() { Success = false, Errors= result.Errors.Select(e => e.ErrorMessage).ToList() };
            }

        }
        public async Task<ServiceResponse<FlightDto>> UpdateFlightAsync(int id, FlightUpdateDto flight)
        {
            var flightEntity = await _flightRepository.GetFlightByIdAsync(id);
            if (flightEntity == null)
                return null;
            var result = await _updateFlightValidator.ValidateAsync(flight);
            if (result.IsValid)
            {
                _mapper.Map(flight, flightEntity);
                var updatedFlight = await _flightRepository.UpdateFlightAsync(flightEntity);
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
            return true;
        }
    }

}
