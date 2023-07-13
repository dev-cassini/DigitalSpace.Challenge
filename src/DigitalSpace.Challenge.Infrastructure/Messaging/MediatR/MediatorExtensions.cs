using DigitalSpace.Challenge.Domain.Common;
using DigitalSpace.Challenge.Infrastructure.Persistence;
using MediatR;

namespace DigitalSpace.Challenge.Infrastructure.Messaging.MediatR;

internal static class MediatorExtensions
{
    internal static async Task DispatchDomainEventsAsync(
        this IMediator mediator, 
        ChallengeDbContext dbContext)
    {
        var entityEntries = dbContext.ChangeTracker
            .Entries<Entity>()
            .Where(x => x.Entity.DomainEvents.Any()).ToList();

        foreach (var entityEntry in entityEntries)
        {
            foreach (var domainEvent in entityEntry.Entity.DomainEvents.ToList())
            {
                entityEntry.Entity.RemoveDomainEvent(domainEvent);
                await mediator.Publish(domainEvent);
            }
        }
    }
}