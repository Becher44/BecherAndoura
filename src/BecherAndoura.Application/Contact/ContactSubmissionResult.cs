namespace BecherAndoura.Application.Contact;

public sealed record ContactSubmissionResult(
    bool Accepted,
    Dictionary<string, string[]> Errors,
    string Message);
