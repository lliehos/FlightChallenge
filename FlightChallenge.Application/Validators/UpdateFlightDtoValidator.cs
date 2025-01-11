using FlightChallenge.Application.Dtos;
using FlightChallenge.Domain.Interfaces;
using FlightChallenge.Infrastructure.Repositories;
using FluentValidation;

namespace FlightChallenge.Application.Validators
{
    public class UpdateFlightDtoValidator : AbstractValidator<FlightUpdateDto>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IFlightRepository _flightRepository;

        public UpdateFlightDtoValidator(IBookingRepository bookingRepository, IFlightRepository flightRepository)
        {
            _bookingRepository = bookingRepository;
            RuleFor(x => x.FlightNumber).NotEmpty().WithMessage("Flight code is required.");
            RuleFor(x => x.DepartureTime).GreaterThan(DateTime.Now).WithMessage("Departure time must be in the future.");
            RuleFor(x => x.AvailableSeats).GreaterThan(0).WithMessage("AvailableSeats must be greater than zero.");
            RuleFor(x => x).MustAsync(async (flight, cancellation) =>
             await CanEditSeatState(flight.Id, flight.AvailableSeats))
             .WithMessage("Can't update flight that have booking.");
            _flightRepository = flightRepository;
        }
        private async Task<bool> CanEditSeatState(int flightId,int? asvailableSeats)
        {
            var hasBooking= !await _bookingRepository.AnyBookingForFlightAsync(flightId);
            var baseFlight=await _flightRepository.GetFlightByIdAsync(flightId);
            return (hasBooking && baseFlight.AvailableSeats == asvailableSeats) || !hasBooking;

        }
    }
}
