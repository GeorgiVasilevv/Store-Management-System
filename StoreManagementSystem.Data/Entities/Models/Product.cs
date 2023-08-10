using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static StoreManagementSystem.Common.EntityModelValidationConstants.Product;

namespace StoreManagementSystem.Data.Entities.Models
{
    public class Product
    {
        //TODO Add Comments
        public Product()
        {
            IsDeleted = false;
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [MaxLength(DescriptionMaxLength)]
        [Required]
        public string Description { get; set; } = null!;

        [Column(TypeName = "DECIMAL(18, 2)")]
        [Required]
        public decimal Price { get; set; }


        [Required]
        [ForeignKey(nameof(Condition))]
        public int ConditionId { get; set; }
        public Condition Condition { get; set; } = null!;


        [Required]
        [MaxLength(UrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Category))]
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
