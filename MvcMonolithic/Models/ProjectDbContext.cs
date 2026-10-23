using Microsoft.EntityFrameworkCore;
using MvcMonolithic.Models.DomainModel.PersonAggregates;

namespace MvcMonolithic.Models
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
    }
}
