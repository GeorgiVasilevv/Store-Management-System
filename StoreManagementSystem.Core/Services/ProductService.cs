using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Core.Models.Store;
using StoreManagementSystem.Core.Models.ViewModels.Products;
using StoreManagementSystem.Core.Services.Interfaces;
using StoreManagementSystem.Data.Contexts;

namespace StoreManagementSystem.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly StoreManagementDbContext dbContext;

        public ProductService(StoreManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<ProductSelectCategoryFormModel>> GetAllCategoriesAsync()
        {
            IEnumerable<ProductSelectCategoryFormModel> allCategories = await dbContext
                .Categories
                .AsNoTracking()
                .Select(c => new ProductSelectCategoryFormModel()
                {
                    Id = c.Id,
                    Title = c.Title,
                })
                .ToArrayAsync();

            return allCategories;
        }
    }
}
