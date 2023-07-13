using System.Linq.Expressions;

namespace DigitalSpace.Challenge.Application.Scheduling;

public interface IScheduler
{
    void Schedule<T>(Expression<Action<T>> methodCall, DateTimeOffset executeAt);
}