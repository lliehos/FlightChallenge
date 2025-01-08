using FlightChallenge.Application.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightChallenge.Application.Validators
{
    public class CreateFlightCommandValidator : AbstractValidator<CreateFlightCommand>
    {
        public CreateFlightCommandValidator()
        {
            RuleFor(x => x.FlightNumber).NotEmpty().WithMessage("Flight code is required.");
            RuleFor(x => x.DepartureTime).GreaterThan(DateTime.Now).WithMessage("Departure time must be in the future.");
        }
    }
}
