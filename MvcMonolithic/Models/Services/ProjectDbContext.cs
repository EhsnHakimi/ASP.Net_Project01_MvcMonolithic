using Microsoft.EntityFrameworkCore;
using MvcMonolithic.Models.DomainModel.PersonAggregates;
using MvcMonolithic.Models.DomainModel.ProductAggregates;

namespace MvcMonolithic.Models.Services
{
    public class ProjectDbContext : DbContext
    {

        //Add Conection String

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Data Source=.;Initial Catalog=MvcMonolithicDb;Integrated Security=True;Persist Security Info=False;Trust Server Certificate=True;");
            }
        }
        public DbSet<Person> People { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().ToTable("People");
        }
    }
}