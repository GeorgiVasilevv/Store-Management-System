using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using static StoreManagementSystem.Common.EntityModelValidationConstants.Order;

namespace StoreManagementSystem.Data.Entities.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Store))]
        [Required]
        public int StoreId { get; set; }
        public Store Store { get; set; } = null!;

        [ForeignKey(nameof(Product))]
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        [ForeignKey(nameof(User))]
        public Guid? UserId { get; set; }
        public virtual User? User { get; set; } = null!;

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
        public string City { get; set; } = null!;

        [Required]
        public bool IsDeleted { get; set; }
    }
}
