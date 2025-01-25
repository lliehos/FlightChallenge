using AutoMapper;
using FlightChallenge.Application.Dtos;
using FlightChallenge.Domain.Entities;

namespace FlightChallenge.Application.Mapping
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingDto>().ReverseMap();
            CreateMap<BookingCrateDto, Booking>().ReverseMap();
            CreateMap<BookingUpdateDto, Booking>().ReverseMap();
        }
    }
}
