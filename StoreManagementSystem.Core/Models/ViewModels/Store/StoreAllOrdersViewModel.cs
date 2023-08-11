
using System.ComponentModel.DataAnnotations;


namespace StoreManagementSystem.Core.Models.ViewModels.Store
{
    public class StoreAllOrdersViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
    }
}
