using DigitalSpace.Challenge.Domain.Common;

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
}