using MvcMonolithic.ApplicationServices.Dto;

namespace MvcMonolithic.ApplicationServices.Contract
{
    public interface IPersonApplicationService
    {
        #region [-GetAllPerson-]
        Task<List<GetPersonDto>> GetAllPerson();
        #endregion

        #region [- GetPersonById() -]
        Task<GetPersonDto> GetPersonById(int id);
        #endregion

        #region [- PostPerson() -]
        Task Post(PostPersonDto postPersonDto); 
        #endregion

        #region [- Update() -]
        Task Update(UpdatePersonDto updatePersonDto);
        #endregion

        #region [- Delete() -]
        Task Delete(DeletePersonDto deletePersonDto); 
        #endregion
    }

}
