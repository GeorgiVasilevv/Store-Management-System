using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManagementSystem.Data.Entities.Models;

namespace StoreManagementSystem.Data.Configurations
{
    public class ShoesEntityConfiguration : IEntityTypeConfiguration<Shoes>
    {
        public void Configure(EntityTypeBuilder<Shoes> builder)
        {
            builder
                .HasOne(s => s.ShoesSize)
                .WithMany(s => s.Shoes)
                .HasForeignKey(s => s.SizeId) // This line of code can be skipped due to Atrributes
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(s => s.Category)
                .WithMany(s => s.Shoes)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(s => s.Store)
                .WithMany(s => s.Shoes)
                .HasForeignKey(c => c.StoreId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
