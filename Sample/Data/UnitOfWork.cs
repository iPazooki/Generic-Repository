using GenericRepository;
using System;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class, IEntity
    {
        private readonly MRPanelContext context;

        public UnitOfWork(MRPanelContext context)
        {
            this.context = context;
            Repository = new Repository<T>(context);
        }

        public IRepository<T> Repository { get; }

        public async Task Commit()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
