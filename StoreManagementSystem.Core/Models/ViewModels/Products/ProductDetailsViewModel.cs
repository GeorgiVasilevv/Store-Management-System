
namespace StoreManagementSystem.Core.Models.ViewModels.Products
{
    public class ProductDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string CategoryName { get; set; } = null!;
        public string ConditionName { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
    }
}
