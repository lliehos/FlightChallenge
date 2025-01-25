using FlightChallenge.Domain.Entities;
using FlightChallenge.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FlightChallenge.Infrastructure.Repositories
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly AppDbContext _context;

        public PassengerRepository(AppDbContext context)
        {
            _context = context;
        }

        // دریافت یک مسافر بر اساس شناسه
        public async Task<Passenger?> GetPassengerByIdAsync(int id)
        {
            return await _context.Passengers
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        // دریافت تمامی مسافران با صفحه‌بندی
        public async Task<IEnumerable<Passenger>> GetPassengersAsync(int page, int count)
        {
            return await _context.Passengers
                .Skip((page - 1) * count)
                .Take(count)
                .ToListAsync();
        }

        // اضافه کردن مسافر جدید
        public async Task<Passenger> AddPassengerAsync(Passenger passenger)
        {
            await _context.Passengers.AddAsync(passenger);
            await _context.SaveChangesAsync();
            return passenger;
        }

        // به‌روزرسانی اطلاعات مسافر
        public async Task<Passenger> UpdatePassengerAsync(Passenger passenger)
        {
            _context.Passengers.Update(passenger);
            await _context.SaveChangesAsync();
            return passenger;
        }

        // حذف مسافر
        public async Task<bool> DeletePassengerAsync(int id)
        {
            var passenger = await GetPassengerByIdAsync(id);
            if (passenger == null)
            {
                return false;
            }

            _context.Passengers.Remove(passenger);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}