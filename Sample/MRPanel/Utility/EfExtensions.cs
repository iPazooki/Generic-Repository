using Data;
using GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MRPanel
{
    public static class EfExtensions
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MRPanelContext>(options => options.UseSqlServer(connectionString, x => x.MigrationsAssembly("MRPanel")));

            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;
        }
    }
}
