using StoreManagementSystem.Core.ViewModels.Home;


namespace StoreManagementSystem.Core.Interfaces
{
    public interface IHomeService
    {
        Task<IEnumerable<StoreIndexViewModel>> GetThreeHighestRatingStores();
        Task<IEnumerable<StoreIndexViewModel>> GetNineMostRecentStores();
    }
}
