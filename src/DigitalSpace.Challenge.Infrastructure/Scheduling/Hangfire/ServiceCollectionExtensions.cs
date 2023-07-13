using DigitalSpace.Challenge.Application.Scheduling;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalSpace.Challenge.Infrastructure.Scheduling.Hangfire;

internal static class ServiceCollectionExtensions
{
    internal static void AddHangfire(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        var postgresConnectionString = configuration.GetConnectionString("Postgres");
        serviceCollection.AddHangfire(x =>
        {
            x.UsePostgreSqlStorage(postgresConnectionString);
        });
        
        serviceCollection.AddHangfireServer(options =>
        {
            options.SchedulePollingInterval = TimeSpan.FromMilliseconds(500);
        });
        
        serviceCollection.AddScoped<IScheduler, HangfireScheduler>();
    }
}