
using StoreManagementSystem.Core.Models.ViewModels.Store.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.Core.Models.ViewModels.Store
{
    public class StoreAllViewModel : IStoreDetailsModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public decimal Rating { get; set; }

        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}
