using CronJob.Common.UnitofWork;
using CronJob.Data;
using CronJob.Data.Entities;
using CronQuery.Mvc.Jobs;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CronJob.Jobs
{
    public class SecondJob : IJob
    {
        private IUnitofWork _unitofwork;
        private ILogger<SecondJob> _logger;
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public SecondJob(ILogger<SecondJob> logger, IUnitofWork unitofWork)
        {
            _unitofwork = unitofWork;
            _logger = logger;
        }
        public Task RunAsync()
        {
            Demo demo = new Demo();
            demo.DemoName = RandomString(15);
            _unitofwork.GetRepository<CronJob.Data.Entities.Demo>().Add(demo);
            _unitofwork.SaveChanges(true);
            _logger.LogError($"Second Job in DbContext !! :{DateTime.Now:yyyy-MM--dd HH:mm:ss}");
            _logger.LogCritical($"Second Job :{DateTime.Now:yyyy-MM--dd HH:mm:ss}");
            return Task.CompletedTask;
        }
    }
}
