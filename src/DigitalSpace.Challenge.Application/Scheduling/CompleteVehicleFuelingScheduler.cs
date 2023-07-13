using DigitalSpace.Challenge.Application.Commands.Vehicles;
using DigitalSpace.Challenge.Domain.Enums;
using DigitalSpace.Challenge.Domain.Events;
using DigitalSpace.Challenge.Domain.Repositories;
using MediatR;

namespace DigitalSpace.Challenge.Application.Scheduling;

public class CompleteVehicleFuelingScheduler : INotificationHandler<VehicleArrivedAtForecourt>
{
    private readonly IScheduler _scheduler;
    private readonly ITransactionRepository _transactionRepository;

    public CompleteVehicleFuelingScheduler(
        IScheduler scheduler,
        ITransactionRepository transactionRepository)
    {
        _scheduler = scheduler;
        _transactionRepository = transactionRepository;
    }
    
    public async Task Handle(VehicleArrivedAtForecourt @event, CancellationToken cancellationToken)
    {
        if (@event.Status is TransactionStatus.Filling)
        {
            var transaction = await _transactionRepository.GetAsync(@event.TransactionId, cancellationToken);
            var command = new VehicleFueledCommand(@event.VehicleId);
            
            _scheduler.Schedule<IMediator>(
                mediator => mediator.Send(command, cancellationToken), 
                transaction!.CompletionDateTime!.Value);
        }
    }
}