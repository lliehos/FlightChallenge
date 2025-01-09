using AutoMapper;
using FlightChallenge.Application.Dtos;
using FlightChallenge.Application.Interfaces;
using FlightChallenge.Domain.Entities;
using FlightChallenge.Domain.Interfaces;
using FluentValidation;

namespace FlightChallenge.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IFlightRepository _flightRepository;
        private readonly IPassengerRepository _passengerRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<BookingCrateDto> _bookingValidator;
        private readonly IValidator<BookingUpdateDto> _bookingUpdateValidator;

        public BookingService(
            IBookingRepository bookingRepository,
            IFlightRepository flightRepository,
            IPassengerRepository passengerRepository,
            IMapper mapper,
            IValidator<BookingCrateDto> bookingValidator,
            IValidator<BookingUpdateDto> bookingUpdateValidator)
        {
            _bookingRepository = bookingRepository;
            _flightRepository = flightRepository;
            _passengerRepository = passengerRepository;
            _mapper = mapper;
            _bookingValidator = bookingValidator;
            _bookingUpdateValidator = bookingUpdateValidator;
        }

        public async Task<ServiceResponse<BookingDto>> AddBookingAsync(BookingCrateDto bookingDto)
        {
            var validationResult = await _bookingValidator.ValidateAsync(bookingDto);
            var response = new ServiceResponse<BookingDto>();

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Errors.AddRange(validationResult.Errors.Select(x => x.ErrorMessage));
                return response;
            }

            var flight = await _flightRepository.GetFlightByIdAsync(bookingDto.FlightId);
            if (flight == null)
            {
                response.Success = false;
                response.Errors.Add("Flight not found.");
                return response;
            }

            var passenger = await _passengerRepository.GetPassengerByIdAsync(bookingDto.PassengerId);
            if (passenger == null)
            {
                response.Success = false;
                response.Errors.Add("Passenger not found.");
                return response;
            }

            var booking = _mapper.Map<Booking>(bookingDto);
            booking.BookingDate = DateTime.Now; // Set the booking date

            var addedBooking = await _bookingRepository.AddBookingAsync(booking);
            response.Data = _mapper.Map<BookingDto>(addedBooking);

            return response;
        }

        public async Task<ServiceResponse<BookingDto>> UpdateBookingAsync(int id, BookingUpdateDto bookingUpdateDto)
        {
            var validationResult = await _bookingUpdateValidator.ValidateAsync(bookingUpdateDto);
            var response = new ServiceResponse<BookingDto>();

            if (!validationResult.IsValid)
            {
                response.Errors.AddRange(validationResult.Errors.Select(x => x.ErrorMessage));
                return response;
            }

            var bookingEntity = await _bookingRepository.GetBookingByIdAsync(id);
            if (bookingEntity == null)
            {
                response.Errors.Add("Booking not found.");
                return response;
            }

            _mapper.Map(bookingUpdateDto, bookingEntity);
            var updatedBooking = await _bookingRepository.UpdateBookingAsync(bookingEntity);
            response.Data = _mapper.Map<BookingDto>(updatedBooking);

            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteBookingAsync(int id)
        {
            var response = new ServiceResponse<bool>();

            var bookingEntity = await _bookingRepository.GetBookingByIdAsync(id);
            if (bookingEntity == null)
            {
                response.Errors.Add("Booking not found.");
                return response;
            }

            await _bookingRepository.DeleteBookingAsync(id);
            response.Data = true;

            return response;
        }

        public async Task<ServiceResponse<BookingDto>> GetBookingByIdAsync(int id)
        {
            var response = new ServiceResponse<BookingDto>();

            var booking = await _bookingRepository.GetBookingByIdAsync(id);
            if (booking == null)
            {
                response.Errors.Add("Booking not found.");
                return response;
            }

            response.Data = _mapper.Map<BookingDto>(booking);
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<BookingDto>>> GetBookingsByFlightIdAsync(int flightId, int page = 1, int count = 10)
        {
            var response = new ServiceResponse<IEnumerable<BookingDto>>();

            var bookings = await _bookingRepository.GetBookingsByFlightIdAsync(flightId, page, count);
            response.Data = _mapper.Map<IEnumerable<BookingDto>>(bookings);

            return response;
        }

        public async Task<ServiceResponse<IEnumerable<BookingDto>>> GetBookingsByPassengerIdAsync(int passengerId, int page = 1, int count = 10)
        {
            var response = new ServiceResponse<IEnumerable<BookingDto>>();

            var bookings = await _bookingRepository.GetBookingsByPassengerIdAsync(passengerId, page, count);
            response.Data = _mapper.Map<IEnumerable<BookingDto>>(bookings);

            return response;
        }
    }

}
