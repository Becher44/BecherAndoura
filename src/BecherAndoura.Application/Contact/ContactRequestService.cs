using System.Net.Mail;
using BecherAndoura.Application.Abstractions;
using BecherAndoura.Domain.Portfolio;

namespace BecherAndoura.Application.Contact;

public sealed class ContactRequestService(
    IContactLeadRepository repository,
    IClock clock) : IContactRequestService
{
    public async Task<ContactSubmissionResult> SubmitAsync(ContactRequest request, CancellationToken cancellationToken)
    {
        var errors = Validate(request);

        if (errors.Count > 0)
        {
            return new ContactSubmissionResult(false, errors, "Please review the fields that need more information.");
        }

        var lead = new ContactLead(
            Normalize(request.Name),
            Normalize(request.Email),
            NormalizeOptional(request.Company),
            NormalizeOptional(request.ProjectType),
            Normalize(request.Message),
            clock.UtcNow);

        await repository.SaveAsync(lead, cancellationToken);

        return new ContactSubmissionResult(true, [], "Thanks. Becher will review your service request soon.");
    }

    private static Dictionary<string, string[]> Validate(ContactRequest request)
    {
        var errors = new Dictionary<string, string[]>(StringComparer.OrdinalIgnoreCase);

        AddRequired(errors, nameof(request.Name), request.Name, "Please add your name.");
        AddRequired(errors, nameof(request.Email), request.Email, "Please add your email.");
        AddRequired(errors, nameof(request.Message), request.Message, "Please describe what you want the website to help you do.");

        if (!string.IsNullOrWhiteSpace(request.Email) && !IsValidEmail(request.Email))
        {
            errors[nameof(request.Email)] = ["Please add a valid email address."];
        }

        if (!string.IsNullOrWhiteSpace(request.Message) && request.Message.Trim().Length < 20)
        {
            errors[nameof(request.Message)] = ["Please share a little more context about the service you need."];
        }

        return errors;
    }

    private static void AddRequired(
        Dictionary<string, string[]> errors,
        string field,
        string value,
        string message)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            errors[field] = [message];
        }
    }

    private static bool IsValidEmail(string email)
    {
        try
        {
            _ = new MailAddress(email);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }

    private static string Normalize(string value)
    {
        return value.Trim();
    }

    private static string? NormalizeOptional(string? value)
    {
        return string.IsNullOrWhiteSpace(value) ? null : value.Trim();
    }
}
