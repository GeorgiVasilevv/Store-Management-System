
using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Core.Services.Interfaces;
using StoreManagementSystem.Core.Services;
using StoreManagementSystem.Data.Contexts;
using static StoreManagementSystem.Tests.DatabaseSeeder;
using StoreManagementSystem.Core.Models.ViewModels.Store.Enums;
using StoreManagementSystem.Core.Models.ViewModels.Store;
using StoreManagementSystem.Core.Models.Store;

namespace StoreManagementSystem.Tests.Services
{
    public class StoreServiceTests
    {
        private StoreManagementDbContext dbContext;
        private DbContextOptions<StoreManagementDbContext> dbOptions;

        private IStoreService storeService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            dbOptions = new DbContextOptionsBuilder<StoreManagementDbContext>()
                .UseInMemoryDatabase("StoreManagementInMemory" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new StoreManagementDbContext(dbOptions);

            SeedDatabase(dbContext);

            storeService = new StoreService(dbContext);
        }

        [Test]
        public async Task AddRatingAsyncShouldUpdateStoreRating()
        {
            // Arrange
            var storeId = Store.Id;
            var rating = 4;

            // Act
            await storeService.AddRatingAsync(rating, storeId);

            // Assert
            var updatedStore = dbContext.Stores.FirstOrDefault(s => s.Id == storeId);
            Assert.That(updatedStore, Is.Not.Null);
            Assert.That(updatedStore.RatingCount, Is.EqualTo(1));
            Assert.That(updatedStore.RatingSum, Is.EqualTo(rating));
            Assert.That(updatedStore.Rating, Is.EqualTo(rating));
        }

        [Test]
        public async Task AllAsyncShouldReturnFilteredAndPagedStores()
        {
            // Arrange
            var queryModel = new AllStoresQueryModel
            {
                Province = "",
                SearchString = "",
                CurrentPage = 1,
                StoresPerPage = 5,
                StoreSorting = StoreSorting.Newest
            };

            // Act
            var result = await storeService.AllAsync(queryModel);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Stores.Count(), Is.EqualTo(5));
            Assert.That(result.TotalStoresCount, Is.EqualTo(9));
        }

        [Test]
        public async Task AllAsyncShouldReturnEmptyResult()
        {
            // Arrange
            var queryModel = new AllStoresQueryModel
            {
                Province = "NonExistentProvince",
                SearchString = "NonExistentStore",
                CurrentPage = 1,
                StoresPerPage = 5,
                StoreSorting = StoreSorting.Newest
            };

            // Act
            var result = await storeService.AllAsync(queryModel);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsEmpty(result.Stores);
            Assert.That(result.TotalStoresCount, Is.EqualTo(0));
        }

        [Test]
        public async Task AllByUserIdAsyncShouldReturnUserStores()
        {
            // Arrange
            var userId = "F1CCA3DF-6437-423B-6256-08DB7EE9BE60";

            // Act
            var result = await storeService.AllByUserIdAsync(userId);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.EqualTo(9));
        }

        [Test]
        public async Task AllByUserIdAsyncShouldReturnEmptyListForNonExistentUserId()
        {
            // Arrange
            var nonExistentUserId = "NonExistentUserId";

            // Act
            var result = await storeService.AllByUserIdAsync(nonExistentUserId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }

        [Test]
        public async Task AllOrdersAsyncShouldReturnOrdersForStore()
        {
            // Arrange
            var storeId = 1; 

            // Act
            var result = await storeService.AllOrdersAsync(storeId);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.EqualTo(3)); 
        }

        [Test]
        public async Task AllOrdersAsyncShouldReturnEmptyListForNonExistentStore()
        {
            // Arrange
            var nonExistentStoreId = 999;

            // Act
            var result = await storeService.AllOrdersAsync(nonExistentStoreId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsEmpty(result);
        }

        [Test]
        public async Task CreateAndReturnIdAsyncShouldCreateAndReturnId()
        {
            // Arrange
            var ownerId = "F1CCA3DF-6437-423B-6256-08DB7EE9BE60";

            var storeModel = new StoreAddFormModel
            {
                Title = "Test Store",
                Description = "Test description",
                Address = "Test address",
                ImageUrl = "https://example.com/test-image.jpg",
                CityId = 1, 
                ProvinceId = 1, 
            };

            // Act
            var result = await storeService.CreateAndReturnIdAsync(storeModel, ownerId);

            // Assert
            Assert.IsTrue(result > 0);
        }

        [Test]
        public async Task DeleteAsyncShouldMarkStoreAsDeleted()
        {
            // Arrange
            var storeIdToDelete = 1;

            // Act
            await storeService.DeleteAsync(storeIdToDelete);

            // Assert
            var deletedStore = await dbContext.Stores.FirstOrDefaultAsync(s => s.Id == storeIdToDelete && s.IsDeleted);
            Assert.IsNotNull(deletedStore);
        }

        [Test]
        public async Task DeleteOrderAsyncShouldMarkOrderAsDeleted()
        {
            // Arrange
            var orderIdToDelete = 1; 

            // Act
            await storeService.DeleteOrderAsync(orderIdToDelete);

            // Assert
            var deletedOrder = await dbContext.Orders.FirstOrDefaultAsync(o => o.Id == orderIdToDelete && o.IsDeleted);
            Assert.IsNotNull(deletedOrder);
        }

        [Test]
        public async Task DetailsAsync_ShouldReturnStoreDetails()
        {
            // Arrange
            var storeIdToRetrieve = 1; // Replace with the ID of the store you want to retrieve details for

            // Act
            var storeDetails = await storeService.DetailsAsync(storeIdToRetrieve);

            // Assert
            Assert.IsNotNull(storeDetails);
            Assert.That(storeDetails.Id, Is.EqualTo(storeIdToRetrieve));
            // Add more assertions based on your StoreDetailsViewModel properties
            // and expected values from your database seeder
        }
    }
}
