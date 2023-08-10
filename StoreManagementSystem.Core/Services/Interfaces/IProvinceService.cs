using StoreManagementSystem.Core.Models.Store;

namespace StoreManagementSystem.Core.Services.Interfaces
{
    public interface IProvinceService
    {
        Task<IEnumerable<StoreSelectProvinceFormModel>> GetAllProvincesOrderedAsync();
        Task<bool> ExistsByIdAsync(int id);
        Task<IEnumerable<string>> AllProvincesNamesAsync();

    }
}
