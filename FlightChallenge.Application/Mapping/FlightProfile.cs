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
}
