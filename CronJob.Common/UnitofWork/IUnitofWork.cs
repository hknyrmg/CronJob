using CronJob.Common.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CronJob.Common.UnitofWork
{
    public interface IUnitofWork : IDisposable
    {
       
        IGenericRepository<T> GetRepository<T>() where T : class;

        bool BeginNewTransaction();

        bool RollBackTransaction();

     
        int SaveChanges(bool ensureAutoHistory);
    }
}