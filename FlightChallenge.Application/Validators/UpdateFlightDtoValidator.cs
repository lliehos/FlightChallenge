using FlightChallenge.Application.Dtos;
using FluentValidation;

namespace FlightChallenge.Application.Validators
{
    public class UpdateFlightDtoValidator : AbstractValidator<FlightUpdateDto>
    {
        public UpdateFlightDtoValidator()
        {
            RuleFor(x => x.FlightNumber).NotEmpty().WithMessage("Flight code is required.");
            RuleFor(x => x.DepartureTime).GreaterThan(DateTime.Now).WithMessage("Departure time must be in the future.");
            RuleFor(x => x.AvailableSeats).GreaterThan(0).WithMessage("AvailableSeats must be greater than zero.");
        }
    }
}
