using StoreManagementSystem.Core.Models.ViewModels.Products;
using StoreManagementSystem.Core.Models.ViewModels.Products.Clothing;
using StoreManagementSystem.Core.Models.ViewModels.Products.Shoes;
using StoreManagementSystem.Core.Models.ViewModels.Store.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagementSystem.Core.Models.ViewModels.Store
{
    public class StoreDetailsViewModel : StoreAllViewModel , IStoreDetailsModel
    {
        public StoreDetailsViewModel()
        {
            Products = new List<ProductStoreDetailsViewModel>();
        }
        public string Description { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public string CityName { get; set; } = null!;
        public ICollection<ProductStoreDetailsViewModel> Products { get; set; }
    }
}
