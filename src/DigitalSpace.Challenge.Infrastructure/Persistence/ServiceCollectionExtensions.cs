using DigitalSpace.Challenge.Domain.Repositories;
using DigitalSpace.Challenge.Infrastructure.Persistence.Data;
using DigitalSpace.Challenge.Infrastructure.Persistence.Databases.Postgres;
using DigitalSpace.Challenge.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalSpace.Challenge.Infrastructure.Persistence;

internal static class ServiceCollectionExtensions
{
    internal static void AddPersistence(
        this IServiceCollection serviceCollection, 
        IConfiguration configuration)
    {
        serviceCollection.AddPostgresDatabase<ChallengeDbContext>(configuration);
    }
    
    internal static void AddRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IForecourtRepository, EfForecourtRepository>();
        serviceCollection.AddScoped<IVehicleRepository, EfVehicleRepository>();
        serviceCollection.AddScoped<ITransactionRepository, EfTransactionRepository>();
    }
    
    internal static void AddSeedDataService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<SeedDataService>();
    }
}