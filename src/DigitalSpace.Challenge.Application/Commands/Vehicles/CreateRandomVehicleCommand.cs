using MediatR;

namespace DigitalSpace.Challenge.Application.Commands.Vehicles;

public record CreateRandomVehicleCommand(Random Random) : IRequest;