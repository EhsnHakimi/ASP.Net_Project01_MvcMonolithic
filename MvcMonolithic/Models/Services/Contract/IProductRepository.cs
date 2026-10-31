using MvcMonolithic.Models.DomainModel.ProductAggregates;

namespace MvcMonolithic.Models.Services.Contract
{
    public interface IProductRepository
    {
        #region [-Insert-]

        Task insert(Product product);
        #endregion    

        #region [-SelectAll-]
        Task<IEnumerable<Product>> SelectAll();

        #endregion

        #region [-Update-]
        Task<Product> UpdateAsync(Product product);

        #endregion

        #region [- Delete() -]
        Task DeleteAsync(int id);
        #endregion

        #region [- SelectById() -]
        Task<Product> SelectByIdAsync(int id);
        #endregion
    }
}
