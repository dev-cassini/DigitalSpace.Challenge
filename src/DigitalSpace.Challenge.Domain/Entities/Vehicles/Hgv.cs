using DigitalSpace.Challenge.Domain.Enums;

namespace DigitalSpace.Challenge.Domain.Entities.Vehicles;

public class Hgv : Vehicle
{
    private const int DefaultTankCapacity = 150;
    private static readonly IReadOnlyList<FuelType> SupportedFuelTypes = new List<FuelType>()
    {
        FuelType.Diesel
    }.AsReadOnly();

    private Hgv(Guid id, FuelType fuelType, int fuelLevel) 
        : base(id, VehicleType.Hgv, fuelType, fuelLevel, DefaultTankCapacity) { }

    public static Hgv CreateRandom(Random random)
    {
        var index = random.Next(0, SupportedFuelTypes.Count);
        var fuelType = SupportedFuelTypes[index];
        var fuelLevel = random.Next(0, DefaultTankCapacity / 4);

        return new Hgv(Guid.NewGuid(), fuelType, fuelLevel);
    }
}