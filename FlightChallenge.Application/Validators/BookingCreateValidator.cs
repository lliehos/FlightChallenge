using FlightChallenge.Application.Dtos;
using FluentValidation;

namespace FlightChallenge.Application.Validators
{
    public class BookingCreateValidator : AbstractValidator<BookingCrateDto>
    {
        public BookingCreateValidator()
        {
            RuleFor(x => x.FlightId).GreaterThan(0).WithMessage("Flight ID must be greater than zero.");
            RuleFor(x => x.PassengerId).GreaterThan(0).WithMessage("Passenger ID must be greater than zero.");
            RuleFor(x => x.BookingDate).GreaterThan(DateTime.Now).WithMessage("Booking date must be in the future.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than zero.");
            RuleFor(x => x.SeatNumber).NotNull().WithMessage("Seat Number is required.");
        }
    }
}
