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
        public async Task CreateFlight_ShouldReturnOk_WhenFlightIsCreated()
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
            var response = new ServiceResponse<FlightDto>
            {
                Data = flightDto,
                Success = true,
                Errors = new List<string>()   
            };
            _flightServiceMock.Setup(s => s.AddFlightAsync(flightCreateDto))
                .ReturnsAsync(response);
            var result = await _controller.CreateFlight(flightCreateDto); 
            result.Should().BeOfType<OkObjectResult>();
            var createdFlight = (result as OkObjectResult).Value as ServiceResponse<FlightDto>;
            createdFlight.Should().NotBeNull();
            createdFlight.Data.Should().BeEquivalentTo(flightDto);
        }
        [Fact]
        public async Task GetFlight_ShouldReturnOk_WhenFlightExists()
        {
            var flightId = 16;
            var response = new FlightDto { Id = flightId, FlightNumber = "ABC123" };;
            _flightServiceMock.Setup(s => s.GetFlightByIdAsync(flightId)).ReturnsAsync(response);
            var result = await _controller.GetFlight(flightId);
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task GetFlight_ShouldReturnNotFound_WhenFlightDoesNotExist()
        {
            _flightServiceMock.Setup(s => s.GetFlightByIdAsync(100));
            var result = await _controller.GetFlight(100);
            result.Should().BeOfType<NotFoundResult>();
        }


        [Fact]
        public async Task CreateFlight_ShouldReturnBadRequest_WhenFlightCreationFails()
        {
            var flightCreateDto = new FlightCreateDto { FlightNumber = "ABC123" };
            var response = new ServiceResponse<FlightDto> { Success = false, Errors = new List<string> { "Validation failed" } };

            _flightServiceMock.Setup(s => s.AddFlightAsync(flightCreateDto)).ReturnsAsync(response);

            var result = await _controller.CreateFlight(flightCreateDto);

            result.Should().BeOfType<BadRequestObjectResult>();
        }

    }
}
