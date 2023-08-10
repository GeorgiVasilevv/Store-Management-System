using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreManagementSystem.Data.Entities.Models;

namespace StoreManagementSystem.Data.Configurations
{
    public class ConditionEntityConfiguration : IEntityTypeConfiguration<Condition>
    {
        public void Configure(EntityTypeBuilder<Condition> builder)
        {
            builder.HasData(SeedProducts());
        }

        private Condition[] SeedProducts()
        {
            ICollection<Condition> conditions = new List<Condition>();

            Condition condition;

            condition = new Condition()
            {
                Id = 1,
                Title = "New"
            };
            conditions.Add(condition);

            condition = new Condition()
            {
                Id = 2,
                Title = "Used"
            };
            conditions.Add(condition);

            return conditions.ToArray();
        }
    }
}
