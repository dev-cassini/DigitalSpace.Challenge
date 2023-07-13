using DigitalSpace.Challenge.Domain.Common;
using DigitalSpace.Challenge.Domain.Entities.Vehicles;
using DigitalSpace.Challenge.Domain.Enums;

namespace DigitalSpace.Challenge.Domain.Entities;

public class Transaction : Entity
{
    /// <summary>
    /// Unique identifier.
    /// </summary>
    public Guid Id { get; }
    
    /// <summary>
    /// Status of transaction.
    /// </summary>
    public TransactionStatus Status { get; private set; }

    /// <summary>
    /// When the transaction was created.
    /// </summary>
    public DateTimeOffset DateTimeCreated { get; }

    /// <summary>
    /// When the transaction status moved to <see cref="TransactionStatus.Filling"/>.
    /// </summary>
    public DateTimeOffset? DateTimeFilling { get; }

    /// <summary>
    /// When the transaction status moved to <see cref="TransactionStatus.Completed"/>.
    /// </summary>
    public DateTimeOffset? DateTimeCompleted { get; private set; }
    
    public Guid VehicleId { get; }
    public Guid? PumpId { get; }

    internal Transaction(
        Guid id, 
        TransactionStatus status,
        DateTimeOffset dateTimeCreated,
        DateTimeOffset? dateTimeFilling,
        Vehicle vehicle, 
        Pump? pump)
    {
        Id = id;
        Status = status;
        DateTimeCreated = dateTimeCreated;
        DateTimeFilling = dateTimeFilling;
        VehicleId = vehicle.Id;
        PumpId = pump?.Id;
    }
}