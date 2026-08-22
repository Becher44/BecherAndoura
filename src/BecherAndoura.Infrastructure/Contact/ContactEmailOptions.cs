namespace BecherAndoura.Infrastructure.Contact;

public sealed class ContactEmailOptions
{
    public const string SectionName = "ContactEmail";

    public string RecipientEmail { get; set; } = "Becherandoura@hotmail.com";

    public string SenderEmail { get; set; } = "Becherandoura@gmail.com";

    public string SenderName { get; set; } = "Becher Andoura Website";

    public string SubjectPrefix { get; set; } = "New website service request";

    public SmtpEmailOptions Smtp { get; set; } = new();

    public bool IsConfigured()
    {
        return !string.IsNullOrWhiteSpace(RecipientEmail)
            && !string.IsNullOrWhiteSpace(SenderEmail)
            && !string.IsNullOrWhiteSpace(Smtp.Host)
            && (string.IsNullOrWhiteSpace(Smtp.UserName) || !string.IsNullOrWhiteSpace(Smtp.Password));
    }
}

public sealed class SmtpEmailOptions
{
    public string Host { get; set; } = "smtp.gmail.com";

    public int Port { get; set; } = 587;

    public bool EnableSsl { get; set; } = true;

    public string UserName { get; set; } = "Becherandoura@gmail.com";

    public string Password { get; set; } = string.Empty;
}
