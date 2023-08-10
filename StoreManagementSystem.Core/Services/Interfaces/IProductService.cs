using StoreManagementSystem.Core.Models.Store;
using StoreManagementSystem.Core.Models.ViewModels.Products;

namespace StoreManagementSystem.Core.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductSelectCategoryFormModel>> GetAllCategoriesAsync();
    }
}
