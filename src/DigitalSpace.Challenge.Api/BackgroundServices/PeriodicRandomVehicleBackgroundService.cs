using DigitalSpace.Challenge.Application.Commands.Vehicles;
using MediatR;

namespace DigitalSpace.Challenge.Api.BackgroundServices;

public class PeriodicRandomVehicleBackgroundService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public PeriodicRandomVehicleBackgroundService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        var random = new Random();
        var randomTimeSpan = TimeSpan.FromMilliseconds(random.Next(1500, 2200));
        using var periodicTimer = new PeriodicTimer(randomTimeSpan);
        
        while (await periodicTimer.WaitForNextTickAsync(cancellationToken))
        {
            await using var scope = _serviceProvider.CreateAsyncScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            var command = new CreateRandomVehicleCommand(random);
            await mediator.Send(command, cancellationToken);
        }
    }
}