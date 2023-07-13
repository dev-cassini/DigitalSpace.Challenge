using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalSpace.Challenge.Infrastructure.Persistence.Databases.Postgres;

internal static class ServiceCollectionExtensions
{
    internal static void AddPostgresDatabase<TDbContext>(
        this IServiceCollection serviceCollection,
        IConfiguration configuration) where TDbContext : DbContext
    {
        serviceCollection.AddDbContext<TDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("Postgres"));
        });
    }
}