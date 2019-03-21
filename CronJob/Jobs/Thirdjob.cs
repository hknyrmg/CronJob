using CronJob.Data;
using CronJob.Models;
using CronQuery.Mvc.Jobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CronJob.Jobs
{
    public class Thirdjob : IJob
    {
        private ILogger<Thirdjob> _logger;
        
        public Thirdjob( ILogger<Thirdjob> logger)
        {
            _logger = logger;
        }
        public Task RunAsync()
        {
            _logger.LogError($"Third Job here !! :{DateTime.Now:yyyy-MM--dd HH:mm:ss}");
            _logger.LogCritical($"Third Job :{DateTime.Now:yyyy-MM--dd HH:mm:ss}");

            return Task.CompletedTask;

        }
    }
}
