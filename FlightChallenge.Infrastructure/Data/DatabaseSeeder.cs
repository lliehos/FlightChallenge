using FlightChallenge.Domain.Entities;

public class DatabaseSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (!context.Flights.Any())
        {
            context.Flights.AddRange(
                new Flight
                {
                    ArrivalTime =new DateTime(2025,1,15,16,59,0),
                    AvailableSeats = 150,
                    FlightNumber="2056",
                    Destination="مشهد",
                    Price=32000000,
                    DepartureTime = new DateTime(2025, 1, 15, 18, 00, 0),
                    Origin="تهران"
                },
                new Flight
                {
                    ArrivalTime = new DateTime(2025, 1, 16, 16, 59, 0),
                    AvailableSeats = 150,
                    FlightNumber = "2056",
                    Destination = "مشهد",
                    Price = 32000000,
                    DepartureTime = new DateTime(2025, 1, 16, 18, 00, 0),
                    Origin = "تهران"
                },
                new Flight
                {
                    ArrivalTime = new DateTime(2025, 1, 17, 16, 59, 0),
                    AvailableSeats = 150,
                    FlightNumber = "2056",
                    Destination = "مشهد",
                    Price = 32000000,
                    DepartureTime = new DateTime(2025, 1, 17, 18, 00, 0),
                    Origin = "تهران"
                },
                new Flight
                {
                    ArrivalTime = new DateTime(2025, 1, 18, 16, 59, 0),
                    AvailableSeats = 150,
                    FlightNumber = "2056",
                    Destination = "مشهد",
                    Price = 32000000,
                    DepartureTime = new DateTime(2025, 1, 18, 18, 00, 0),
                    Origin = "تهران"
                }

                );
            context.SaveChanges();
        }
        if (!context.Passengers.Any())
        {
            context.Passengers.AddRange(
                new Passenger
                {
                    Email="lliehos@yahoo.com",
                    FullName="سید سهیل حسینی",
                    PassportNumber="654789",
                    PhoneNumber="9153244965"
                },
                new Passenger
                {
                    Email = "moh.1568@yahoo.com",
                    FullName = "رضا اسد زاده",
                    PassportNumber = "456321",
                    PhoneNumber = "9152155486",
                },
                new Passenger
                {
                Email = "rezahalgh21@yahoo.com",
                FullName = "رضا حق شناس",
                PassportNumber = "741852",
                PhoneNumber = "9153244965"
                },
                new Passenger
                {
                Email = "ma2024@yahoo.com",
                FullName = "مریم آذری",
                PassportNumber = "963852",
                PhoneNumber = "9153244965"
                }
                );
            context.SaveChanges();
        }
    }
}
