using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManagementSystem.Data.Entities.Models;

namespace StoreManagementSystem.Data.Configurations
{
    public class StoreEntityConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder
              .HasOne(s => s.Province)
              .WithMany(s => s.Stores)
              .HasForeignKey(s => s.ProvinceId) // This line of code can be skipped due to Atrributes
              .OnDelete(DeleteBehavior.NoAction);

            builder
              .HasOne(s => s.City)
              .WithMany(s=> s.Stores)
              .HasForeignKey(s=> s.CityId) // This line of code can be skipped due to Atrributes
              .OnDelete(DeleteBehavior.NoAction);

            builder.Property(s => s.DateCreated)
                .HasDefaultValueSql("GETDATE()");

            builder.HasData(SeedStores());
        }

        private Store[] SeedStores()
        {
            ICollection<Store> stores = new List<Store>();

            Store store;

            store = new Store()
            {
                Id = 1,
                Title = "Gosho's designer store",
                Description = "This store is made for designer's brands",
                Rating = 0,
                ImageUrl = "https://cdn.shopify.com/s/files/1/0635/0815/files/claremont-store-iamge_1000x.jpg?v=1667541605",
                OwnerId = Guid.Parse("F1CCA3DF-6437-423B-6256-08DB7EE9BE60"),
                Address = "ul. Petko R. Slaveikov 36",
                CityId = 22,
                ProvinceId = 23
            };
            stores.Add(store);

            store = new Store()
            {
                Id = 2,
                Title = "Gosho's store",
                Description = "This store has different types of clothing",
                Rating = 0,
                ImageUrl = "https://bigsee.eu/wp-content/uploads/2022/04/DSC4685.jpg",
                OwnerId = Guid.Parse("F1CCA3DF-6437-423B-6256-08DB7EE9BE60"),
                Address = "ul. Asen Hristoforov 6",
                CityId = 2,
                ProvinceId = 13
            };
            stores.Add(store);


            store = new Store()
            {
                Id = 3,
                Title = "Gosho's sneaker store",
                Description = "This store has different types of sneakers",
                Rating = 0,
                ImageUrl = "https://planomagazine.com/wp-content/uploads/2021/04/Plano-Magazine-Prized-Kicks-sneaker-store-now-open_feature-1170x556.jpg",
                OwnerId = Guid.Parse("F1CCA3DF-6437-423B-6256-08DB7EE9BE60"),
                Address = "bul. Cherni Vrah 47",
                CityId = 1,
                ProvinceId = 20
            };
            stores.Add(store);

            store = new Store()
            {
                Id = 4,
                Title = "Vanko's designer store",
                Description = "This store has different types of designer wear",
                ImageUrl = "https://media.architecturaldigest.com/photos/56045fcfcbec99cc0f9f7574/16:9/w_1280,c_limit/dam-images-daily-2014-10-jill-stuart-jill-stuart-soho.jpg",
                OwnerId = Guid.Parse("96521533-2970-4085-B6D0-08DB81187EB1"),
                Address = "ul. Mara Buneva 52",
                CityId = 1,
                ProvinceId = 20
            };
            stores.Add(store);



            return stores.ToArray();
        }
    }
}
