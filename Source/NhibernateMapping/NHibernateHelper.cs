using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace NhibernateMapping
{
    public class NHibernateHelper
    {
        private readonly string _connectionString;

        private ISessionFactory _sessionFactory;

        public ISessionFactory SessionFactory
        {
            get { return _sessionFactory ?? (_sessionFactory = CreateSessionFactory()); }
        }

        public NHibernateHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        private ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
                .Database(MySQLConfiguration.Standard.ConnectionString(_connectionString))
                .Mappings(m => m.FluentMappings.AddFromAssembly(typeof(NHibernateHelper).Assembly))
                .BuildSessionFactory();
        }
    }
}