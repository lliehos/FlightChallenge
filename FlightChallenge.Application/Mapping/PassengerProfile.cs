using AutoMapper;
using FlightChallenge.Application.Dtos;
using FlightChallenge.Domain.Entities;

namespace FlightChallenge.Application.Mapping
{
    public class PassengerProfile : Profile
    {
        public PassengerProfile()
        {
            CreateMap<Passenger, PassengerDto>().ReverseMap();
            CreateMap<PassengerCreateDto, Passenger>().ReverseMap();
            CreateMap<PassengerUpdateDto, Passenger>().ReverseMap();
        }
    }
}
