using FlightChallenge.Application.Dtos;
using FlightChallenge.Application.Interfaces;
using FlightChallenge.Application.Services;
using FlightChallenge.Application.Validators;
using FlightChallenge.Domain.Interfaces;
using FlightChallenge.Filters;
using FlightChallenge.Infrastructure.Repositories;
using FlightChallenge.Middlewares;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;


try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog((context, config) =>
    {
        config.ReadFrom.Configuration(context.Configuration);
    });
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", builder =>
        {
            builder.AllowAnyOrigin() 
                   .AllowAnyMethod() 
                   .AllowAnyHeader();
        });
    });
    builder.Services.AddControllers(options =>
    {
        options.Filters.Add<ExceptionFilter>();
    });
    Log.Information("Starting up the application");

    builder.Services.AddMemoryCache();
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
    builder.Services.AddScoped<IFlightRepository, FlightRepository>();
    builder.Services.AddScoped<IFlightService, FlightService>();
    builder.Services.AddScoped<IPassengerRepository, PassengerRepository>();
    builder.Services.AddScoped<IPassengerService, PassengerService>();
    builder.Services.AddScoped<IBookingService, BookingService>();
    builder.Services.AddScoped<IBookingRepository, BookingRepository>();

    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    builder.Services.AddValidatorsFromAssemblyContaining<Program>();
    builder.Services.AddValidatorsFromAssemblyContaining<CreateFlightDtoValidator>();
    builder.Services.AddValidatorsFromAssemblyContaining<UpdateFlightDtoValidator>();
    builder.Services.AddValidatorsFromAssemblyContaining<BookingCreateValidator>();
    builder.Services.AddValidatorsFromAssemblyContaining<BookingUpdateValidator>();
    builder.Services.AddValidatorsFromAssemblyContaining<PassengerCreateDtoValidator>();
    builder.Services.AddValidatorsFromAssemblyContaining<PassengerUpdateDtoValidator>();

    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Flight API",
            Version = "v1",
            Description = "API for flight booking and management"
        });
        options.EnableAnnotations();
    });

    var app = builder.Build();
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<AppDbContext>();
        await DatabaseSeeder.SeedAsync(context);
    }
    app.UseMiddleware<ExceptionMiddleware>();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseMiddleware<LoggingMiddleware>();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "The application failed to start correctly");
}
finally
{
    Log.CloseAndFlush();
}
