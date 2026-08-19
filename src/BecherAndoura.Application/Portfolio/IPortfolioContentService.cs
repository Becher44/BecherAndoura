using BecherAndoura.Domain.Portfolio;

namespace BecherAndoura.Application.Portfolio;

public interface IPortfolioContentService
{
    Task<PortfolioContent> GetAsync(CancellationToken cancellationToken);
}
