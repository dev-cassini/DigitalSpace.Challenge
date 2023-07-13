using DigitalSpace.Challenge.Application.Queries.Transactions;
using DigitalSpace.Challenge.Infrastructure.Queries.Transactions;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalSpace.Challenge.Infrastructure.Queries;

internal static class ServiceCollectionExtensions
{
    internal static void AddQueries(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IRequestHandler<GetSumOfLitresDispensedQuery, int>, GetSumOfLitresDispensedQueryHandler>();
    }
}