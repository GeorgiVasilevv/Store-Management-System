using StoreManagementSystem.Core.Models.Store;

namespace StoreManagementSystem.Core.Services.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<StoreSelectCityFormModel>> GetAllCitiesOrderedAsync();
        Task<bool> ExistsByIdAsync(int id);
    }
}
