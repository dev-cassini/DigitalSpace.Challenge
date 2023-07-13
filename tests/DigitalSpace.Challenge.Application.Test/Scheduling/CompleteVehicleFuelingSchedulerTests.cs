using System.Linq.Expressions;
using DigitalSpace.Challenge.Application.Scheduling;
using DigitalSpace.Challenge.Domain.Entities;
using DigitalSpace.Challenge.Domain.Entities.Vehicles;
using DigitalSpace.Challenge.Domain.Enums;
using DigitalSpace.Challenge.Domain.Events;
using DigitalSpace.Challenge.Domain.Repositories;
using DigitalSpace.Challenge.Test.BuildingBlocks.Builders;
using MediatR;
using Moq;

namespace DigitalSpace.Challenge.Application.Test.Scheduling;

[TestFixture]
public class CompleteVehicleFuelingSchedulerTests
{
    [TestCase(TransactionStatus.Waiting)]
    [TestCase(TransactionStatus.Completed)]
    [TestCase(TransactionStatus.RageQuit)]
    public async Task VehicleFueledCommandIsNotScheduled_When_VehicleIsNotFilling(TransactionStatus transactionStatus)
    {
        var command = new VehicleArrivedAtForecourt(
            Guid.NewGuid(),
            Guid.NewGuid(),
            transactionStatus);
        
        var scheduler = new Mock<IScheduler>();
        var sut = new CompleteVehicleFuelingScheduler(
            scheduler.Object,
            Mock.Of<ITransactionRepository>());

        await sut.Handle(command, new CancellationToken());
        
        scheduler.Verify(x => x.Schedule(
            It.IsAny<Expression<Action<IMediator>>>(),
            It.IsAny<DateTimeOffset>()), Times.Never);
    }
    
    [Test]
    public async Task VehicleFueledCommandIsScheduled_When_VehicleIsFilling()
    {
        var vehicle = Car.CreateRandom(new Random());
        var pump = new Pump(Guid.NewGuid(), new Lane(Guid.NewGuid(), new Forecourt(Guid.NewGuid())));
        var transaction = new TransactionBuilder()
            .WithStatus(TransactionStatus.Filling)
            .WithPump(pump)
            .Build(vehicle);
        
        var command = new VehicleArrivedAtForecourt(
            vehicle.Id,
            transaction.Id,
            transaction.Status);
        
        var scheduler = new Mock<IScheduler>();
        var transactionRepository = new Mock<ITransactionRepository>();
        transactionRepository.Setup(x => x.GetAsync(
                It.Is<Guid>(y => y == transaction.Id),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(transaction);
        
        var sut = new CompleteVehicleFuelingScheduler(
            scheduler.Object,
            transactionRepository.Object);

        await sut.Handle(command, new CancellationToken());
        
        scheduler.Verify(x => x.Schedule(
            It.IsAny<Expression<Action<IMediator>>>(),
            It.IsAny<DateTimeOffset>()), Times.Once);
    }
}