using BecherAndoura.Domain.Portfolio;

namespace BecherAndoura.Application.Abstractions;

public interface IPortfolioContentRepository
{
    Task<PortfolioContent> GetAsync(CancellationToken cancellationToken);
}
