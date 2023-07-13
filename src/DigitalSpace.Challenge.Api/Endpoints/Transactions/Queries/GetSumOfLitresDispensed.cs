using DigitalSpace.Challenge.Application.Queries.Transactions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DigitalSpace.Challenge.Api.Endpoints.Transactions.Queries;

public static class GetSumOfLitresDispensed
{
    public static void GetSumOfLitresDispensedEndpoint(this WebApplication webApplication)
    {
        webApplication.MapGet(
            "/transactions/number-of-litres-dispensed/sum",
            async (
                [FromServices] IMediator mediator,
                CancellationToken cancellationToken) =>
            {
                var response = await mediator.Send(new GetSumOfLitresDispensedQuery(), cancellationToken);
                return Results.Ok(response);
            });
    }
}