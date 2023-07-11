using Microsoft.AspNetCore.Identity;

namespace StoreManagementSystem.Data.Entities.Models
{
    public class User : IdentityUser<Guid>
    {
        //TODO Add Comments
        public User()
        {
            Stores = new List<Store>();
        }

        public ICollection<Store> Stores { get; set; }
    }
}
