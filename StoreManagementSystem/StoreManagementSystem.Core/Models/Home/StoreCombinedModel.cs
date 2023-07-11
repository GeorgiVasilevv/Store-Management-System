using StoreManagementSystem.Core.ViewModels.Home;

namespace StoreManagementSystem.Core.Models.Home
{
    public class StoreCombinedModel
    {
        public IEnumerable<StoreIndexViewModel> RecentStores { get; set; } = null!;
        public IEnumerable<StoreIndexViewModel> TopRatedStores { get; set; } = null!;


    }
}
