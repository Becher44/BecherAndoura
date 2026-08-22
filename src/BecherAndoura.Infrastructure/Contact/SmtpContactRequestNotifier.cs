using System.Net;
using System.Net.Mail;
using BecherAndoura.Application.Abstractions;
using BecherAndoura.Domain.Portfolio;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BecherAndoura.Infrastructure.Contact;

public sealed class SmtpContactRequestNotifier(
    IOptions<ContactEmailOptions> emailOptions,
    ILogger<SmtpContactRequestNotifier> logger) : IContactRequestNotifier
{
    public async Task NotifyAsync(ContactLead lead, CancellationToken cancellationToken)
    {
        var options = emailOptions.Value;

        if (!options.IsConfigured())
        {
            logger.LogWarning(
                "Contact request email was not sent because SMTP is not fully configured. Configure ContactEmail to send requests to {RecipientEmail}.",
                options.RecipientEmail);
            return;
        }

        using var ownerMessage = CreateOwnerNotificationMessage(options, lead);
        using var customerMessage = CreateCustomerConfirmationMessage(options, lead);
        using var smtpClient = CreateSmtpClient(options.Smtp);

        await smtpClient.SendMailAsync(ownerMessage).WaitAsync(cancellationToken);
        await smtpClient.SendMailAsync(customerMessage).WaitAsync(cancellationToken);
    }

    private static MailMessage CreateOwnerNotificationMessage(ContactEmailOptions options, ContactLead lead)
    {
        var message = new MailMessage
        {
            From = new MailAddress(options.SenderEmail, options.SenderName),
            Subject = $"{options.SubjectPrefix}: {lead.ProjectType ?? "Website request"}",
            Body = CreateOwnerNotificationBody(lead)
        };

        message.To.Add(new MailAddress(options.RecipientEmail));
        message.ReplyToList.Add(new MailAddress(lead.Email, lead.Name));

        return message;
    }

    private static MailMessage CreateCustomerConfirmationMessage(ContactEmailOptions options, ContactLead lead)
    {
        var message = new MailMessage
        {
            From = new MailAddress(options.SenderEmail, options.SenderName),
            Subject = "We received your website service request",
            Body = CreateCustomerConfirmationBody(lead)
        };

        message.To.Add(new MailAddress(lead.Email, lead.Name));
        message.ReplyToList.Add(new MailAddress(options.RecipientEmail, "Becher Andoura"));

        return message;
    }

    private static SmtpClient CreateSmtpClient(SmtpEmailOptions options)
    {
        var smtpClient = new SmtpClient(options.Host, options.Port)
        {
            EnableSsl = options.EnableSsl,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false
        };

        if (!string.IsNullOrWhiteSpace(options.UserName))
        {
            smtpClient.Credentials = new NetworkCredential(options.UserName, options.Password);
        }

        return smtpClient;
    }

    private static string CreateOwnerNotificationBody(ContactLead lead)
    {
        var company = lead.Company ?? "Not provided";
        var projectType = lead.ProjectType ?? "Not selected";

        return string.Join(
            Environment.NewLine,
            $"Name: {lead.Name}",
            $"Email: {lead.Email}",
            $"Company: {company}",
            $"Request type: {projectType}",
            $"Submitted: {lead.SubmittedAt:O}",
            string.Empty,
            "Message:",
            lead.Message);
    }

    private static string CreateCustomerConfirmationBody(ContactLead lead)
    {
        var projectType = lead.ProjectType ?? "your request";

        return string.Join(
            Environment.NewLine,
            $"Hi {GetFirstName(lead.Name)},",
            string.Empty,
            "Thanks for contacting Becher Andoura. I received your request and will review it soon.",
            string.Empty,
            $"Request type: {projectType}",
            $"Submitted: {lead.SubmittedAt:MMMM d, yyyy 'at' h:mm tt 'UTC'}",
            string.Empty,
            "Your message:",
            lead.Message,
            string.Empty,
            "If you need to add anything, you can reply to this email.",
            string.Empty,
            "Regards,",
            "Becher Andoura",
            "Website Developer & Software Developer");
    }

    private static string GetFirstName(string name)
    {
        var parts = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return parts.Length > 0 ? parts[0] : name;
    }
}
