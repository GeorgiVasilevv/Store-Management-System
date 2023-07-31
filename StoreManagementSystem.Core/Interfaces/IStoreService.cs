using StoreManagementSystem.Core.Models.ServiceModels;
using StoreManagementSystem.Core.Models.Store;
using StoreManagementSystem.Core.Models.ViewModels.Store;

namespace StoreManagementSystem.Core.Interfaces
{
    public interface IStoreService
    {
        Task CreateAsync(StoreAddFormModel storeModel, string ownerId);
        Task<AllStoresFilteredAndPagedServiceModel> AllAsync(AllStoresQueryModel queryModel);
        Task<IEnumerable<StoreAllViewModel>> AllByUserIdAsync(string userId);
    }
}
