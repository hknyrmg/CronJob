using CronQuery.Mvc.Jobs;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CronJob.Jobs
{
    public class FirstJob:IJob
    {
        private ILogger<FirstJob> _logger;

        public FirstJob(ILogger<FirstJob> logger)
        {
            _logger = logger;
        }
          public Task RunAsync()
        {
            _logger.LogError($"First Job here !! :{DateTime.Now:yyyy-MM--dd HH:mm:ss}");
            _logger.LogCritical($"First Job :{DateTime.Now:yyyy-MM--dd HH:mm:ss}");

            return Task.CompletedTask;
        }
    }
}
