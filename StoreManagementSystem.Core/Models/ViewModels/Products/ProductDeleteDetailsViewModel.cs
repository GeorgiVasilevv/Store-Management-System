

namespace StoreManagementSystem.Core.Models.ViewModels.Products
{
    public class ProductDeleteDetailsViewModel
    {
        public string Title { get; set; } = null!;
        public int StoreId { get; set; }
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = null!;

    }
}
