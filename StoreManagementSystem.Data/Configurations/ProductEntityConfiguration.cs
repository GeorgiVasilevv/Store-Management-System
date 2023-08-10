using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManagementSystem.Data.Entities.Models;

namespace StoreManagementSystem.Data.Configurations
{
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder
                .HasOne(p => p.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.CategoryId) // This line of code can be skipped due to Atrributes
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(p => p.Store)
                .WithMany(p => p.Products)
                .HasForeignKey(p => p.StoreId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p=> p.Condition)
                .WithMany(p=> p.Products)
                .HasForeignKey(p => p.ConditionId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(SeedProducts());
        }

        private Product[] SeedProducts()
        {
            ICollection<Product> products = new List<Product>();

            Product product;

            product = new Product()
            {
                Id = 1,
                Title = "T-Shirt - GUESS",
                Description = "Made with 100% cotton",
                Price = 50.99M,
                ConditionId = 1,
                ImageUrl = "https://d010205.bibloo.bg/_galerie/varianty/190/1902771-z.jpg",
                CategoryId = 1,
                StoreId = 1

            };
            products.Add(product);


            return products.ToArray();
        }
    }
}
