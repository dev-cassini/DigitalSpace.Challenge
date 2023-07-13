using DigitalSpace.Challenge.Domain.Common;
using DigitalSpace.Challenge.Domain.Entities.Vehicles;
using DigitalSpace.Challenge.Domain.Enums;

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
    }
    
    #region EF Constructor
    // ReSharper disable once UnusedMember.Local
    private Forecourt() { }
    #endregion
}