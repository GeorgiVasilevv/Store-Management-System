
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManagementSystem.Data.Entities.Models;

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

            category = new Category()
            {
                Id = 2,
                Title = "Shoes"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 3,
                Title = "Dress"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 4,
                Title = "Pants"
            };
            categories.Add(category);


            return categories.ToArray();
        }
    }
}
