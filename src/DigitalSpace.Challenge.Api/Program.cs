using DigitalSpace.Challenge.Api.BackgroundServices;
using DigitalSpace.Challenge.Infrastructure;
using DigitalSpace.Challenge.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddHostedService<PeriodicRandomVehicleBackgroundService>();

var app = builder.Build();

app.Services
    .MigrateDatabase()
    .SeedData();

app.MapGet("/", () => "Hello World!");

app.Run();