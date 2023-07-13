using DigitalSpace.Challenge.Infrastructure;
using DigitalSpace.Challenge.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.Services
    .MigrateDatabase()
    .SeedData();

app.MapGet("/", () => "Hello World!");

app.Run();