using CronJob.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CronJob.Data
{
    public class CronDbContext : DbContext
    {

        public CronDbContext(DbContextOptions<CronDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Loglamayı aktif hale getiriyoruz
            modelBuilder.EnableAutoHistory(null);
            //modelBuilder.Entity<Demo>();
        }
        #region OnConfiguring

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var config = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile(@"appsettings.json")
        //        .Build();
        //    //optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        //    optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-FTH46FT\\MSSQLSERVER2017;Initial Catalog=CronDb;Integrated Security=True;");
        //    //optionsBuilder.UseLazyLoadingProxies();
        //}

        #endregion OnConfiguring
        #region DbSets

        public DbSet<Demo> Demos { get; set; }
        #endregion DbSets

    }
}