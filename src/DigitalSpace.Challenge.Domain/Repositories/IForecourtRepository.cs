using DigitalSpace.Challenge.Domain.Entities;

namespace DigitalSpace.Challenge.Domain.Repositories;

public interface IForecourtRepository
{
    Task<Forecourt> GetAsync(CancellationToken cancellationToken);
    Task SaveChangesAsync(CancellationToken cancellationToken);
}