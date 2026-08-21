namespace BecherAndoura.Infrastructure.Contact;

public sealed class ContactEmailOptions
{
    public const string SectionName = "ContactEmail";

    public string RecipientEmail { get; set; } = "Becherandoura@hotmail.com";

    public string SenderEmail { get; set; } = "Becherandoura@hotmail.com";

    public string SenderName { get; set; } = "Becher Andoura Website";

    public string SubjectPrefix { get; set; } = "New website service request";

    public SmtpEmailOptions Smtp { get; set; } = new();

    public bool IsConfigured()
    {
        return !string.IsNullOrWhiteSpace(RecipientEmail)
            && !string.IsNullOrWhiteSpace(SenderEmail)
            && !string.IsNullOrWhiteSpace(Smtp.Host);
    }
}

public sealed class SmtpEmailOptions
{
    public string Host { get; set; } = string.Empty;

    public int Port { get; set; } = 587;

    public bool EnableSsl { get; set; } = true;

    public string UserName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}
