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
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(SeedCategories());
        }

        private Category[] SeedCategories()
        {
            ICollection<Category> categories = new List<Category>();

            Category category;

            category = new Category()
            {
                Id = 1,
                Title = "T-Shirt"
            };
            categories.Add(category);

            return categories.ToArray();
        }
    }
}
