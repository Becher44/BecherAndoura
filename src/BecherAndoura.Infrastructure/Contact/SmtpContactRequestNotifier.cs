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
                "Contact request email was not sent because SMTP is not configured. Configure ContactEmail to send requests to {RecipientEmail}.",
                options.RecipientEmail);
            return;
        }

        using var message = CreateMessage(options, lead);
        using var smtpClient = CreateSmtpClient(options.Smtp);

        await smtpClient.SendMailAsync(message).WaitAsync(cancellationToken);
    }

    private static MailMessage CreateMessage(ContactEmailOptions options, ContactLead lead)
    {
        var message = new MailMessage
        {
            From = new MailAddress(options.SenderEmail, options.SenderName),
            Subject = $"{options.SubjectPrefix}: {lead.ProjectType ?? "Website request"}",
            Body = CreateBody(lead)
        };

        message.To.Add(new MailAddress(options.RecipientEmail));
        message.ReplyToList.Add(new MailAddress(lead.Email, lead.Name));

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

    private static string CreateBody(ContactLead lead)
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
}
