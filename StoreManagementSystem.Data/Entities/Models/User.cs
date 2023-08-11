using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static StoreManagementSystem.Common.EntityModelValidationConstants.User;

namespace StoreManagementSystem.Data.Entities.Models
{
    public class User : IdentityUser<Guid>
    {
        //TODO Add Comments
        public User()
        {
            Id = Guid.NewGuid();

            Stores = new List<Store>();
            Orders = new List<Order>();
        }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        [MaxLength(CityMaxLength)]
        public string CityName { get; set; } = null!;

        public virtual ICollection<Store> Stores { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
