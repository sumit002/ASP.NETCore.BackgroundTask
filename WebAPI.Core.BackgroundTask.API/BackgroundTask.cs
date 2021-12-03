using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Core.BackgroundTask.API
{
    public class BackgroundTask : BackgroundService
    {
        private readonly ILogger<BackgroundTask> logger;
        public ISchedulerWork SchedulerWork { get; }

        public BackgroundTask(ILogger<BackgroundTask> logger, ISchedulerWork schedulerWork)
        {
            this.logger = logger;
            SchedulerWork = schedulerWork;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                await SchedulerWork.DoScheduleWork(stoppingToken);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in BackgroundTask:ExecuteAsync");
            }
        }
    }
}
