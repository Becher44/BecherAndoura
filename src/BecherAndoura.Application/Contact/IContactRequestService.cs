namespace BecherAndoura.Application.Contact;

public interface IContactRequestService
{
    Task<ContactSubmissionResult> SubmitAsync(ContactRequest request, CancellationToken cancellationToken);
}
