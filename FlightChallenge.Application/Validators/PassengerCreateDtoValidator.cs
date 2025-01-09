using FlightChallenge.Application.Dtos;
using FluentValidation;

namespace FlightChallenge.Application.Validators
{
    public class PassengerCreateDtoValidator : AbstractValidator<PassengerCreateDto>
    {
        public PassengerCreateDtoValidator()
        {
            RuleFor(p => p.FullName).NotEmpty().WithMessage("Full Name is required.");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Email is required.").EmailAddress().WithMessage("Invalid email format.");
            RuleFor(p => p.PhoneNumber).NotEmpty().WithMessage("Phone Number is required.");
            RuleFor(p => p.PassportNumber).NotEmpty().WithMessage("Passport Number is required.");
        }
    }
}
