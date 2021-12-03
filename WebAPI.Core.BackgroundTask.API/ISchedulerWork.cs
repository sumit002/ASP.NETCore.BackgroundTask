using System.Threading;
using System.Threading.Tasks;

namespace WebAPI.Core.BackgroundTask.API
{
    public interface ISchedulerWork
    {
        Task DoScheduleWork(CancellationToken cancellationToken);
    }
}