namespace FlightChallenge.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IFlightRepository Flights { get; }
        IPassengerRepository Passengers { get; }
        IBookingRepository Bookings { get; }

        Task<int> CommitAsync();  
    }

}
