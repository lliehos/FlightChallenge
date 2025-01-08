using FlightChallenge.Application.Dtos;
using FluentValidation;

namespace FlightChallenge.Application.Validators
{
    public class CreateFlightDtoValidator : AbstractValidator<FlightCreateDto>
    {
        public CreateFlightDtoValidator()
        {
            RuleFor(x => x.FlightNumber).NotEmpty().WithMessage("Flight code is required.");
            RuleFor(x => x.DepartureTime).GreaterThan(DateTime.Now).WithMessage("Departure time must be in the future.");
        }
    }
}
