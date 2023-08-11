using StoreManagementSystem.Data.Contexts;
using StoreManagementSystem.Data.Entities.Models;

namespace StoreManagementSystem.Tests
{

    public static class DatabaseSeeder
    {
        public static User User;

        public static City City;
        public static City City2;

        public static Store Store;
        public static Store Store2;
        public static Store Store3;
        public static Store Store4;
        public static Store Store5;
        public static Store Store6;
        public static Store Store7;
        public static Store Store8;
        public static Store Store9;

        public static Product Product;
        public static Product Product2;
        public static Product Product3;
        public static Product Product4;

        public static Category Category;
        public static Category Category2;

        public static Condition Condition;
        public static Condition Condition2;


        public static void SeedDatabase(StoreManagementDbContext dbContext)
        {
            Condition = new Condition()
            {
                Id = 1,
                Title = "New"
            };

            Condition2 = new Condition()
            {
                Id = 2,
                Title = "Used"
            };

            Category = new Category()
            {
                Id = 1,
                Title = "T-Shirt"
            };

            Category2 = new Category()
            {
                Id = 2,
                Title = "Shoes"
            };

            User = new User()
            {
                Id = Guid.Parse("F1CCA3DF-6437-423B-6256-08DB7EE9BE60"),
                UserName = "gosho@abv.bg",
                NormalizedUserName = "GOSHO@ABV.BG",
                Email = "gosho@abv.bg",
                NormalizedEmail = "GOSHO@ABV.BG",
                EmailConfirmed = false,
                PasswordHash = "AQAAAAEAACcQAAAAEFGpWPn+6jEAeZR85KMb15sGP7jV8JGoKVPywMBYfBmWXCzJ7weUlSt/HYLtbd/G0Q==",
                ConcurrencyStamp = "de0ee469-0404-497d-9294-fe571a91561f",
                SecurityStamp = "Z3GDY5KALBJ2YANMSI6OQ4LE2O5CQ6YX",
                TwoFactorEnabled = false,
                FirstName = "Test",
                LastName = "Test",
                Address = "Test street 104",
                CityName = "Vratsa"
            };

            Product = new Product()
            {
                Title = "T-Shirt - GUESS",
                Description = "Made with 100% cotton",
                Price = 50.99M,
                ConditionId = 1,
                ImageUrl = "https://d010205.bibloo.bg/_galerie/varianty/190/1902771-z.jpg",
                CategoryId = 1,
                StoreId = 1
            };

            Product2 = new Product()
            {
                Title = "T-Shirt - GUESS Number 2",
                Description = "Made with 100% cotton",
                Price = 50.99M,
                ConditionId = 1,
                ImageUrl = "https://d010205.bibloo.bg/_galerie/varianty/190/1902771-z.jpg",
                CategoryId = 1,
                StoreId = 1
            };

            Product3 = new Product()
            {
                Title = "T-Shirt - GUESS Number 3",
                Description = "Made with 100% cotton",
                Price = 50.99M,
                ConditionId = 1,
                ImageUrl = "https://d010205.bibloo.bg/_galerie/varianty/190/1902771-z.jpg",
                CategoryId = 1,
                StoreId = 1
            };

            Product4 = new Product()
            {
                Title = "T-Shirt - GUESS Number 3",
                Description = "Made with 100% cotton",
                Price = 50.99M,
                ConditionId = 1,
                ImageUrl = "https://d010205.bibloo.bg/_galerie/varianty/190/1902771-z.jpg",
                CategoryId = 1,
                StoreId = 1
            };

            City = new City()
            {
                Id = 1,
                Title = "Sofia"
            };

            City2 = new City()
            {
                Id = 2,
                Title = "Varna"
            };

            Store3 = new Store()
            {
                Title = "Gosho's store",
                Description = "This store has different types of clothing",
                Rating = 2,
                DateCreated = DateTime.UtcNow.AddHours(-9),
                ImageUrl = "https://bigsee.eu/wp-content/uploads/2022/04/DSC4685.jpg",
                OwnerId = Guid.Parse("F1CCA3DF-6437-423B-6256-08DB7EE9BE60"),
                Address = "ul. Asen Hristoforov 6",
                CityId = 2,
                ProvinceId = 13,
                IsDeleted = false
            };

            Store4 = new Store()
            {
                Title = "Gosho's store",
                Description = "This store has different types of clothing",
                Rating = 9,
                DateCreated = DateTime.UtcNow.AddHours(-8),
                ImageUrl = "https://bigsee.eu/wp-content/uploads/2022/04/DSC4685.jpg",
                OwnerId = Guid.Parse("F1CCA3DF-6437-423B-6256-08DB7EE9BE60"),
                Address = "ul. Asen Hristoforov 6",
                CityId = 2,
                ProvinceId = 13,
                IsDeleted = false
            };

            Store5 = new Store()
            {
                Title = "Gosho's store",
                Description = "This store has different types of clothing",
                Rating = 7,
                DateCreated = DateTime.UtcNow.AddHours(-7),
                ImageUrl = "https://bigsee.eu/wp-content/uploads/2022/04/DSC4685.jpg",
                OwnerId = Guid.Parse("F1CCA3DF-6437-423B-6256-08DB7EE9BE60"),
                Address = "ul. Asen Hristoforov 6",
                CityId = 2,
                ProvinceId = 13,
                IsDeleted = false
            };

            Store6 = new Store()
            {
                Title = "Gosho's store",
                Description = "This store has different types of clothing",
                Rating = 1,
                DateCreated = DateTime.UtcNow.AddHours(-6),
                ImageUrl = "https://bigsee.eu/wp-content/uploads/2022/04/DSC4685.jpg",
                OwnerId = Guid.Parse("F1CCA3DF-6437-423B-6256-08DB7EE9BE60"),
                Address = "ul. Asen Hristoforov 6",
                CityId = 2,
                ProvinceId = 13,
                IsDeleted = false
            };

            Store7 = new Store()
            {
                Title = "Gosho's store",
                Description = "This store has different types of clothing",
                Rating = 2,
                DateCreated = DateTime.UtcNow.AddHours(-5),
                ImageUrl = "https://bigsee.eu/wp-content/uploads/2022/04/DSC4685.jpg",
                OwnerId = Guid.Parse("F1CCA3DF-6437-423B-6256-08DB7EE9BE60"),
                Address = "ul. Asen Hristoforov 6",
                CityId = 2,
                ProvinceId = 13,
                IsDeleted = false
            };

            Store8 = new Store()
            {
                Title = "Gosho's store",
                Description = "This store has different types of clothing",
                Rating = 5,
                DateCreated = DateTime.UtcNow.AddHours(-4),
                ImageUrl = "https://bigsee.eu/wp-content/uploads/2022/04/DSC4685.jpg",
                OwnerId = Guid.Parse("F1CCA3DF-6437-423B-6256-08DB7EE9BE60"),
                Address = "ul. Asen Hristoforov 6",
                CityId = 2,
                ProvinceId = 13,
                IsDeleted = false
            };

            Store9 = new Store()
            {
                Title = "Gosho's store",
                Description = "This store has different types of clothing",
                Rating = 3,
                DateCreated = DateTime.UtcNow.AddHours(-3),
                ImageUrl = "https://bigsee.eu/wp-content/uploads/2022/04/DSC4685.jpg",
                OwnerId = Guid.Parse("F1CCA3DF-6437-423B-6256-08DB7EE9BE60"),
                Address = "ul. Asen Hristoforov 6",
                CityId = 2,
                ProvinceId = 13,
                IsDeleted = false
            };

            Store = new Store()
            {
                Title = "Gosho's designer store",
                Description = "This store is made for designer's brands",
                Rating = 1.23M,
                ImageUrl = "https://cdn.shopify.com/s/files/1/0635/0815/files/claremont-store-iamge_1000x.jpg?v=1667541605",
                DateCreated = DateTime.UtcNow.AddHours(-2),
                OwnerId = Guid.Parse("F1CCA3DF-6437-423B-6256-08DB7EE9BE60"),
                Address = "ul. Petko R. Slaveikov 36",
                CityId = 22,
                ProvinceId = 23,
                IsDeleted = false
            };

            Store2 = new Store()
            {
                Title = "Gosho's store",
                Description = "This store has different types of clothing",
                Rating = 1,
                DateCreated = DateTime.UtcNow.AddHours(-1),
                ImageUrl = "https://bigsee.eu/wp-content/uploads/2022/04/DSC4685.jpg",
                OwnerId = Guid.Parse("F1CCA3DF-6437-423B-6256-08DB7EE9BE60"),
                Address = "ul. Asen Hristoforov 6",
                CityId = 2,
                ProvinceId = 13,
                IsDeleted = false
            };

            



            dbContext.Cities.Add(City);
            dbContext.Cities.Add(City2);

            dbContext.Stores.Add(Store);
            dbContext.Stores.Add(Store2);
            dbContext.Stores.Add(Store3);
            dbContext.Stores.Add(Store4);
            dbContext.Stores.Add(Store5);
            dbContext.Stores.Add(Store6);
            dbContext.Stores.Add(Store7);
            dbContext.Stores.Add(Store8);
            dbContext.Stores.Add(Store9);

            dbContext.Products.Add(Product);
            dbContext.Products.Add(Product2);
            dbContext.Products.Add(Product3);
            dbContext.Products.Add(Product4);

            dbContext.Categories.Add(Category);
            dbContext.Categories.Add(Category2);

            dbContext.Conditions.Add(Condition);
            dbContext.Conditions.Add(Condition2);

            dbContext.SaveChanges();
        }
    }
}
