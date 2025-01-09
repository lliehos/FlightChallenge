using FlightChallenge.Application.Dtos;

namespace FlightChallenge.Application.Interfaces
{
    public interface IBookingService
    {
        Task<ServiceResponse<BookingDto>> AddBookingAsync(BookingCrateDto bookingDto);
        Task<ServiceResponse<BookingDto>> UpdateBookingAsync(int id, BookingUpdateDto bookingUpdateDto);
        Task<ServiceResponse<bool>> DeleteBookingAsync(int id);
        Task<ServiceResponse<BookingDto>> GetBookingByIdAsync(int id);
        Task<ServiceResponse<IEnumerable<BookingDto>>> GetBookingsByFlightIdAsync(int flightId, int page = 1, int count = 10);
        Task<ServiceResponse<IEnumerable<BookingDto>>> GetBookingsByPassengerIdAsync(int passengerId, int page = 1, int count = 10);
    }
}
