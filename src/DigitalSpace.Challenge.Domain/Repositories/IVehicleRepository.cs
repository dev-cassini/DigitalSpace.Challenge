using DigitalSpace.Challenge.Domain.Entities.Vehicles;

namespace DigitalSpace.Challenge.Domain.Repositories;

public interface IVehicleRepository
{
    Task AddAsync(Vehicle vehicle, CancellationToken cancellationToken);
}