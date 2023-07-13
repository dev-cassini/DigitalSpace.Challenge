using MediatR;

namespace DigitalSpace.Challenge.Application.Queries.Transactions;

public record GetSumOfLitresDispensedQuery : IRequest<int>;