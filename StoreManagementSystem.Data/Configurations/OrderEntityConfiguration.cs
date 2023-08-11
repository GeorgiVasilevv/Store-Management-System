using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManagementSystem.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagementSystem.Data.Configurations
{
    public class OrderEntityConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasOne(o => o.Store)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.StoreId) // This line of code can be skipped due to Atrributes
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.Product)
                .WithMany(o => o.Orders)
                .HasForeignKey(o => o.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
