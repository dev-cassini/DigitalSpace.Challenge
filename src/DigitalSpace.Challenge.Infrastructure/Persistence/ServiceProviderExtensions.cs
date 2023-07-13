using DigitalSpace.Challenge.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalSpace.Challenge.Infrastructure.Persistence;

public static class ServiceProviderExtensions
{
    public static IServiceProvider MigrateDatabase(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<ChallengeDbContext>();
        dbContext.Database.Migrate();

        return serviceProvider;
    }
    
    public static IServiceProvider SeedData(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var seedDataService = scope.ServiceProvider.GetRequiredService<SeedDataService>();
        seedDataService.ClearDb();
        seedDataService.Execute();

        return serviceProvider;
    }
}