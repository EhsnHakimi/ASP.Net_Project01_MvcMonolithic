using MvcMonolithic.ApplicationServices.Dto;
using MvcMonolithic.Models.DomainModel.PersonAggregates;

namespace MvcMonolithic.Models.Services.Contract
{
    public interface IPersonRepository
    {
        #region [-Insert-]

        Task insert(Person person);
        #endregion    

        #region [-SelectAll-]
        Task<IEnumerable<Person>> SelectAll();

        #endregion

        #region [-Update-]
        Task<Person> UpdateAsync(Person person);

        #endregion
        #region [- Delete() -]
        Task DeleteAsync(int id);
        #endregion

        #region [- SelectById() -]
        Task<Person> SelectByIdAsync(int id); 
        #endregion

    }
}
