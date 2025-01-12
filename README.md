# Travel Booking API

## Overview
This is a simple Travel Booking API built using .NET 8, Entity Framework Core, and SQLite. The API allows for managing flights, passengers, and bookings. It includes the basic CRUD operations and error handling, logging, validation, caching, and API documentation using Swagger.

## Project Structure

- **Entities**: Flight, Passenger, Booking
- **Endpoints**:
  - **Flight Management**:
    - Create a new flight.
    - Retrieve flights with optional filters (e.g., by origin, destination, date).
    - Retrieve flight details by ID.
    - Update available seats for a flight.
    - Delete a flight.
  - **Passenger Management**:
    - Create a new passenger.
    - Retrieve passenger details.
    - Update passenger information.
    - Delete a passenger.
  - **Booking/Reservation**:
    - Create a new booking for a passenger if seats are available.
    - Retrieve all bookings for a specific flight.
    - Delete a booking.
- **Logging**: Serilog for logging API requests and errors.
- **Error Handling**: Custom exception filter with JSON error response.
- **Caching**: In-memory caching for frequently accessed data.
- **API Versioning**: The API supports versioning.
- **API Documentation**: Swagger for generating API documentation.

## Requirements

- .NET 8 or later
- SQLite Database
- Entity Framework Core (Code First)
- Serilog
- FluentValidation
- Moq (for testing)
- Swagger

## Setup Instructions

### Prerequisites

- Install [.NET SDK 8](https://dotnet.microsoft.com/download/dotnet/8.0)
- Install [SQLite](https://www.sqlite.org/download.html)

### 1. Clone the Repository

Clone this repository to your local machine.

```bash
git clone https://github.com/lliehos/FlightChallenge.git
cd FlightChallenge
```

### 2. Set Up the Database

Run the following commands to apply migrations and create the database.

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 3. Run the Application

Start the API by running the following command:

```bash
dotnet run
```

### 4. Access Swagger UI

Once the application is running, navigate to `https://localhost:5001/swagger` to view the API documentation and test the endpoints.

## API Endpoints

### Flight Management

#### Create Flight

```http
POST /flights
```

- **Summary**: Create a new flight.
- **Request Body**: `FlightCreateDto`

#### Get Flights

```http
GET /flights
```

- **Summary**: Retrieve flights with optional filters.
- **Query Parameters**: `origin`, `destination`, `departureDate`, `page`, `count`

#### Get Flight by ID

```http
GET /flights/{id}
```

- **Summary**: Fetches flight details using the unique flight ID.

#### Update Flight

```http
PUT /flights/{id}
```

- **Summary**: Update the details of a flight.
- **Request Body**: `FlightUpdateDto`

#### Delete Flight

```http
DELETE /flights/{id}
```

- **Summary**: Delete a flight.

### Passenger Management

#### Create Passenger

```http
POST /passengers
```

- **Summary**: Create a new passenger.
- **Request Body**: `PassengerCreateDto`

#### Get Passenger

```http
GET /passengers/{id}
```

- **Summary**: Retrieve passenger details by ID.

#### Update Passenger

```http
PUT /passengers/{id}
```

- **Summary**: Update the details of a passenger.
- **Request Body**: `PassengerUpdateDto`

#### Delete Passenger

```http
DELETE /passengers/{id}
```

- **Summary**: Delete a passenger.

### Booking Management

#### Create Booking

```http
POST /bookings
```

- **Summary**: Create a new booking for a passenger if seats are available.
- **Request Body**: `BookingCreateDto`

#### Get Bookings by Flight

```http
GET /bookings/flight/{flightId}
```

- **Summary**: Retrieve all bookings for a specific flight.

#### Delete Booking

```http
DELETE /bookings/{id}
```

- **Summary**: Delete a booking.

## Logging

- The application uses **Serilog** for logging requests and errors.

## Caching

- In-memory caching is implemented for frequently accessed data using `IMemoryCache`.

## Testing

- Unit tests are implemented using **Moq** for mocking dependencies and **xUnit** for test execution.

## API Documentation

- The API uses **Swagger** for documentation. You can access it at `https://localhost:5001/swagger` after running the application.

## License

This project is licensed under the MIT License.

