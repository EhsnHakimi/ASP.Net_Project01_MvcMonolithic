using MvcMonolithic.ApplicationServices.Dto.Product_Dtos;

namespace MvcMonolithic.ApplicationServices.Contract
{
    public interface IProductApplicationService
    {
        #region [-GetAllProduct-]
        Task<List<GetProductDto>> GetAllProduct();
        #endregion

        #region [- GetProductById() -]
        Task<GetProductDto> GetProductById(int id);
        #endregion

        #region [- PostProduct() -]
        Task Post(PostProductDto postProductDto); 
        #endregion

        #region [- Update() -]
        Task Update(PutProductDto updateProductDto);
        #endregion

        #region [- Delete() -]
        Task Delete(DeleteProductDto deleteProductDto); 
        #endregion
    }

}
