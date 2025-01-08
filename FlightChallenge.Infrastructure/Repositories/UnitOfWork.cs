using FlightChallenge.Domain.Interfaces;

namespace FlightChallenge.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IFlightRepository Flights => throw new NotImplementedException();

        public IPassengerRepository Passengers => throw new NotImplementedException();

        public IBookingRepository Bookings => throw new NotImplementedException();

        public Task<int> CommitAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}