using SPAMarket.DAL.Contracts;
using SPAMarket.DAL.Implementations.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPAMarket.DAL.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private DataContext context = new DataContext();
        private IDbRepository departmentRepository;

        public IDbRepository DepartmentRepository
        {
            get
            {

                if (this.departmentRepository == null)
                {
                    this.departmentRepository = new DbRepository(context);
                }
                return departmentRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
