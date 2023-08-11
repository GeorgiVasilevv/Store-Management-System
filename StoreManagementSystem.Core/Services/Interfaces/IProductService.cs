using StoreManagementSystem.Core.Models.Store;
using StoreManagementSystem.Core.Models.ViewModels.Products;
using StoreManagementSystem.Core.Models.ViewModels.Store;

namespace StoreManagementSystem.Core.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductSelectCategoryFormModel>> GetAllCategoriesAsync();
        Task<IEnumerable<ProductSelectConditionFormModel>> GetAllConditionsAsync();
        Task<int> CreateAndReturnIdAsync(ProductAddFormModel productModel, int storeId);
        Task<bool> CategoryExistsByIdAsync(int id);
        Task<bool> ConditionExistsByIdAsync(int id);
        Task<bool> ExistsByIdAsync(int productId);
        Task<ProductDetailsViewModel> DetailsAsync(int productId);
        Task<ProductAddFormModel> GetProductForEditByIdAsync(int productId);
        Task EditAsync(int productId, ProductAddFormModel model);
        Task<ProductDeleteDetailsViewModel> GetProductForDeleteAsync(int productId);
        Task DeleteAsync(int productId);
    }
}
