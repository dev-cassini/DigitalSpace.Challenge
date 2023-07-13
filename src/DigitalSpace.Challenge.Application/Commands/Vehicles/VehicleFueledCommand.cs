using MediatR;

namespace DigitalSpace.Challenge.Application.Commands.Vehicles;

public record VehicleFueledCommand(Guid VehicleId) : IRequest;