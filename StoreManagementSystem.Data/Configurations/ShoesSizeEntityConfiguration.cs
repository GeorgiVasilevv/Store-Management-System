using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManagementSystem.Data.Entities.Models;

namespace StoreManagementSystem.Data.Configurations
{
    public class ShoesSizeEntityConfiguration : IEntityTypeConfiguration<ShoesSize>
    {
        public void Configure(EntityTypeBuilder<ShoesSize> builder)
        {
            builder.HasData(SeedShoesSizes());
        }

        private ShoesSize[] SeedShoesSizes()
        {
            ICollection<ShoesSize> Sizes = new List<ShoesSize>();

            ShoesSize size;
            
            size = new ShoesSize()
            {
                Id = 1,
                SizeNumber = 34
            };
            Sizes.Add(size);

            size = new ShoesSize()
            {
                Id = 2,
                SizeNumber = 35
            };
            Sizes.Add(size);

            size = new ShoesSize()
            {
                Id = 3,
                SizeNumber = 36
            };
            Sizes.Add(size);

            size = new ShoesSize()
            {
                Id = 4,
                SizeNumber = 37
            };
            Sizes.Add(size);

            size = new ShoesSize()
            {
                Id = 5,
                SizeNumber = 38
            };
            Sizes.Add(size);

            size = new ShoesSize()
            {
                Id = 6,
                SizeNumber = 39
            };
            Sizes.Add(size);

            size = new ShoesSize()
            {
                Id = 7,
                SizeNumber = 40
            };
            Sizes.Add(size);

            size = new ShoesSize()
            {
                Id = 8,
                SizeNumber = 41
            };
            Sizes.Add(size);

            size = new ShoesSize()
            {
                Id = 9,
                SizeNumber = 42
            };
            Sizes.Add(size);

            size = new ShoesSize()
            {
                Id = 10,
                SizeNumber = 43
            };
            Sizes.Add(size);

            size = new ShoesSize()
            {
                Id = 11,
                SizeNumber = 44
            };
            Sizes.Add(size);

            size = new ShoesSize()
            {
                Id = 12,
                SizeNumber = 45
            };
            Sizes.Add(size);

            size = new ShoesSize()
            {
                Id = 13,
                SizeNumber = 46
            };
            Sizes.Add(size);

            size = new ShoesSize()
            {
                Id = 14,
                SizeNumber = 47
            };
            Sizes.Add(size);

            return Sizes.ToArray();
        }
    }
}
