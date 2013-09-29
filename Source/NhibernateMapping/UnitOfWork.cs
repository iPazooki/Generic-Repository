using System;
using System.Data;
using GenericRepository;
using NHibernate;

namespace NhibernateMapping
{
	public class UnitOfWork : IUnitOfWork
	{
	    private readonly ITransaction _transaction;

		public ISession Session { get; private set; }

		public UnitOfWork(ISessionFactory sessionFactory)
		{
		    Session = sessionFactory.OpenSession();

			Session.FlushMode = FlushMode.Auto;

			_transaction = Session.BeginTransaction(IsolationLevel.ReadCommitted);
		}

		public void Dispose()
		{
			if(Session.IsOpen)
			{
				Session.Close();
			}
		}

		public void Commit()
		{
			if(!_transaction.IsActive)
			{
				throw new InvalidOperationException("No active transation");
			}

			_transaction.Commit();
		}

		public void Rollback()
		{
			if(_transaction.IsActive)
			{
				_transaction.Rollback();
			}
		}
	}
}