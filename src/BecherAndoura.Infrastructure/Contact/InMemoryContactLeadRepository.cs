using System.Collections.Concurrent;
using BecherAndoura.Application.Abstractions;
using BecherAndoura.Domain.Portfolio;

namespace BecherAndoura.Infrastructure.Contact;

public sealed class InMemoryContactLeadRepository : IContactLeadRepository
{
    private readonly ConcurrentQueue<ContactLead> leads = new();

    public Task SaveAsync(ContactLead lead, CancellationToken cancellationToken)
    {
        leads.Enqueue(lead);
        return Task.CompletedTask;
    }
}
