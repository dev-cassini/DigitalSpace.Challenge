using DigitalSpace.Challenge.Application.Queries.Transactions;
using DigitalSpace.Challenge.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DigitalSpace.Challenge.Infrastructure.Queries.Transactions;

public class GetSumOfLitresDispensedQueryHandler : IRequestHandler<GetSumOfLitresDispensedQuery, int>
{
    private readonly ChallengeDbContext _dbContext;

    public GetSumOfLitresDispensedQueryHandler(ChallengeDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<int> Handle(GetSumOfLitresDispensedQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Transactions.AsNoTracking()
            .SumAsync(x => x.NumberOfLitresDispensed, cancellationToken);
    }
}