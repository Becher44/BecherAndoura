namespace BecherAndoura.Application.Contact;

public sealed record ContactRequest(
    string Name,
    string Email,
    string? Company,
    string? Budget,
    string Message);
