using DigitalSpace.Challenge.Domain.Repositories;
using MediatR;

namespace DigitalSpace.Challenge.Application.Commands.Vehicles;

public class VehicleFueledCommandHandler : IRequestHandler<VehicleFueledCommand>
{
    private readonly IForecourtRepository _forecourtRepository;

    public VehicleFueledCommandHandler(IForecourtRepository forecourtRepository)
    {
        _forecourtRepository = forecourtRepository;
    }
    
    public async Task Handle(VehicleFueledCommand request, CancellationToken cancellationToken)
    {
        var forecourt = await _forecourtRepository.GetAsync(cancellationToken);
        forecourt.VehicleFueled(request.VehicleId);

        await _forecourtRepository.SaveChangesAsync(cancellationToken);
    }
}