using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManagementSystem.Data.Entities.Models;

namespace StoreManagementSystem.Data.Configurations
{
    public class StoreEntityConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasData(SeedStores());
        }

        private Store[] SeedStores()
        {
            ICollection<Store> stores = new List<Store>();

            Store store;

            store = new Store()
            {
                Id = 1,
                Title = "Gosho's store",
                Description = "This store is made for designer's brands",
                Rating = 0,
                ImageUrl = "https://cdn.shopify.com/s/files/1/0635/0815/files/claremont-store-iamge_1000x.jpg?v=1667541605",
                OwnerId = Guid.Parse("F1CCA3DF-6437-423B-6256-08DB7EE9BE60"),
            };
            stores.Add(store);

            return stores.ToArray();
        }
    }
}
