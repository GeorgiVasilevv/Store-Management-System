using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static StoreManagementSystem.Common.EntityModelValidationConstants.Store;

namespace StoreManagementSystem.Data.Entities.Models
{
    public class Store
    {
        //TODO Add Comments
        public Store()
        {
            Products = new List<Product>();
            Orders = new List<Order>();
            Rating = 0;
            DateCreated = DateTime.UtcNow;
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;


        [MaxLength(DescriptionMaxLength)]
        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        [Column(TypeName = "DECIMAL(4, 2)")]
        public decimal Rating { get; set; }

        public decimal RatingCount { get; set; }
        public int RatingSum { get; set; }

        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(City))]
        public int CityId { get; set; }
        public City City { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Province))]
        public int ProvinceId { get; set; }
        public Province Province { get; set; } = null!;

        [Required]
        [MaxLength(UrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [ForeignKey(nameof(Owner))]
        [Required]
        public Guid OwnerId { get; set; }
        public virtual User Owner { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    }
}
