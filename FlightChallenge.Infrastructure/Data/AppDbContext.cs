using FlightChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected AppDbContext()
    {
    }

    public DbSet<Flight> Flights { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Passenger> Passengers { get; set; }
}
