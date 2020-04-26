using Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Data
{
    public class MRPanelContext : DbContext
    {
        public MRPanelContext(DbContextOptions<MRPanelContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Seed data
            modelBuilder.Entity<Person>().HasData(new Person { Name = "Mohammad Reza", Family = "Pazooki" });
        }
    }
}