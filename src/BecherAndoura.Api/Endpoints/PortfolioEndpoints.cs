using BecherAndoura.Application.Portfolio;

namespace BecherAndoura.Api.Endpoints;

public static class PortfolioEndpoints
{
    public static IEndpointRouteBuilder MapPortfolioEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/portfolio")
            .WithTags("Portfolio");

        group.MapGet("/", async (
                IPortfolioContentService portfolioService,
                CancellationToken cancellationToken) =>
            {
                var content = await portfolioService.GetAsync(cancellationToken);
                return Results.Ok(content);
            })
            .WithName("GetPortfolioContent")
            .WithSummary("Gets Becher Andoura portfolio and service content.");

        group.MapGet("/services", async (
                IPortfolioContentService portfolioService,
                CancellationToken cancellationToken) =>
            {
                var content = await portfolioService.GetAsync(cancellationToken);
                return Results.Ok(content.Services);
            })
            .WithName("GetPortfolioServices")
            .WithSummary("Gets the services offered by Becher Andoura.");

        return app;
    }
}
