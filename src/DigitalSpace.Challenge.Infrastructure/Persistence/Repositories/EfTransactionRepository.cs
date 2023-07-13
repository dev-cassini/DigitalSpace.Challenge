using DigitalSpace.Challenge.Domain.Entities;
using DigitalSpace.Challenge.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DigitalSpace.Challenge.Infrastructure.Persistence.Repositories;

public class EfTransactionRepository : ITransactionRepository
{
    private readonly ChallengeDbContext _dbContext;

    public EfTransactionRepository(ChallengeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Transaction?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Transactions
            .Include(x => x.Vehicle)
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}