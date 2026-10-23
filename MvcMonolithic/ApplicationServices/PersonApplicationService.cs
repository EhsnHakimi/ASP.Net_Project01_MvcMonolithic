using MvcMonolithic.ApplicationServices.Contract;
using MvcMonolithic.ApplicationServices.Dto;
using MvcMonolithic.Models.Services.Contract;

namespace MvcMonolithic.ApplicationServices
{
    public class PersonApplicationService :IPersonApplicationService
    {
        
        private readonly IPersonRepository _personRepository;

        #region [- Ctor() -]
        public PersonApplicationService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }  
        #endregion

        #region [- CreatePost(*) -]
        public async Task Post(PostPersonDto postPersonDto)
        {
            var person = new Models.DomainModel.PersonAggregates.Person()
            {
                FirstName = postPersonDto.FirstName,
                LastName = postPersonDto.LastName
            };
            await _personRepository.insert(person);
        } 
        #endregion

        #region [- ReadGetAllPerson(*) -]
        public async Task<List<GetPersonDto>> GetAllPerson()
        {
            var persons = await _personRepository.SelectAll();

            var getPersonDtos = new List<GetPersonDto>();
            foreach (var item in persons)
            {
                var getPersonDto = new GetPersonDto()
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                };

                getPersonDtos.Add(getPersonDto);
            }
            return getPersonDtos;
        }


        #endregion

        #region [- ReadGetPersonByID(*) -]
        public async Task<GetPersonDto?> GetPersonById(int id)
        {
            if (id <= 0)
                return null;

            var person = await _personRepository.SelectByIdAsync(id);

            if (person is null)
                return null;

            var getPersonDto = new GetPersonDto
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName
            };

            return getPersonDto;
        }
        #endregion

        #region [- Update(*) -]
        public async Task Update(UpdatePersonDto updatePersonDto)
        {
            if (updatePersonDto.Id <= 0)
                return;

            var person = new Models.DomainModel.PersonAggregates.Person()
            {
                Id = updatePersonDto.Id,
                FirstName = updatePersonDto.FirstName,
                LastName = updatePersonDto.LastName
            };

            await _personRepository.UpdateAsync(person);

        }
        #endregion

        #region [- Delete(*) -]

        public async Task Delete(DeletePersonDto deletePersonDto)
        {
            if (deletePersonDto.Id <= 0)
                return;

            var person = await _personRepository
                .SelectByIdAsync(deletePersonDto.Id);

            if (person is null)
                return;

            await _personRepository.DeleteAsync(person.Id);
        }

        #endregion
    }
}
