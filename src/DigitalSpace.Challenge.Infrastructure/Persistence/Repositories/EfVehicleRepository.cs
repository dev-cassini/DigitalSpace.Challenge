using DigitalSpace.Challenge.Domain.Entities.Vehicles;
using DigitalSpace.Challenge.Domain.Repositories;

namespace DigitalSpace.Challenge.Infrastructure.Persistence.Repositories;

public class EfVehicleRepository : IVehicleRepository
{
    private readonly ChallengeDbContext _dbContext;

    public EfVehicleRepository(ChallengeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Vehicle vehicle, CancellationToken cancellationToken)
    {
        await _dbContext.Vehicles.AddAsync(vehicle, cancellationToken);
    }
}