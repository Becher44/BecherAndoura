using BecherAndoura.Application.Contact;

namespace BecherAndoura.Api.Endpoints;

public static class ContactEndpoints
{
    public static IEndpointRouteBuilder MapContactEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/contact")
            .WithTags("Contact");

        group.MapPost("/", async (
                ContactRequest request,
                IContactRequestService contactService,
                CancellationToken cancellationToken) =>
            {
                var result = await contactService.SubmitAsync(request, cancellationToken);

                if (!result.Accepted)
                {
                    return Results.ValidationProblem(result.Errors);
                }

                return Results.Accepted("/api/contact", new { result.Message });
            })
            .WithName("SubmitContactRequest")
            .WithSummary("Submits a website or web application project inquiry.");

        return app;
    }
}
