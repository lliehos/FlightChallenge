using FlightChallenge.Application.Dtos;
using FlightChallenge.Application.Interfaces;
using FlightChallenge.Controllers;
using FlightChallenge.Domain.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.FlightChallenge.Controllers
{
    public class FlightControllerTests
    {
        private readonly Mock<IFlightService> _flightServiceMock;
        private readonly FlightController _controller;

        public FlightControllerTests()
        {
            _flightServiceMock = new Mock<IFlightService>();
            _controller = new FlightController(_flightServiceMock.Object);
        }

        [Fact]
        public async Task AddFlightAsync_ShouldReturnCreatedResult_WhenFlightIsValid()
        {
            var flightCreateDto = new FlightCreateDto
            {
                FlightNumber = "ABC123",
                Origin = "NYC",
                Destination = "LAX",
                DepartureTime = DateTime.Now.AddHours(1),   
                ArrivalTime = DateTime.Now.AddHours(3), 
                AvailableSeats = 100,
                Price = 199.99m
            };
            Console.WriteLine(flightCreateDto);
            var flightDto = new FlightDto
            {
                Id = 24,
                FlightNumber = "ABC123",
                Origin = "NYC",
                Destination = "LAX",
                DepartureTime = flightCreateDto.DepartureTime,
                ArrivalTime = flightCreateDto.ArrivalTime,
                AvailableSeats = flightCreateDto.AvailableSeats,
                Price = flightCreateDto.Price
            };
            Console.WriteLine(flightDto);
            var response = new ServiceResponse<FlightDto>
            {
                Data = flightDto,
                Success = true,
                Errors = new List<string>()   
            };
            Console.WriteLine(response);
            _flightServiceMock.Setup(s => s.AddFlightAsync(flightCreateDto))
                .ReturnsAsync(response);
            Console.WriteLine("tsetstarted");
            var result = await _controller.CreateFlight(flightCreateDto); 
            Console.WriteLine(result);
            result.Should().BeOfType<CreatedAtActionResult>();
            var createdFlight = (result as CreatedAtActionResult).Value as ServiceResponse<FlightDto>;
            Console.WriteLine(createdFlight);
            createdFlight.Should().NotBeNull();
            createdFlight.Data.Should().BeEquivalentTo(flightDto);
        }
    }
}
