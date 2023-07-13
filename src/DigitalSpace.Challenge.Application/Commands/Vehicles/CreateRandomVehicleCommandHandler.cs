using DigitalSpace.Challenge.Domain.Entities.Vehicles;
using DigitalSpace.Challenge.Domain.Enums;
using DigitalSpace.Challenge.Domain.Repositories;
using MediatR;

namespace DigitalSpace.Challenge.Application.Commands.Vehicles;

public class CreateRandomVehicleCommandHandler : IRequestHandler<CreateRandomVehicleCommand>
{
    private readonly IForecourtRepository _forecourtRepository;
    private readonly IVehicleRepository _vehicleRepository;

    public CreateRandomVehicleCommandHandler(
        IForecourtRepository forecourtRepository,
        IVehicleRepository vehicleRepository)
    {
        _forecourtRepository = forecourtRepository;
        _vehicleRepository = vehicleRepository;
    }
    
    public async Task Handle(CreateRandomVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicleTypes = Enum.GetValues<VehicleType>().ToList();
        var index = request.Random.Next(0, vehicleTypes.Count);
        var randomVehicleType = vehicleTypes[index];

        Vehicle randomVehicle = randomVehicleType switch
        {
            VehicleType.Car => Car.CreateRandom(request.Random),
            VehicleType.Van => Van.CreateRandom(request.Random),
            VehicleType.Hgv => Hgv.CreateRandom(request.Random),
            _ => throw new NotSupportedException()
        };

        await _vehicleRepository.AddAsync(randomVehicle, cancellationToken);
        var forecourt = await _forecourtRepository.GetAsync(cancellationToken);
        forecourt.VehicleArrived(randomVehicle);
        
        await _forecourtRepository.SaveChangesAsync(cancellationToken);
    }
}