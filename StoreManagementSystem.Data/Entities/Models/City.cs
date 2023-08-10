using System.ComponentModel.DataAnnotations;

namespace StoreManagementSystem.Data.Entities.Models
{
    public class City
    {
        //TODO Add Comments
        public City()
        {
            Stores = new List<Store>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        public ICollection<Store> Stores { get; set; }

    }
}
