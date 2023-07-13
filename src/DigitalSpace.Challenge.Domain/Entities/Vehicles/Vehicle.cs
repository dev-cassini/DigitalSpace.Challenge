using DigitalSpace.Challenge.Domain.Common;
using DigitalSpace.Challenge.Domain.Enums;

namespace DigitalSpace.Challenge.Domain.Entities.Vehicles;

public abstract class Vehicle : Entity
{
    public Guid Id { get; }
    public VehicleType Type { get; }
    public FuelType FuelType { get; }
    public int FuelLevel { get; }
    public int TankCapacity { get; }

    protected Vehicle(
        Guid id, 
        VehicleType type, 
        FuelType fuelType, 
        int fuelLevel, 
        int tankCapacity)
    {
        Id = id;
        Type = type;
        FuelType = fuelType;
        FuelLevel = fuelLevel;
        TankCapacity = tankCapacity;
    }
}