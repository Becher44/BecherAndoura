using BecherAndoura.Domain.Portfolio;

namespace BecherAndoura.Application.Abstractions;

public interface IContactLeadRepository
{
    Task SaveAsync(ContactLead lead, CancellationToken cancellationToken);
}
