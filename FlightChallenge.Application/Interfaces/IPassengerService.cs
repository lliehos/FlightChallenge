using FlightChallenge.Application.Dtos;

namespace FlightChallenge.Application.Interfaces
{
    public interface IPassengerService
    {
        Task<ServiceResponse<PassengerDto>> AddPassengerAsync(PassengerCreateDto passengerDto);
        Task<ServiceResponse<PassengerDto>> UpdatePassengerAsync(int id, PassengerUpdateDto passengerDto);
        Task<ServiceResponse<PassengerDto>> GetPassengerByIdAsync(int id);
        Task<ServiceResponse<IEnumerable<PassengerDto>>> GetPassengersAsync(int page = 1, int count = 10);
        Task<ServiceResponse<bool>> DeletePassengerAsync(int id);
    }
}
