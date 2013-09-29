using System;

namespace GenericRepository
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        void Rollback();
    }
}