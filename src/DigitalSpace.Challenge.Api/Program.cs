using DigitalSpace.Challenge.Api.BackgroundServices;
using DigitalSpace.Challenge.Infrastructure;
using DigitalSpace.Challenge.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddInfrastructure(builder.Configuration)
    .AddHostedService<PeriodicRandomVehicleBackgroundService>();

var app = builder.Build();

app.Services.MigrateDatabase();
if (app.Environment.IsDevelopment())
{
    app.Services.SeedData();
}

if (app.Environment.IsProduction() is false)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await app.RunAsync();