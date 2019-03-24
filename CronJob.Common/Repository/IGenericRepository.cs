using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CronJob.Common.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        
        IQueryable<T> GetAll();

      
        T Find(int Id);

       
        T Add(T entity);

       
        T Update(T entityToUpdate);
        void Delete(int Id);


        void Delete(T entityToDelete);
    }

}
