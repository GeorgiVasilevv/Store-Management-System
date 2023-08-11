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
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Store> Stores { get; set; } = null!;
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<Province> Provinces { get; set; } = null!;
        public DbSet<Condition> Conditions { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
           
            Assembly configAssembly = Assembly.GetAssembly(typeof(StoreManagementDbContext)) ?? Assembly.GetExecutingAssembly();

            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);
        }
    }
}