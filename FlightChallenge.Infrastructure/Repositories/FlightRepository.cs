using FlightChallenge.Domain.Entities;
using FlightChallenge.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightChallenge.Infrastructure.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly AppDbContext _context;

        public FlightRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Flight> GetFlightByIdAsync(int id)
        {
            return await _context.Flights.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<Flight>> GetFlightsAsync(string? origin, string? destination, DateTime? departureDate)
        {
            var query = _context.Flights.AsQueryable();

            if (!string.IsNullOrEmpty(origin))
                query = query.Where(f => f.Origin == origin);

            if (!string.IsNullOrEmpty(destination))
                query = query.Where(f => f.Destination == destination);

            if (departureDate.HasValue)
                query = query.Where(f => f.DepartureTime.Date == departureDate.Value.Date);

            return await query.ToListAsync();
        }

        public async Task<Flight> AddFlightAsync(Flight flight)
        {
            _context.Flights.Add(flight);
            await _context.SaveChangesAsync();
            return flight;
        }

        public async Task<Flight> UpdateFlightAsync(Flight flight)
        {
            _context.Flights.Update(flight);
            await _context.SaveChangesAsync();
            return flight;
        }

        public async Task<bool> DeleteFlightAsync(int id)
        {
            var flight = await _context.Flights.FirstOrDefaultAsync(f => f.Id == id);
            if (flight == null) return false;

            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}