
# Travel Booking API

## Overview
This is a simple Travel Booking API built using .NET 8, Entity Framework Core, and SQLite. The API allows for managing flights, passengers, and bookings. It includes the basic CRUD operations and error handling, logging, and validation.

## Project Structure
- **Entities**: Flight, Passenger, Booking
- **Endpoints**:
  - **Flight Management**:
    - Create a new flight.
    - Retrieve flights with optional filters (e.g., by origin, destination, date).
    - Update available seats for a flight.
  - **Booking/Reservation**:
    - Create a new booking for a passenger if seats are available.
    - Retrieve all bookings for a specific flight.
- **Logging**: Serilog for logging API requests and errors.
- **Error Handling**: Custom exception filter with JSON error response.
- **API Versioning**: The API supports versioning.

## Requirements
- .NET 8 or later
- SQLite Database
- Entity Framework Core (Code First)

## Setup Instructions

### Prerequisites
- Install [.NET SDK 8](https://dotnet.microsoft.com/download/dotnet/8.0)
- Install [SQLite](https://www.sqlite.org/download.html)

### 1. Clone the Repository
Clone this repository to your local machine.

