using BecherAndoura.Application.Abstractions;

namespace BecherAndoura.Infrastructure;

public sealed class SystemClock : IClock
{
    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}
