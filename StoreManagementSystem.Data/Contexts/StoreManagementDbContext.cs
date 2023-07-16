using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Data.Entities.Models;
using System.Reflection;

namespace StoreManagementSystem.Data.Contexts
{
    public class StoreManagementDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public StoreManagementDbContext(DbContextOptions<StoreManagementDbContext> options)
            : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Clothing> Clothes { get; set; } = null!;
        public DbSet<Shoes> Shoes { get; set; } = null!;
        public DbSet<ShoesSize> ShoesSizes { get; set; } = null!;
        public DbSet<Store> Stores { get; set; } = null!;
        public DbSet<ClothingSize> ClothesSizes { get; set; } = null!;
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<Province> Provinces { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
           
            Assembly configAssembly = Assembly.GetAssembly(typeof(StoreManagementDbContext)) ?? Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);
        }
    }
}