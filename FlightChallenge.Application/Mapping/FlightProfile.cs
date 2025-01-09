using AutoMapper;
using FlightChallenge.Application.Dtos;
using FlightChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FlightChallenge.Application.Mapping
{
    public class FlightProfile : Profile
    {
        public FlightProfile()
        {
            CreateMap<Flight, FlightDto>().ReverseMap();
            CreateMap<FlightCreateDto, Flight>().ReverseMap();
            CreateMap<FlightUpdateDto, Flight>().ReverseMap();
        }
    }
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingDto>().ReverseMap();
            CreateMap<BookingCrateDto, Booking>().ReverseMap();
            CreateMap<BookingUpdateDto, Booking>().ReverseMap();
        }
    }
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
