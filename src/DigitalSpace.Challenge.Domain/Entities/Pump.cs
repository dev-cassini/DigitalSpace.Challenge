using DigitalSpace.Challenge.Domain.Common;
using DigitalSpace.Challenge.Domain.Entities.Vehicles;

namespace DigitalSpace.Challenge.Domain.Entities;

public class Pump : Entity
{
    /// <summary>
    /// Fuel dispense rate in litres per second.
    /// </summary>
    public const decimal FuelDispenseRate = 1.5m;
    
    public Guid Id { get; }
    public Guid? VehicleId { get; private set; }
    
    public Guid LaneId { get; }
    public Lane Lane { get; } = null!;
    
    public Pump(Guid id, Lane lane)
    {
        Id = id;
        LaneId = lane.Id;
        Lane = lane;
    }
    
    public void Filling(Vehicle vehicle)
    {
        VehicleId = vehicle.Id;
    }
    
    public void Release()
    {
        VehicleId = null;
    }
    
    #region EF Constructor
    // ReSharper disable once UnusedMember.Local
    private Pump() { }
    #endregion
}