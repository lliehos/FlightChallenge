using FlightChallenge.Domain.Entities;

public class DatabaseSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (!context.Flights.Any())
        {
            context.Flights.AddRange(GetSampleFlights());
            context.SaveChanges();
        }
        if (!context.Passengers.Any())
        {
            context.Passengers.AddRange(GetSamplePassengers());
            context.SaveChanges();
        }
    }
    public static List<Flight> GetSampleFlights()
    {
        return new List<Flight>
    {
        new Flight
        {
            ArrivalTime = new DateTime(2025, 1, 18, 16, 59, 0),
            AvailableSeats = 150,
            FlightNumber = "2056",
            Destination = "ارومیه",
            Price = 32000000,
            DepartureTime = new DateTime(2025, 1, 18, 18, 00, 0),
            Origin = "تهران"
        },
        new Flight
        {
            ArrivalTime = new DateTime(2025, 1, 19, 14, 30, 0),
            AvailableSeats = 100,
            FlightNumber = "2057",
            Destination = "مشهد",
            Price = 40000000,
            DepartureTime = new DateTime(2025, 1, 19, 15, 00, 0),
            Origin = "تهران"
        },
        new Flight
        {
            ArrivalTime = new DateTime(2025, 1, 20, 10, 10, 0),
            AvailableSeats = 120,
            FlightNumber = "2058",
            Destination = "شیراز",
            Price = 35000000,
            DepartureTime = new DateTime(2025, 1, 20, 11, 00, 0),
            Origin = "تهران"
        },
        new Flight
        {
            ArrivalTime = new DateTime(2025, 1, 21, 12, 00, 0),
            AvailableSeats = 140,
            FlightNumber = "2059",
            Destination = "تبریز",
            Price = 33000000,
            DepartureTime = new DateTime(2025, 1, 21, 13, 00, 0),
            Origin = "تهران"
        },
        new Flight
        {
            ArrivalTime = new DateTime(2025, 1, 22, 15, 45, 0),
            AvailableSeats = 80,
            FlightNumber = "2060",
            Destination = "اصفهان",
            Price = 31000000,
            DepartureTime = new DateTime(2025, 1, 22, 16, 30, 0),
            Origin = "تهران"
        },
        new Flight
        {
            ArrivalTime = new DateTime(2025, 1, 23, 17, 20, 0),
            AvailableSeats = 130,
            FlightNumber = "2061",
            Destination = "کیش",
            Price = 28000000,
            DepartureTime = new DateTime(2025, 1, 23, 18, 00, 0),
            Origin = "تهران"
        },
        new Flight
        {
            ArrivalTime = new DateTime(2025, 1, 24, 19, 00, 0),
            AvailableSeats = 90,
            FlightNumber = "2062",
            Destination = "بندرعباس",
            Price = 35000000,
            DepartureTime = new DateTime(2025, 1, 24, 20, 00, 0),
            Origin = "تهران"
        },
        new Flight
        {
            ArrivalTime = new DateTime(2025, 1, 25, 11, 30, 0),
            AvailableSeats = 160,
            FlightNumber = "2063",
            Destination = "یاسوج",
            Price = 33000000,
            DepartureTime = new DateTime(2025, 1, 25, 12, 00, 0),
            Origin = "تهران"
        },
        new Flight
        {
            ArrivalTime = new DateTime(2025, 1, 26, 13, 00, 0),
            AvailableSeats = 110,
            FlightNumber = "2064",
            Destination = "کرمان",
            Price = 30000000,
            DepartureTime = new DateTime(2025, 1, 26, 14, 00, 0),
            Origin = "تهران"
        },
        new Flight
        {
            ArrivalTime = new DateTime(2025, 1, 27, 16, 15, 0),
            AvailableSeats = 120,
            FlightNumber = "2065",
            Destination = "زاهدان",
            Price = 34000000,
            DepartureTime = new DateTime(2025, 1, 27, 17, 00, 0),
            Origin = "تهران"
        },
        new Flight
        {
            ArrivalTime = new DateTime(2025, 1, 28, 18, 20, 0),
            AvailableSeats = 130,
            FlightNumber = "2066",
            Destination = "اهواز",
            Price = 29000000,
            DepartureTime = new DateTime(2025, 1, 28, 19, 00, 0),
            Origin = "تهران"
        },
        new Flight
        {
            ArrivalTime = new DateTime(2025, 1, 29, 14, 45, 0),
            AvailableSeats = 100,
            FlightNumber = "2067",
            Destination = "اراک",
            Price = 31000000,
            DepartureTime = new DateTime(2025, 1, 29, 15, 00, 0),
            Origin = "تهران"
        },
        new Flight
        {
            ArrivalTime = new DateTime(2025, 1, 30, 12, 30, 0),
            AvailableSeats = 140,
            FlightNumber = "2068",
            Destination = "قم",
            Price = 32000000,
            DepartureTime = new DateTime(2025, 1, 30, 13, 00, 0),
            Origin = "تهران"
        },
        new Flight
        {
            ArrivalTime = new DateTime(2025, 2, 1, 11, 30, 0),
            AvailableSeats = 150,
            FlightNumber = "2069",
            Destination = "همدان",
            Price = 35000000,
            DepartureTime = new DateTime(2025, 2, 1, 12, 00, 0),
            Origin = "تهران"
        },
        new Flight
        {
            ArrivalTime = new DateTime(2025, 2, 2, 15, 45, 0),
            AvailableSeats = 130,
            FlightNumber = "2070",
            Destination = "بوشهر",
            Price = 34000000,
            DepartureTime = new DateTime(2025, 2, 2, 16, 00, 0),
            Origin = "تهران"
        }
    };
    }
    public static List<Passenger> GetSamplePassengers()
    {
        return new List<Passenger>
    {
        new Passenger
        {
            Email = "lliehos@yahoo.com",
            FullName = "سید سهیل حسینی",
            PassportNumber = "654789",
            PhoneNumber = "9153244965"
        },
        new Passenger
        {
            Email = "sara_karimi@gmail.com",
            FullName = "سارا کریمی",
            PassportNumber = "123456",
            PhoneNumber = "9123456789"
        },
        new Passenger
        {
            Email = "ali.mohammadi@outlook.com",
            FullName = "علی محمدی",
            PassportNumber = "987654",
            PhoneNumber = "9198765432"
        },
        new Passenger
        {
            Email = "niloofar.ahmadi@hotmail.com",
            FullName = "نیلوفر احمدی",
            PassportNumber = "112233",
            PhoneNumber = "9187654321"
        },
        new Passenger
        {
            Email = "parastoo.saeedi@gmail.com",
            FullName = "پرستو سعیدی",
            PassportNumber = "445566",
            PhoneNumber = "9134567890"
        },
        new Passenger
        {
            Email = "amir.nejad@yahoo.com",
            FullName = "امیر نیاید",
            PassportNumber = "998877",
            PhoneNumber = "9112345678"
        },
        new Passenger
        {
            Email = "mahsa.ahmadi@icloud.com",
            FullName = "مهسا احمدی",
            PassportNumber = "667788",
            PhoneNumber = "9145678901"
        },
        new Passenger
        {
            Email = "mohammadreza.saeedi@gmail.com",
            FullName = "محمدرضا سعیدی",
            PassportNumber = "223344",
            PhoneNumber = "9198765430"
        },
        new Passenger
        {
            Email = "fatemeh.jafari@outlook.com",
            FullName = "فاطمه جعفری",
            PassportNumber = "554433",
            PhoneNumber = "9125678902"
        },
        new Passenger
        {
            Email = "mehdi.zeynali@ymail.com",
            FullName = "مهدی زینعلی",
            PassportNumber = "443322",
            PhoneNumber = "9135678903"
        }
    };
    }

}
