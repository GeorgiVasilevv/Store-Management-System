using StoreManagementSystem.Core.Models.Store;
using StoreManagementSystem.Core.Models.ViewModels.Products;

namespace StoreManagementSystem.Core.Services.Interfaces
{
    public interface IProvinceService
    {
        Task<IEnumerable<StoreSelectProvinceFormModel>> GetAllProvincesOrderedAsync();
        Task<bool> ExistsByIdAsync(int id);
        Task<IEnumerable<string>> AllProvincesNamesAsync();
        

    }
}
