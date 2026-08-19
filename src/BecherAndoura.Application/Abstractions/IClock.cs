namespace BecherAndoura.Application.Abstractions;

public interface IClock
{
    DateTimeOffset UtcNow { get; }
}
