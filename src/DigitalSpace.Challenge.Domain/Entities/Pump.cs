using DigitalSpace.Challenge.Domain.Common;

namespace DigitalSpace.Challenge.Domain.Entities;

public class Pump : Entity
{
    /// <summary>
    /// Fuel dispense rate in litres per second.
    /// </summary>
    public const decimal FuelDispenseRate = 1.5m;
    
    public Guid Id { get; }
    
    public Guid LaneId { get; }
    public Lane Lane { get; } = null!;
    
    public Pump(Guid id, Lane lane)
    {
        Id = id;
        LaneId = lane.Id;
        Lane = lane;
    }
    
    #region EF Constructor
    // ReSharper disable once UnusedMember.Local
    private Pump() { }
    #endregion
}