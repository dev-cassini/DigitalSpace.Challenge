using DigitalSpace.Challenge.Domain.Entities;

namespace DigitalSpace.Challenge.Domain.Repositories;

public interface ITransactionRepository
{
    Task<Transaction?> GetAsync(Guid id, CancellationToken cancellationToken);
}