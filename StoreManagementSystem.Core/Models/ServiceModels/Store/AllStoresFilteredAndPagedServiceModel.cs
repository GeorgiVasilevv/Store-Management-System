using StoreManagementSystem.Core.Models.ViewModels.Store;

namespace StoreManagementSystem.Core.Models.ServiceModels
{
    public class AllStoresFilteredAndPagedServiceModel
    {
        public AllStoresFilteredAndPagedServiceModel()
        {
            Stores = new List<StoreAllViewModel>();
        }
        public int TotalStoresCount { get; set; }
        public IEnumerable<StoreAllViewModel> Stores { get; set; }
    }
}
