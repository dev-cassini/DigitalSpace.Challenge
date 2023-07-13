using DigitalSpace.Challenge.Domain.Enums;
using MediatR;

namespace DigitalSpace.Challenge.Domain.Events;

public class VehicleArrivedAtForecourt : INotification
{
    /// <summary>
    /// Vehicle identifier.
    /// </summary>
    public Guid VehicleId { get; }
    
    /// <summary>
    /// Identifier of the transaction which represents the interaction between forecourt and vehicle.
    /// </summary>
    public Guid TransactionId { get; }
    
    /// <summary>
    /// Status of transaction.
    /// </summary>
    public TransactionStatus Status { get; }
    
    public VehicleArrivedAtForecourt(
        Guid vehicleId, 
        Guid transactionId, 
        TransactionStatus status)
    {
        VehicleId = vehicleId;
        TransactionId = transactionId;
        Status = status;
    }
}