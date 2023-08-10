using System.ComponentModel.DataAnnotations;
using static StoreManagementSystem.Common.EntityModelValidationConstants.Condition;

namespace StoreManagementSystem.Data.Entities.Models
{
    public class Condition
    {
        public Condition()
        {
            Products = new List<Product>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        public ICollection<Product> Products { get; set; }
    }
}
