using System.ComponentModel.DataAnnotations;
using static StoreManagementSystem.Common.EntityModelValidationConstants.Category;

namespace StoreManagementSystem.Data.Entities.Models
{
    public class Category
    {
        //TODO Add Comments
        public Category()
        {
            Shoes = new List<Shoes>();
            Clothes = new List<Clothing>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        public ICollection<Clothing> Clothes { get; set; }
        public ICollection<Shoes> Shoes { get; set; }
    }
}
