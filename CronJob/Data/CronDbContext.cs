using CronJob.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CronJob.Data
{
    public class CronDbContext : DbContext
    {

        public CronDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Demo> Demos { get; set; }
    }
}