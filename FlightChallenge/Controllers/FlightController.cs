﻿using FlightChallenge.Application.Dtos;
using FlightChallenge.Application.Interfaces;
using FlightChallenge.Application.Validators;
using FlightChallenge.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FlightChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlight(int id)
        {
            var flight = await _flightService.GetFlightByIdAsync(id);
            if (flight == null)
                return NotFound();

            return Ok(flight);
        }

        [HttpGet]
        public async Task<IActionResult> GetFlights([FromQuery] string? origin, [FromQuery] string? destination, [FromQuery] DateTime? departureDate)
        {
            var flights = await _flightService.GetFlightsAsync(origin, destination, departureDate);
            return Ok(flights);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFlight([FromBody] FlightCreateDto flight)
        {
            var createdFlight = await _flightService.AddFlightAsync(flight);
            return CreatedAtAction(nameof(GetFlights), createdFlight.Data is FlightDto? new { id = createdFlight.Data?.Id }:null, createdFlight);
        }
    }
}
