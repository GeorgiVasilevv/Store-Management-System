using StoreManagementSystem.Core.ViewModels.Home;


namespace StoreManagementSystem.Core.Services.Interfaces
{
    public interface IHomeService
    {
        Task<IEnumerable<StoreIndexViewModel>> GetThreeHighestRatingStores();
        Task<IEnumerable<StoreIndexViewModel>> GetNineMostRecentStores();
    }
}
