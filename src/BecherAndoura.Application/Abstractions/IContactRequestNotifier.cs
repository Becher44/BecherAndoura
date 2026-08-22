using BecherAndoura.Domain.Portfolio;

namespace BecherAndoura.Application.Abstractions;

public interface IContactRequestNotifier
{
    Task NotifyAsync(ContactLead lead, CancellationToken cancellationToken);
}
