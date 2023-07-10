using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManagementSystem.Data.Entities.Models;

namespace StoreManagementSystem.Data.Configurations
{
    public class ClothesSizeEntityConfiguration : IEntityTypeConfiguration<ClothesSize>
    {
        public void Configure(EntityTypeBuilder<ClothesSize> builder)
        {
            builder.HasData(SeedClothesSizes());
        }

        private ClothesSize[] SeedClothesSizes()
        {
            ICollection<ClothesSize> Sizes = new List<ClothesSize>();

            ClothesSize size;

            size = new ClothesSize()
            {
                Id = 1,
                Size = 0
            };
            Sizes.Add(size);

            size = new ClothesSize()
            {
                Id = 2,
                Size = (Entities.Enums.ClothingSize)1
            };
            Sizes.Add(size);

            size = new ClothesSize()
            {
                Id = 3,
                Size = (Entities.Enums.ClothingSize)2
            };
            Sizes.Add(size);

            size = new ClothesSize()
            {
                Id = 4,
                Size = (Entities.Enums.ClothingSize)3
            };
            Sizes.Add(size);

            size = new ClothesSize()
            {
                Id = 5,
                Size = (Entities.Enums.ClothingSize)4
            };
            Sizes.Add(size);

            return Sizes.ToArray();
        }
    }
}
