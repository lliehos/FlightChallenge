using FlightChallenge.Application.Dtos;

namespace FlightChallenge.Application.Interfaces
{
    public interface IBookingService
    {
        Task<ServiceResponse<BookingCrateDto>> AddBookingAsync(BookingCrateDto bookingDto);
        Task<ServiceResponse<BookingCrateDto>> UpdateBookingAsync(int id, BookingUpdateDto bookingUpdateDto);
        Task<ServiceResponse<bool>> DeleteBookingAsync(int id);
        Task<ServiceResponse<BookingCrateDto>> GetBookingByIdAsync(int id);
        Task<ServiceResponse<IEnumerable<BookingCrateDto>>> GetBookingsByFlightIdAsync(int flightId, int page = 1, int count = 10);
        Task<ServiceResponse<IEnumerable<BookingCrateDto>>> GetBookingsByPassengerIdAsync(int passengerId, int page = 1, int count = 10);
    }
}
