
using StoreManagementSystem.Core.Models.ViewModels.Store.Enums;
using System.ComponentModel.DataAnnotations;
using static StoreManagementSystem.Common.GeneralApplicationConstants;

namespace StoreManagementSystem.Core.Models.ViewModels.Store
{
    public class AllStoresQueryModel
    {
        public AllStoresQueryModel()
        {
            CurrentPage = DefaultPage;
            StoresPerPage = EntitiesPerPage;

            Provinces = new List<string>();
            Stores = new List<StoreAllViewModel>();
        }
        public string? Province { get; set; }

        [Display(Name = "Search by keyword")]
        public string? SearchString { get; set; }

        [Display(Name = "Sort stores by")]
        public StoreSorting? StoreSorting { get; set; }

        public int CurrentPage { get; set; }

        public int TotalStores { get; set; }
        public int StoresPerPage { get; set; }

        public IEnumerable<string> Provinces { get; set; }
        public IEnumerable<StoreAllViewModel> Stores { get; set; }
    }
}
