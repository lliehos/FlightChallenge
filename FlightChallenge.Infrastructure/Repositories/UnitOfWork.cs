using System;
using System.Threading.Tasks;
using FlightChallenge.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FlightChallenge.Infrastructure.Repositories
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IFlightRepository _flightRepository;
        private IPassengerRepository _passengerRepository;
        private IBookingRepository _bookingRepository;

        public UnitOfWork(AppDbContext context, IFlightRepository flightRepository, IPassengerRepository passengerRepository, IBookingRepository bookingRepository)
        {
            _flightRepository = flightRepository;
            _passengerRepository = passengerRepository;
            _bookingRepository = bookingRepository;
        }

        public IFlightRepository Flights => _flightRepository;

        public IPassengerRepository Passengers => _passengerRepository;

        public IBookingRepository Bookings => _bookingRepositoryB;

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}