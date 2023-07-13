using DigitalSpace.Challenge.Domain.Common;
using DigitalSpace.Challenge.Domain.Entities.Vehicles;
using DigitalSpace.Challenge.Domain.Enums;
using DigitalSpace.Challenge.Domain.Events;

namespace DigitalSpace.Challenge.Domain.Entities;

public class Forecourt : Entity
{
    public Guid Id { get; }

    private readonly List<Lane> _lanes = new();
    public IReadOnlyList<Lane> Lanes => _lanes.AsReadOnly();
    
    private readonly List<Transaction> _transactions = new();
    public IReadOnlyList<Transaction> Transactions => _transactions.AsReadOnly();

    public Forecourt(Guid id)
    {
        Id = id;
    }

    public void AddLane(Lane lane)
    {
        _lanes.Add(lane);
    }
    
    public void VehicleArrived(Vehicle vehicle)
    {
        var freePump = Lanes.SelectMany(x => x.Pumps)
            .FirstOrDefault(x => x.VehicleId is null);

        freePump?.Filling(vehicle);

        var utcNow = DateTimeOffset.UtcNow;
        var transaction = new Transaction(
            Guid.NewGuid(),
            freePump is null ? TransactionStatus.Waiting : TransactionStatus.Filling,
            utcNow, 
            freePump is null ? null : utcNow,
            vehicle,
            freePump);

        _transactions.Add(transaction);
        AddDomainEvent(new VehicleArrivedAtForecourt(
            vehicle.Id,
            transaction.Id,
            transaction.Status));
    }
    
    public void VehicleFueled(Guid vehicleId)
    {
        var transaction = _transactions.Single(x => x.VehicleId == vehicleId && x.Status is TransactionStatus.Filling);
        transaction.Complete();
        
        var pump = Lanes.SelectMany(x => x.Pumps).Single(x => x.VehicleId == vehicleId);
        pump.Release();
    }
    
    #region EF Constructor
    // ReSharper disable once UnusedMember.Local
    private Forecourt() { }
    #endregion
}