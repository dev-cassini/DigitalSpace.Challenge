using DigitalSpace.Challenge.Infrastructure.Messaging.MediatR;
using DigitalSpace.Challenge.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalSpace.Challenge.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(
        this IServiceCollection serviceCollection, 
        IConfiguration configuration)
    {
        serviceCollection.AddPersistence(configuration);
        serviceCollection.AddRepositories();
        serviceCollection.AddSeedDataService();
        serviceCollection.AddMediatR();
    }
}