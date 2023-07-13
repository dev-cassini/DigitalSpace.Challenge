using DigitalSpace.Challenge.Api.Endpoints.Transactions.Queries;

namespace DigitalSpace.Challenge.Api;

public static class EndpointsConfiguration
{
    public static void RegisterEndpoints(this WebApplication webApplication)
    {
        webApplication.GetSumOfLitresDispensedEndpoint();
    }
}