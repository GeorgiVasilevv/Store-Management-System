using StoreManagementSystem.Core.Models.ServiceModels;
using StoreManagementSystem.Core.Models.ServiceModels.Statistics;
using StoreManagementSystem.Core.Models.Store;
using StoreManagementSystem.Core.Models.ViewModels.Store;

namespace StoreManagementSystem.Core.Services.Interfaces
{
    public interface IStoreService
    {
        Task<int> CreateAndReturnIdAsync(StoreAddFormModel storeModel, string ownerId);
        Task<AllStoresFilteredAndPagedServiceModel> AllAsync(AllStoresQueryModel queryModel);
        Task<IEnumerable<StoreAllViewModel>> AllByUserIdAsync(string userId);
        Task<StoreDetailsViewModel> DetailsAsync(int storeId);
        Task<bool> ExistsByIdAsync(int storeId);
        Task<StoreAddFormModel> GetStoreForEditByIdAsync(int storeId);
        Task<bool> IsUserOwnerOfStoreAsync(int storeId, string userId);
        Task EditAsync(int storeId, StoreAddFormModel model);
        Task<StoreDeleteDetailsViewModel> GetStoreForDeleteAsync(int storeId);
        Task DeleteAsync(int storeId);
        Task<StatisticsServiceModel> GetStatisticsAsync();
        bool RatingExists(int rating);
        Task AddRatingAsync(int rating, int storeId);
        Task<IEnumerable<StoreAllOrdersViewModel>> AllOrdersAsync(int storeId);
        Task<bool> IsUserOwnerOfOrderAsync(int orderId, string userId);
        Task<bool> OrderExistsAsync(int orderId);
        Task DeleteOrderAsync(int id);

    }
}
