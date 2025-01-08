using FlightChallenge.Application.Interfaces;
using FlightChallenge.Application.Services;
using FlightChallenge.Domain.Interfaces;
using FlightChallenge.Filters;
using FlightChallenge.Infrastructure.Repositories;
using FlightChallenge.Middlewares;
using Microsoft.EntityFrameworkCore;
using Serilog;


try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Host.UseSerilog((context, config) =>
    {
        config.ReadFrom.Configuration(context.Configuration);
    });
    builder.Services.AddControllers(options =>
    {
        options.Filters.Add<ExceptionFilter>();
    });
    Log.Information("Starting up the application");

    //Add Services
    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
    builder.Services.AddScoped<IFlightRepository, FlightRepository>();
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddScoped<IFlightRepository, FlightRepository>();
    builder.Services.AddScoped<IFlightService, FlightService>();
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
