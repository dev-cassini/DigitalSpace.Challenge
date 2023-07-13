using DigitalSpace.Challenge.Application;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalSpace.Challenge.Infrastructure.Messaging.MediatR;

internal static class ServiceCollectionExtensions
{
    internal static void AddMediatR(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblyContaining<ApplicationMarker>();
        });
    }
}