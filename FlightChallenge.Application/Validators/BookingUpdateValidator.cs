using FlightChallenge.Application.Dtos;
using FlightChallenge.Domain.Interfaces;
using FluentValidation;

namespace FlightChallenge.Application.Validators
{
    public class BookingUpdateValidator : AbstractValidator<BookingUpdateDto>
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IBookingRepository _bookingRepository;
        public BookingUpdateValidator(IFlightRepository flightRepository, IBookingRepository bookingRepository)
        {
            _flightRepository = flightRepository;
            _bookingRepository = bookingRepository;
            RuleFor(x => x.FlightId).GreaterThan(0).WithMessage("Flight ID must be greater than zero.");
            RuleFor(x => x.PassengerId).GreaterThan(0).WithMessage("Passenger ID must be greater than zero.");
            RuleFor(x => x.BookingDate).GreaterThan(DateTime.Now).WithMessage("Booking date must be in the future.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than zero.");
            RuleFor(x => x.SeatNumber).NotNull().WithMessage("Seat Number is required.").GreaterThan(0).WithMessage("SeatNumber must be greater than zero.");
            RuleFor(x => x).MustAsync(async (booking, cancellation) =>
                 await HasAvailableSeat(booking.Id,booking.FlightId, booking.SeatNumber))
                 .WithMessage("The selected seat is not available.");
            RuleFor(x => x).MustAsync(async (booking, cancellation) =>
                 await HasValidPrice(booking.FlightId, booking.Price))
                 .WithMessage("Price is invalid.");
        }
        private async Task<bool> HasAvailableSeat(int id,int flightId, int seatNumber)
        {
            var flight = await _flightRepository.GetFlightByIdAsync(flightId);
            if (flight == null)
            {
                return false;
            }
            if (seatNumber < 1 || seatNumber > flight.AvailableSeats)
            {
                return false;
            }

            var currentFlightBookingLists = await _bookingRepository.GetBookingsByFlightIdAsync(flightId);
            return currentFlightBookingLists != null && !currentFlightBookingLists.Any(p => p.SeatNumber == seatNumber && p.Id!=id);
        }
        private async Task<bool> HasValidPrice(int flightId, decimal price)
        {
            var flight = await _flightRepository.GetFlightByIdAsync(flightId);
            if (flight == null)
            {
                return false;
            }
            return flight.Price == price;
        }
    }
}
