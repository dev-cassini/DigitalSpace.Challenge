using DigitalSpace.Challenge.Domain.Entities;
using DigitalSpace.Challenge.Domain.Enums;
using DigitalSpace.Challenge.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DigitalSpace.Challenge.Infrastructure.Persistence.Repositories;

public class EfForecourtRepository : IForecourtRepository
{
    private readonly ChallengeDbContext _dbContext;

    public EfForecourtRepository(ChallengeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Forecourt> GetAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Forecourts
            .Include(x => x.Lanes)
            .ThenInclude(x => x.Pumps)
            .Include(x => x.Transactions.Where(y => y.Status == TransactionStatus.Filling))
            .ThenInclude(x => x.Vehicle)
            .SingleAsync(cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}