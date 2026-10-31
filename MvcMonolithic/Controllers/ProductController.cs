using Microsoft.AspNetCore.Mvc;
using MvcMonolithic.ApplicationServices.Contract;
using MvcMonolithic.ApplicationServices.Dto;
using MvcMonolithic.ApplicationServices.Dto.Product_Dtos;

namespace MvcMonolithic.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApplicationService _productApplicationService;

        #region [- Ctor() -]
        public ProductController(IProductApplicationService productApplicationService)
        {
            _productApplicationService = productApplicationService;
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
        public async Task<IActionResult> Create(PostProductDto postProductDto)
        {
            ModelState.Remove("Id");

            if (ModelState.IsValid)
            {
                await _productApplicationService.Post(postProductDto);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(postProductDto);

            }
        }
        #endregion

        #region [- ReadIndex() -]
        public async Task<IActionResult> Index()
        {
            var result = await _productApplicationService.GetAllProduct();
            return View(result);
        }
        #endregion

        #region [- ReadDetails() -]
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null || id <= 0)
                return BadRequest();

            var product = await _productApplicationService.GetProductById(id.Value);

            if (product is null)
                return NotFound();

            return View(product);
        }
        #endregion

        #region [- Update() -]
        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id <= 0)
                return BadRequest();

            var product = await _productApplicationService.GetProductById(id.Value);

            if (product is null)
                return NotFound();

            var updateProductDto = new PutProductDto
            {
                Id = product.Id,
                Title = product.Title,
                UnitPrice = product.UnitPrice
            };

            return View(updateProductDto);
        }
        #endregion

        #region [- UpdatePost() -]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(PutProductDto updateProductDto)
        {
            if (!ModelState.IsValid)
                return View(updateProductDto);

            var person = await _productApplicationService.GetProductById(updateProductDto.Id);

            if (person is null)
                return NotFound();

            await _productApplicationService.Update(updateProductDto);

            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region [- Delete() -]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id <= 0)
                return BadRequest();

            var product = await _productApplicationService.GetProductById(id.Value);

            if (product is null)
                return NotFound();

            var deleteProductDto = new DeleteProductDto
            {
                Id = product.Id,
                Title = product.Title,
                UnitPrice = product.UnitPrice
            };

            return View(deleteProductDto);
        }

        #endregion

        #region [- DeletePost() -]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeleteProductDto deleteProductDto)
        {
            var product = await _productApplicationService
                .GetProductById(deleteProductDto.Id);

            if (product is null)
                return NotFound();

            await _productApplicationService.Delete(deleteProductDto);

            return RedirectToAction(nameof(Index));
        }
        #endregion


    }
}
