﻿
namespace StoreManagementSystem.Core.Models.ViewModels.Products
{
    public class ProductStoreDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = null!;
    }
}
