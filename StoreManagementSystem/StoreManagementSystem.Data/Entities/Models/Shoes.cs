using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StoreManagementSystem.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static StoreManagementSystem.Common.EntityModelValidationConstants.Shoes;
namespace StoreManagementSystem.Data.Entities.Models
{
    public class Shoes
    {
        //TODO Add Comments
        public Shoes()
        {
            IsDeleted = false;
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Column(TypeName = "DECIMAL(18, 2)")]
        [Required]
        public decimal Price { get; set; }

        [Required]
        public int AvailableQuantity { get; set; }

        [Required]
        public Condition Condition { get; set; }


        [Required]
        [ForeignKey(nameof(ShoesSize))]
        public int SizeId { get; set; } 
        public ShoesSize ShoesSize { get; set; } = null!;

        [Required]
        [MaxLength(UrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [ForeignKey(nameof(Category))]
        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Store))]
        public int StoreId { get; set; }
        public virtual Store Store { get; set; } = null!;

        [Required]
        public bool IsDeleted { get; set; }
    }
}
