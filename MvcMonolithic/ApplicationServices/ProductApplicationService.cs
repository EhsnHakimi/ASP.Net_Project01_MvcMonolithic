using MvcMonolithic.ApplicationServices.Contract;
using MvcMonolithic.ApplicationServices.Dto;
using MvcMonolithic.ApplicationServices.Dto.Product_Dtos;
using MvcMonolithic.Models.Services.Contract;

namespace MvcMonolithic.ApplicationServices
{
    public class ProductApplicationService : IProductApplicationService
    {

        private readonly IProductRepository _productRepository;

        #region [- Ctor() -]
        public ProductApplicationService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion

        #region [- CreatePost() -]
        public async Task Post(PostProductDto postProductDto)
        {
            var product = new Models.DomainModel.ProductAggregates.Product()
            {
                Title = postProductDto.Title,
                UnitPrice = postProductDto.UnitPrice
            };
            await _productRepository.insert(product);
        }
        #endregion

        #region [- ReadGetAllProduct() -]
        public async Task<List<GetProductDto>> GetAllProduct()
        {
            var products = await _productRepository.SelectAll();

            var getProductDtos = new List<GetProductDto>();
            foreach (var item in products)
            {
                var getProductDto = new GetProductDto()
                {
                    Id = item.Id,
                    Title = item.Title,
                    UnitPrice = item.UnitPrice,
                };

                getProductDtos.Add(getProductDto);
            }
            return getProductDtos;
        }


        #endregion

        #region [- ReadGetProductByID() -]
        public async Task<GetProductDto?> GetProductById(int id)
        {
            if (id <= 0)
                return null;

            var product = await _productRepository.SelectByIdAsync(id);

            if (product is null)
                return null;

            var getProductDto = new GetProductDto
            {
                Id = product.Id,
                Title = product.Title,
                UnitPrice = product.UnitPrice
            };

            return getProductDto;
        }
        #endregion

        #region [- Update() -]
        public async Task Update(PutProductDto updateProductDto)
        {
            if (updateProductDto.Id <= 0)
                return;

            var product = new Models.DomainModel.ProductAggregates.Product()
            {
                Id = updateProductDto.Id,
                Title = updateProductDto.Title,
                UnitPrice = updateProductDto.UnitPrice
            };

            await _productRepository.UpdateAsync(product);

        }
        #endregion

        #region [- Delete() -]

        public async Task Delete(DeleteProductDto deleteProductDto)
        {
            if (deleteProductDto.Id <= 0)
                return;

            var product = await _productRepository
                .SelectByIdAsync(deleteProductDto.Id);

            if (product is null)
                return;

            await _productRepository.DeleteAsync(product.Id);
        }
        #endregion
    }
}
