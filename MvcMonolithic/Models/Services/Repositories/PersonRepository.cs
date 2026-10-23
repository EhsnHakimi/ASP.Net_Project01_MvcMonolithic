using Microsoft.EntityFrameworkCore;
using MvcMonolithic.Models.DomainModel.PersonAggregates;
using MvcMonolithic.Models.Services.Contract;

namespace MvcMonolithic.Models.Services.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ProjectDbContext _projectDbContext;

        #region [- ctor(*) -]
        public PersonRepository(ProjectDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
        } 
        #endregion

        #region [- CreateInsert(*) -]
        public async Task insert(Person person)
        {
            try
            {
                _projectDbContext.Add(person);
                await _projectDbContext.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
        } 
        #endregion

        #region [- ReadSelectAll(*) -]
        public async Task<IEnumerable<Person>> SelectAll()
        {
            try
            {
                return await _projectDbContext.People.ToListAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region [- ReadSelectById(*) -]
        public async Task<Person?> SelectByIdAsync(int id)
        {
            if (id <= 0)
                return null;

            return await _projectDbContext.People
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        #endregion

        #region [- Update(*) -]
        public async Task<Person> UpdateAsync(Person person)
        {
            var updatePerson = await _projectDbContext.People
            .FindAsync(person.Id);

            if (updatePerson == null)
                return null;

            updatePerson.FirstName = person.FirstName;
            updatePerson.LastName = person.LastName;

            await _projectDbContext.SaveChangesAsync();

            return updatePerson;

        }
        #endregion

        #region [- Delete(*) -]

        public async Task DeleteAsync(int id)
        {
            var person = await _projectDbContext.People.FindAsync(id);

            if (person is null)
                return;

            _projectDbContext.People.Remove(person);

            await _projectDbContext.SaveChangesAsync();
        }

        #endregion


    }
}
