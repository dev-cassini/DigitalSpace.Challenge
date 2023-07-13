using DigitalSpace.Challenge.Domain.Entities;
using DigitalSpace.Challenge.Domain.Entities.Vehicles;
using DigitalSpace.Challenge.Domain.Enums;

namespace DigitalSpace.Challenge.Test.BuildingBlocks.Builders;

public class TransactionBuilder
{
    private TransactionStatus _status = TransactionStatus.Waiting;
    private Pump? _pump;
    
    public Transaction Build(Vehicle vehicle)
    {
        var utcNow = DateTimeOffset.UtcNow;
        return new Transaction(
            Guid.NewGuid(),
            _status,
            utcNow,
            _status == TransactionStatus.Filling ? utcNow : null,
            vehicle,
            _pump);
    }

    public TransactionBuilder WithStatus(TransactionStatus status)
    {
        _status = status;
        return this;
    }

    public TransactionBuilder WithPump(Pump pump)
    {
        _pump = pump;
        return this;
    }
}