
using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.Core.Models.ViewModels.Store
{
    public class StoreDeleteDetailsViewModel
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        [Display(Name = "Date created")]
        public DateTime DateCreated { get; set; }
        public string ImageUrl { get; set; } = null!;
    }
}
