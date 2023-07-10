using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManagementSystem.Data.Entities.Models;

namespace StoreManagementSystem.Data.Configurations
{
    public class ClothingEntityConfiguration : IEntityTypeConfiguration<Clothing>
    {
        public void Configure(EntityTypeBuilder<Clothing> builder)
        {

            builder
               .HasOne(c => c.ClothingSize)
               .WithMany(c => c.Clothes)
               .HasForeignKey(c => c.ClothingSizeId) // This line of code can be skipped due to Atrributes
               .OnDelete(DeleteBehavior.NoAction);

            builder
               .HasOne(c => c.Category)
               .WithMany(c => c.Clothes)
               .HasForeignKey(c => c.CategoryId)
               .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(c => c.Store)
                .WithMany(c => c.Clothes)
                .HasForeignKey(c => c.StoreId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(SeedClothes());
        }

        private Clothing[] SeedClothes()
        {
            ICollection<Clothing> clothes = new List<Clothing>();

            Clothing clothing;

            clothing = new Clothing()
            {
                Id = 1,
                Title = "T-Shirt - GUESS",
                Description = "Made with 100% cotton",
                Price = 50.99M,
                AvailableQuantity = 4,
                Condition = (Entities.Enums.Condition)0,
                ClothingSizeId = 1,
                ImageUrl = "https://d010205.bibloo.bg/_galerie/varianty/190/1902771-z.jpg",
                CategoryId = 1,
                StoreId = 1

            };
            clothes.Add(clothing);


            return clothes.ToArray();
        }
    }
}
