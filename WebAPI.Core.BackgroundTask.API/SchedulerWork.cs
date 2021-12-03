using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Core.BackgroundTask.API
{
    public class SchedulerWork : ISchedulerWork
    {
        private readonly ILogger<SchedulerWork> logger;
        private readonly int number = 0;
        public SchedulerWork(ILogger<SchedulerWork> logger)
        {
            this.logger = logger;
        }
        public async Task DoScheduleWork(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                logger.LogDebug($"Scheduler process number is: {number}");
                await Task.Delay(2000, cancellationToken);
            }
        }
    }
}
