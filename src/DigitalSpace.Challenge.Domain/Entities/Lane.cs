using DigitalSpace.Challenge.Domain.Common;

namespace DigitalSpace.Challenge.Domain.Entities;

public class Lane : Entity
{
    public Guid Id { get; }

    private readonly List<Pump> _pumps = new();
    public IReadOnlyList<Pump> Pumps => _pumps.AsReadOnly();
    
    public Guid ForecourtId { get; }
    public Forecourt Forecourt { get; } = null!;

    public Lane(Guid id, Forecourt forecourt)
    {
        Id = id;
        ForecourtId = forecourt.Id;
        Forecourt = forecourt;
    }

    public void AddPump(Pump pump)
    {
        _pumps.Add(pump);
    }
    
    #region EF Constructor
    // ReSharper disable once UnusedMember.Local
    private Lane() { }
    #endregion
}