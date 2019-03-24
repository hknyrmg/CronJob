using CronJob.Common.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;


namespace CronJob.Common.UnitofWork
{
    public class UnitofWork : IUnitofWork
    {
        #region Variables
       
     
        private readonly DbContext _context;

        private IDbContextTransaction _transation;
        private bool _disposed;
        private ILogger<UnitofWork> _logger;

        #endregion Variables

        #region Constructor


        public UnitofWork(DbContext context, ILogger<UnitofWork> logger)
        {
            _logger = logger;
            _context = context;
        }

        #endregion Constructor

        #region BusinessSection

       
        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            return new GenericRepository<T>(_context);
        }

       
        public bool BeginNewTransaction()
        {
            try
            {
                _transation = _context.Database.BeginTransaction();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"{_context} <=> {ex.Message} {DateTime.Now}");
                return false;
            }
        }

      
        public bool RollBackTransaction()
        {
            try
            {
                _transation.Rollback();
                _transation = null;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

       
        public int SaveChanges(bool ensureAutoHistory = false)
        {
            var transaction = _transation != null ? _transation : _context.Database.BeginTransaction();
            using (transaction)
            {
                try
                {
                    //Context boş ise hata fırlatıyoruz
                    if (_context == null)
                    {
                        _logger.LogError($"{_context} is null {DateTime.Now}");

                        throw new ArgumentException("Context is null");
                    }

                    //if (ensureAutoHistory)
                    //{
                    //    _context.EnsureAutoHistory();
                    //}
                    //Save changes metodundan dönen int result ı yakalayarak geri dönüyoruz.
                    int result = _context.SaveChanges();

                    //Sorun yok ise kuyruktaki tüm işlemleri commit ederek bitiriyoruz.
                    transaction.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"{_context} <=> {ex.Message} {DateTime.Now} Error on save changes");

                    //Hata ile karşılaşılır ise işlemler geri alınıyor
                    transaction.Rollback();
                    throw new Exception("Error on save changes ", ex);
                }
            }
        }

        #endregion BusinessSection

        #region DisposingSection

        /// <summary>
        /// Context ile işimiz bittiğinde dispose edilmesini sağlıyoruz
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion DisposingSection
    }

}
