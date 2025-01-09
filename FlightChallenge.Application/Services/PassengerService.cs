using AutoMapper;
using FlightChallenge.Application.Dtos;
using FlightChallenge.Application.Interfaces;
using FlightChallenge.Domain.Entities;
using FlightChallenge.Domain.Interfaces;
using FluentValidation;

namespace FlightChallenge.Application.Services
{
    public class PassengerService : IPassengerService
    {
        private readonly IPassengerRepository _passengerRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<PassengerCreateDto> _passengerDtoValidator;
        private readonly IValidator<PassengerUpdateDto> _passengerUpdateDtoValidator;

        public PassengerService(
            IPassengerRepository passengerRepository,
            IMapper mapper,
            IValidator<PassengerCreateDto> passengerDtoValidator,
            IValidator<PassengerUpdateDto> passengerUpdateDtoValidator)
        {
            _passengerRepository = passengerRepository;
            _mapper = mapper;
            _passengerDtoValidator = passengerDtoValidator;
            _passengerUpdateDtoValidator = passengerUpdateDtoValidator;
        }

        public async Task<ServiceResponse<PassengerDto>> AddPassengerAsync(PassengerCreateDto passengerDto)
        {
            var validationResult = await _passengerDtoValidator.ValidateAsync(passengerDto);
            if (!validationResult.IsValid)
            {
                return new ServiceResponse<PassengerDto> { Success = false, Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList() };
            }

            var passengerEntity = _mapper.Map<Passenger>(passengerDto);
            var addedPassenger = await _passengerRepository.AddPassengerAsync(passengerEntity);
            var passengerResponse = _mapper.Map<PassengerDto>(addedPassenger);
            return new ServiceResponse<PassengerDto> { Success = true, Data = passengerResponse };
        }

        public async Task<ServiceResponse<PassengerDto>> UpdatePassengerAsync(int id, PassengerUpdateDto passengerDto)
        {
            var passengerEntity = await _passengerRepository.GetPassengerByIdAsync(id);
            if (passengerEntity == null)
            {
                return new ServiceResponse<PassengerDto> { Success = false, Errors = new List<string>() { "Passenger not found." } };
            }

            var validationResult = await _passengerUpdateDtoValidator.ValidateAsync(passengerDto);
            if (!validationResult.IsValid)
            {
                return new ServiceResponse<PassengerDto> { Success = false,  Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList() };
            }

            _mapper.Map(passengerDto, passengerEntity);
            var updatedPassenger = await _passengerRepository.UpdatePassengerAsync(passengerEntity);
            var passengerResponse = _mapper.Map<PassengerDto>(updatedPassenger);
            return new ServiceResponse<PassengerDto> { Success = true, Data = passengerResponse };
        }

        public async Task<ServiceResponse<PassengerDto>> GetPassengerByIdAsync(int id)
        {
            var passengerEntity = await _passengerRepository.GetPassengerByIdAsync(id);
            if (passengerEntity == null)
            {
                return new ServiceResponse<PassengerDto> { Success = false, Errors = new List<string>() { "Passenger not found." } };
            }

            var passengerResponse = _mapper.Map<PassengerDto>(passengerEntity);
            return new ServiceResponse<PassengerDto> { Success = true, Data = passengerResponse };
        }

        public async Task<ServiceResponse<IEnumerable<PassengerDto>>> GetPassengersAsync(int page = 1, int count = 10)
        {
            var passengers = await _passengerRepository.GetPassengersAsync(page, count);
            var passengerResponse = _mapper.Map<IEnumerable<PassengerDto>>(passengers);
            return new ServiceResponse<IEnumerable<PassengerDto>> { Success = true, Data = passengerResponse };
        }

        public async Task<ServiceResponse<bool>> DeletePassengerAsync(int id)
        {
            var passengerEntity = await _passengerRepository.GetPassengerByIdAsync(id);
            if (passengerEntity == null)
            {
                return new ServiceResponse<bool> { Success = false, Errors =new List<string>() { "Passenger not found." } };
            }

            var isDeleted = await _passengerRepository.DeletePassengerAsync(id);
            return new ServiceResponse<bool> { Success = isDeleted };
        }
    }

}
