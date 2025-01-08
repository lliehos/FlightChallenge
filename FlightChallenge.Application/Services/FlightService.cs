using AutoMapper;
using FlightChallenge.Application.Commands;
using FlightChallenge.Application.Dtos;
using FlightChallenge.Application.Interfaces;
using FlightChallenge.Domain.Entities;
using FlightChallenge.Domain.Interfaces;

using FlightChallenge.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightChallenge.Application.Services
{
    public class FlightService : IFlightService
    {
        public Task<FlightDto> AddFlightAsync(FlightCreateDto flight)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFlightAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<FlightDto> GetFlightByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FlightDto>> GetFlightsAsync(string? origin, string? destination, DateTime? departureDate)
        {
            throw new NotImplementedException();
        }

        public Task<FlightDto> UpdateFlightAsync(int id, FlightUpdateDto flight)
        {
            throw new NotImplementedException();
        }
    }
}
