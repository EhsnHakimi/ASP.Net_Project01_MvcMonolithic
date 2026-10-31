using Microsoft.EntityFrameworkCore;
using MvcMonolithic.Models.DomainModel.PersonAggregates;
using MvcMonolithic.Models.DomainModel.ProductAggregates;
using MvcMonolithic.Models.Services.Contract;

namespace MvcMonolithic.Models.Services.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProjectDbContext _projectDbContext;

        #region [- ctor() -]
        public ProductRepository(ProjectDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
        }
        #endregion

        #region [- CreateInsert() -]
        public async Task insert(Product product)
        {
            try
            {
                _projectDbContext.Add(product);
                await _projectDbContext.SaveChangesAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region [- ReadSelectAll() -]
        public async Task<IEnumerable<Product>> SelectAll()
        {
            try
            {
                return await _projectDbContext.Products.ToListAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region [- ReadSelectById() -]
        public async Task<Product?> SelectByIdAsync(int id)
        {
            if (id <= 0)
                return null;

            return await _projectDbContext.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }
        #endregion

        #region [- Update() -]
        public async Task<Product> UpdateAsync(Product product)
        {
            var updateProduct = await _projectDbContext.Products
            .FindAsync(product.Id);

            if (updateProduct == null)
                return null;

            updateProduct.Title = product.Title;
            updateProduct.UnitPrice = product.UnitPrice;

            await _projectDbContext.SaveChangesAsync();

            return updateProduct;

        }
        #endregion

        #region [- Delete() -]

        public async Task DeleteAsync(int id)
        {
            var product = await _projectDbContext.Products.FindAsync(id);

            if (product is null)
                return;

            _projectDbContext.Products.Remove(product);

            await _projectDbContext.SaveChangesAsync();
        }

        #endregion

    }
}
