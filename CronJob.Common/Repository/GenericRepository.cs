using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CronJob.Common.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        #region Variables

        //Bu sınıf içinde kullanılacak değişkenleri tanımlıyoruz
        //Database işlemleri için DbContext tablo işlemleri için ise DbSet sınıfını kullanacağız
        private DbContext _context;

        private DbSet<T> _dbset;

        #endregion Variables

        #region Constructor

      
        public GenericRepository(DbContext context)
        {
            //Değişkenlere değer ataması yapıyoruz
            _context = context;
            _dbset = _context.Set<T>();
        }

        #endregion Constructor

        #region GetterMethods

        
        public IQueryable<T> GetAll()
        {
            return _dbset;
        }

      
        public T Find(int Id)
        {
            return  _dbset.Find(Id);
        }
   
        #endregion GetterMethods

        #region SetterMethods

       
        public T Update(T entityToUpdate)
        {
            _dbset.Update(entityToUpdate);
            return entityToUpdate;
        }

        
        public T Add(T entity)
        {
            _dbset.Add(entity);
            return entity;
        }

        
        public void Delete(int Id)
        {
            Delete(Find(Id));
        }

       
        public void Delete(T entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _context.Attach(entityToDelete);
            }
            _dbset.Remove(entityToDelete);
        }

        
      
        #endregion SetterMethods
    }
}
