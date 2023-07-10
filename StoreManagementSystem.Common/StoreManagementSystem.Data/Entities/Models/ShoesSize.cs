using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.Data.Entities.Models
{
    public class ShoesSize
    {
        //TODO Add Comments
        public ShoesSize()
        {
            Shoes = new List<Shoes>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public int SizeNumber { get; set; }

        public ICollection<Shoes> Shoes { get; set; }
    }
}
