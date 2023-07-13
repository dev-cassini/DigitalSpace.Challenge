using DigitalSpace.Challenge.Infrastructure.Persistence.Databases.Postgres;
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
}