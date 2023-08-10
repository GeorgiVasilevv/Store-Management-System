using System.ComponentModel.DataAnnotations;


namespace StoreManagementSystem.Data.Entities.Models
{
    public class Province
    {
        //TODO Add Comments
        public Province()
        {
            Stores = new List<Store>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = null!;

        public virtual ICollection<Store> Stores { get; set; }
    }
}
