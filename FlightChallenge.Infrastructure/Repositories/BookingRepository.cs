using FlightChallenge.Domain.Entities;
using FlightChallenge.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FlightChallenge.Infrastructure.Repositories
{

    public class BookingRepository : IBookingRepository
    {
        private readonly AppDbContext _context;

        public BookingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Booking> AddBookingAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<Booking> UpdateBookingAsync(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<bool> DeleteBookingAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
                return false;

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            return await _context.Bookings
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Booking>> GetBookingsByFlightIdAsync(int flightId, int page = 1, int count = 10)
        {
            return await _context.Bookings
                .Where(b => b.FlightId == flightId)
                .Skip((page - 1) * count)
                .Take(count)
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsByPassengerIdAsync(int passengerId, int page = 1, int count = 10)
        {
            return await _context.Bookings
                .Where(b => b.PassengerId == passengerId)
                .Skip((page - 1) * count)
                .Take(count)
                .ToListAsync();
        }

        public async Task<bool> AnyBookingForFlightAsync(int flightId)
        {
            return await _context.Bookings
                .AnyAsync(b => b.FlightId == flightId);
        }
    }

}