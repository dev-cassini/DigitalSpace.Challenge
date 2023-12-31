using DigitalSpace.Challenge.Infrastructure.Messaging.MediatR;
using DigitalSpace.Challenge.Infrastructure.Persistence;
using DigitalSpace.Challenge.Infrastructure.Queries;
using DigitalSpace.Challenge.Infrastructure.Scheduling.Hangfire;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalSpace.Challenge.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection serviceCollection, 
        IConfiguration configuration)
    {
        serviceCollection.AddPersistence(configuration);
        serviceCollection.AddRepositories();
        serviceCollection.AddSeedDataService();
        serviceCollection.AddQueries();
        serviceCollection.AddMediatR();
        serviceCollection.AddHangfire(configuration);
        
        return serviceCollection;
    }
}