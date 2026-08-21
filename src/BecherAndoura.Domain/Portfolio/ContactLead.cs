namespace BecherAndoura.Domain.Portfolio;

public sealed record ContactLead(
    string Name,
    string Email,
    string? Company,
    string? ProjectType,
    string Message,
    DateTimeOffset SubmittedAt);
