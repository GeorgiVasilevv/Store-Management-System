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
            DateCreated = DateTime.UtcNow;
            Clothes = new List<Clothing>();
            Shoes = new List<Shoes>();
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

        [Required]
        [MaxLength(UrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [ForeignKey(nameof(Owner))]
        [Required]
        public Guid OwnerId { get; set; }
        public virtual User Owner { get; set; } = null!;

        public virtual ICollection<Clothing> Clothes { get; set; }
        public virtual ICollection<Shoes> Shoes { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    }
}
