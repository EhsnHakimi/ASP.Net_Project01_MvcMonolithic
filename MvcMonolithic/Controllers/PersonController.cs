using Microsoft.AspNetCore.Mvc;
using MvcMonolithic.ApplicationServices.Contract;
using MvcMonolithic.ApplicationServices.Dto;

namespace MvcMonolithic.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonApplicationService _personApplicationService;
     
        #region [- Ctor() -]
        public PersonController(IPersonApplicationService personApplicationService)
        {
            _personApplicationService = personApplicationService;
        } 
        #endregion

        #region [- Create() -]
        public IActionResult Create()
        {
            return View();
        }
        #endregion

        #region [- CreatePost() -]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostPersonDto postPersonDto)
        {
            ModelState.Remove("Id");

            if (ModelState.IsValid)
            {
                await _personApplicationService.Post(postPersonDto);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(postPersonDto);

            }
        } 
        #endregion

        #region [- ReadIndex() -]
        public async Task<IActionResult> Index()
        {
            var result = await _personApplicationService.GetAllPerson();
            return View(result);
        }
        #endregion

        #region [- ReadDetails() -]
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null || id <= 0)
                return BadRequest();

            var person = await _personApplicationService.GetPersonById(id.Value);

            if (person is null)
                return NotFound();

            return View(person);
        }
        #endregion

        #region [- Update() -]
        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id <= 0)
                return BadRequest();

            var person = await _personApplicationService.GetPersonById(id.Value);

            if (person is null)
                return NotFound();

            var updatePersonDto = new UpdatePersonDto
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName
            };

            return View(updatePersonDto);
        } 
        #endregion

        #region [- UpdatePost() -]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdatePersonDto updatePersonDto)
        {
            if (!ModelState.IsValid)
                return View(updatePersonDto);

            var person = await _personApplicationService.GetPersonById(updatePersonDto.Id);

            if (person is null)
                return NotFound();

            await _personApplicationService.Update(updatePersonDto);

            return RedirectToAction(nameof(Index));
        } 
        #endregion

        #region [- Delete() -]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id <= 0)
                return BadRequest();

            var person = await _personApplicationService.GetPersonById(id.Value);

            if (person is null)
                return NotFound();

            var deletePersonDto = new DeletePersonDto
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName
            };

            return View(deletePersonDto);
        }

        #endregion

        #region [- DeletePost() -]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeletePersonDto deletePersonDto)
        {
            var person = await _personApplicationService
                .GetPersonById(deletePersonDto.Id);

            if (person is null)
                return NotFound();

            await _personApplicationService.Delete(deletePersonDto);

            return RedirectToAction(nameof(Index));
        }
        #endregion



    }
}
