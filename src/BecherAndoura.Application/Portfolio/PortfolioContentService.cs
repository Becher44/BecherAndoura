using BecherAndoura.Application.Abstractions;
using BecherAndoura.Domain.Portfolio;

namespace BecherAndoura.Application.Portfolio;

public sealed class PortfolioContentService(IPortfolioContentRepository repository) : IPortfolioContentService
{
    public Task<PortfolioContent> GetAsync(CancellationToken cancellationToken)
    {
        return repository.GetAsync(cancellationToken);
    }
}
