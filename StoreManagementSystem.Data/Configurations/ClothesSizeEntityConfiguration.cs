using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManagementSystem.Data.Entities.Models;

namespace StoreManagementSystem.Data.Configurations
{
    public class ClothesSizeEntityConfiguration : IEntityTypeConfiguration<ClothingSize>
    {
        public void Configure(EntityTypeBuilder<ClothingSize> builder)
        {
            builder.HasData(SeedClothesSizes());
        }

        private ClothingSize[] SeedClothesSizes()
        {
            ICollection<ClothingSize> Sizes = new List<ClothingSize>();

            ClothingSize size;

            size = new ClothingSize()
            {
                Id = 1,
                Size = 0
            };
            Sizes.Add(size);

            size = new ClothingSize()
            {
                Id = 2,
                Size = (Entities.Enums.ClothingSize)1
            };
            Sizes.Add(size);

            size = new ClothingSize()
            {
                Id = 3,
                Size = (Entities.Enums.ClothingSize)2
            };
            Sizes.Add(size);

            size = new ClothingSize()
            {
                Id = 4,
                Size = (Entities.Enums.ClothingSize)3
            };
            Sizes.Add(size);

            size = new ClothingSize()
            {
                Id = 5,
                Size = (Entities.Enums.ClothingSize)4
            };
            Sizes.Add(size);

            return Sizes.ToArray();
        }
    }
}
