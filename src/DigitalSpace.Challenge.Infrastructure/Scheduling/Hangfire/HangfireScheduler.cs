using System.Linq.Expressions;
using DigitalSpace.Challenge.Application.Scheduling;
using Hangfire;

namespace DigitalSpace.Challenge.Infrastructure.Scheduling.Hangfire;

public class HangfireScheduler : IScheduler
{
    private readonly IBackgroundJobClient _backgroundJobClient;

    public HangfireScheduler(IBackgroundJobClient backgroundJobClient)
    {
        _backgroundJobClient = backgroundJobClient;
    }
    
    public void Schedule<T>(Expression<Action<T>> methodCall, DateTimeOffset executeAt)
    {
        _backgroundJobClient.Schedule(methodCall, executeAt);
    }
}