namespace BecherAndoura.Domain.Portfolio;

public sealed record ContactLead(
    string Name,
    string Email,
    string? Company,
    string? Budget,
    string Message,
    DateTimeOffset SubmittedAt);
