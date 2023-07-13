using DigitalSpace.Challenge.Domain.Enums;

namespace DigitalSpace.Challenge.Domain.Entities.Vehicles;

public class Van : Vehicle
{
    private const int DefaultTankCapacity = 80;
    private static readonly IReadOnlyList<FuelType> SupportedFuelTypes = new List<FuelType>()
    {
        FuelType.Diesel,
        FuelType.Lpg
    }.AsReadOnly();

    private Van(Guid id, FuelType fuelType, int fuelLevel) 
        : base(id, VehicleType.Van, fuelType, fuelLevel, DefaultTankCapacity) { }

    public static Van CreateRandom(Random random)
    {
        var index = random.Next(0, SupportedFuelTypes.Count);
        var fuelType = SupportedFuelTypes[index];
        var fuelLevel = random.Next(0, DefaultTankCapacity / 4);

        return new Van(Guid.NewGuid(), fuelType, fuelLevel);
    }
}