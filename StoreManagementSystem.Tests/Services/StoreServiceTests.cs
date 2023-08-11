
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
            Assert.That(result.Count(), Is.EqualTo(2)); 
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
        public async Task DetailsAsyncShouldReturnStoreDetails()
        {
            // Arrange
            var storeIdToRetrieve = 2;

            // Act
            var storeDetails = await storeService.DetailsAsync(storeIdToRetrieve);

            // Assert
            Assert.IsNotNull(storeDetails);
            Assert.That(storeDetails.Id, Is.EqualTo(storeIdToRetrieve));
            
        }

        [Test]
        public async Task EditAsyncShouldUpdateStoreDetails()
        {
            // Arrange
            var storeIdToEdit = 9; 
            var newStoreData = new StoreAddFormModel
            {
                
                Address = "New Address",
                Description = "New Description",
                ImageUrl = "new-image-url.jpg",
                ProvinceId = 2, 
                CityId = 2, 
                Title = "New Title"
            };

            // Act
            await storeService.EditAsync(storeIdToEdit, newStoreData);

            // Assert
            var editedStore = await dbContext.Stores
                .Where(s => !s.IsDeleted && s.Id == storeIdToEdit)
                .FirstOrDefaultAsync();

            Assert.IsNotNull(editedStore);
            Assert.That(editedStore.Address, Is.EqualTo(newStoreData.Address));
            Assert.That(editedStore.Description, Is.EqualTo(newStoreData.Description));
            Assert.That(editedStore.ImageUrl, Is.EqualTo(newStoreData.ImageUrl));
            Assert.That(editedStore.ProvinceId, Is.EqualTo(newStoreData.ProvinceId));
            Assert.That(editedStore.CityId, Is.EqualTo(newStoreData.CityId));
            Assert.That(editedStore.Title, Is.EqualTo(newStoreData.Title));
        }

        [Test]
        public async Task ExistsByIdAsyncShouldReturnTrueForExistingStoreId()
        {
            // Arrange
            var existingStoreId = 2;
            // Act
            var exists = await storeService.ExistsByIdAsync(existingStoreId);

            // Assert
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task ExistsByIdAsyncShouldReturnFalseForNonExistingStoreId()
        {
            // Arrange
            var nonExistingStoreId = 999;

            // Act
            var exists = await storeService.ExistsByIdAsync(nonExistingStoreId);

            // Assert
            Assert.IsFalse(exists);
        }

        [Test]
        public async Task GetStatisticsAsyncShouldReturnCorrectStatistics()
        {
            // Act
            var statistics = await storeService.GetStatisticsAsync();

            // Assert
            Assert.That(statistics.TotalStores, Is.EqualTo(await dbContext.Stores.CountAsync()));
            Assert.That(statistics.TotalProducts, Is.EqualTo(await dbContext.Products.CountAsync()));
        }

        [Test]
        public async Task GetStoreForDeleteAsyncShouldReturnCorrectStoreDetails()
        {
            // Arrange
            int storeId = 2;
            var storeDescription = "This store has different types of clothing";

            // Act
            var storeDetails = await storeService.GetStoreForDeleteAsync(storeId);

            // Assert
            Assert.IsNotNull(storeDetails);
            Assert.That(storeDetails.Description, Is.EqualTo(storeDescription));
        }

        [Test]
        public async Task GetStoreForEditByIdAsyncShouldReturnCorrectStoreModel()
        {
            // Arrange
            int storeId = 2;

            // Act
            var storeModel = await storeService.GetStoreForEditByIdAsync(storeId);

            // Assert
            Assert.IsNotNull(storeModel);
        }

        [Test]
        public async Task IsUserOwnerOfOrderAsyncShouldReturnTrueForOwner()
        {
            // Arrange
            int orderId = 3; 
            string ownerId = "F1CCA3DF-6437-423B-6256-08DB7EE9BE60"; 

            // Act
            var isOwner = await storeService.IsUserOwnerOfOrderAsync(orderId, ownerId);

            // Assert
            Assert.IsTrue(isOwner);
        }

        [Test]
        public async Task IsUserOwnerOfOrderAsyncShouldReturnFalseForNonOwner()
        {
            // Arrange
            int orderId = 1; 
            string nonOwnerId = "NonExistentUserId"; 

            // Act
            var isOwner = await storeService.IsUserOwnerOfOrderAsync(orderId, nonOwnerId);

            // Assert
            Assert.IsFalse(isOwner);
        }

        [Test]
        public async Task IsUserOwnerOfStoreAsyncShouldReturnTrueForOwner()
        {
            // Arrange
            int storeId = 2; 
            string ownerId = "F1CCA3DF-6437-423B-6256-08DB7EE9BE60"; 

            // Act
            var isOwner = await storeService.IsUserOwnerOfStoreAsync(storeId, ownerId);

            // Assert
            Assert.IsTrue(isOwner);
        }

        [Test]
        public async Task IsUserOwnerOfStoreAsyncShouldReturnFalseForNonOwner()
        {
            // Arrange
            int storeId = 1; 
            string nonOwnerId = "NonExistentUserId"; 

            // Act
            var isOwner = await storeService.IsUserOwnerOfStoreAsync(storeId, nonOwnerId);

            // Assert
            Assert.IsFalse(isOwner);
        }

        [Test]
        public async Task OrderExistsAsyncShouldReturnTrueForExistingOrder()
        {
            // Arrange
            int existingOrderId = 1; 
            // Act
            var exists = await storeService.OrderExistsAsync(existingOrderId);

            // Assert
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task OrderExistsAsyncShouldReturnFalseForNonExistingOrder()
        {
            // Arrange
            int nonExistingOrderId = -1; 

            // Act
            var exists = await storeService.OrderExistsAsync(nonExistingOrderId);

            // Assert
            Assert.IsFalse(exists);
        }


        [TestCase(0)]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(-1)]
        [TestCase(11)]
        public void RatingExistsShouldReturnExpectedResult(int rating)
        {
            // Act
            bool result = storeService.RatingExists(rating);

            // Assert
            Assert.IsTrue(result == (rating >= 0 && rating <= 10));
        }
    }
}
