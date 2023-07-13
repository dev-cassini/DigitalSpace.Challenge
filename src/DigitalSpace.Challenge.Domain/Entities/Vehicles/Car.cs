using DigitalSpace.Challenge.Domain.Enums;

namespace DigitalSpace.Challenge.Domain.Entities.Vehicles;

public class Car : Vehicle
{
    private const int DefaultTankCapacity = 10;
    private static readonly IReadOnlyList<FuelType> SupportedFuelTypes = new List<FuelType>()
    {
        FuelType.Diesel,
        FuelType.Lpg,
        FuelType.Unleaded
    }.AsReadOnly();

    private Car(Guid id, FuelType fuelType, int fuelLevel) 
        : base(id, VehicleType.Car, fuelType, fuelLevel, DefaultTankCapacity) { }

    public static Car CreateRandom(Random random)
    {
        var index = random.Next(0, SupportedFuelTypes.Count);
        var fuelType = SupportedFuelTypes[index];
        var fuelLevel = random.Next(0, DefaultTankCapacity / 4);

        return new Car(Guid.NewGuid(), fuelType, fuelLevel);
    }
}