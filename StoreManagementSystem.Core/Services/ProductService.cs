using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Core.Models.ViewModels.Products;
using StoreManagementSystem.Core.Services.Interfaces;
using StoreManagementSystem.Data.Contexts;
using StoreManagementSystem.Data.Entities.Models;

namespace StoreManagementSystem.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly StoreManagementDbContext dbContext;

        public ProductService(StoreManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> CategoryExistsByIdAsync(int id)
        {
            bool result = await dbContext
                .Categories
                .AnyAsync(c => c.Id == id);

            return result;
        }

        public async Task<bool> ConditionExistsByIdAsync(int id)
        {
            bool result = await dbContext
                .Conditions
                .AnyAsync(c => c.Id == id);

            return result;
        }

        public async Task<int> CreateAndReturnIdAsync(ProductAddFormModel productModel, int storeId)
        {
            Product product = new Product()
            {
                Title = productModel.Title,
                Description = productModel.Description,
                Price = productModel.Price,
                ImageUrl = productModel.ImageUrl,
                CategoryId = productModel.CategoryId,
                ConditionId = productModel.ConditionId,
                StoreId = storeId
            };

            await dbContext.Products.AddAsync(product);
            await dbContext.SaveChangesAsync();

            return product.Id;
        }

        public async Task<ProductDetailsViewModel> DetailsAsync(int productId)
        {
            var currentProduct = await dbContext.Products
               .Where(p => !p.IsDeleted && p.Id == productId)
               .Select(p => new ProductDetailsViewModel
               {
                   Id = p.Id,
                   Title = p.Title,
                   Description = p.Description,
                   Price = p.Price,
                   ImageUrl = p.ImageUrl,
                   CategoryName = p.Category.Title,
                   ConditionName = p.Condition.Title
               })
               .FirstAsync();

            return currentProduct;
        }

        public async Task<bool> ExistsByIdAsync(int productId)
        {
            bool result = await dbContext
               .Products
               .Where(s => !s.IsDeleted)
               .AnyAsync(s => s.Id == productId);

            return result;
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

        public async Task<IEnumerable<ProductSelectConditionFormModel>> GetAllConditionsAsync()
        {

            IEnumerable<ProductSelectConditionFormModel> allConditions = await dbContext
                .Conditions
                .AsNoTracking()
                .Select(c => new ProductSelectConditionFormModel()
                {
                    Id = c.Id,
                    Title = c.Title,
                })
                .ToArrayAsync();

            return allConditions;
        }
    }
}
