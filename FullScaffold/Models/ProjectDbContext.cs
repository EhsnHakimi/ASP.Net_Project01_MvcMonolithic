using FullScaffold.Models.DomainModels.PersonAggregates;
using Microsoft.EntityFrameworkCore;

namespace FullScaffold.Models
{
    public class ProjectDbContext : DbContext
    {

        //Add Conection String

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Data Source=.;Initial Catalog=FullScaffoldSampleDb;Integrated Security=True;Persist Security Info=False;Trust Server Certificate=True;");
            }
        }
        public DbSet<Person> Person { get; set; }
    }
}
