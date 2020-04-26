using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Data
{
    public class MRPanelContext : DbContext
    {
        public MRPanelContext(DbContextOptions<MRPanelContext> options) : base(options) { }

        //TODO: Configure me!
        //public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}