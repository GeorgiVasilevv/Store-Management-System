
using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Core.Services.Interfaces;
using StoreManagementSystem.Core.Services;
using StoreManagementSystem.Data.Contexts;
using static StoreManagementSystem.Tests.DatabaseSeeder;
using StoreManagementSystem.Core.Models.Store;

namespace StoreManagementSystem.Tests.Services
{
    public class ProvinceServiceTests
    {
        private StoreManagementDbContext dbContext;
        private DbContextOptions<StoreManagementDbContext> dbOptions;

        private IProvinceService provinceService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            dbOptions = new DbContextOptionsBuilder<StoreManagementDbContext>()
                .UseInMemoryDatabase("StoreManagementInMemory" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new StoreManagementDbContext(dbOptions);

            SeedDatabase(dbContext);

            provinceService = new ProvinceService(dbContext);
        }

        [Test]
        public async Task AllProvincesNamesAsyncShouldReturnAllProvinceNames()
        {

            // Act
            var provinceNames = await provinceService.AllProvincesNamesAsync();

            // Assert
            var expectedProvinceNames = await dbContext.Provinces.Select(p => p.Title).ToListAsync();

            Assert.That(provinceNames.Count(), Is.EqualTo(expectedProvinceNames.Count));
            Assert.IsTrue(expectedProvinceNames.SequenceEqual(provinceNames));
        }

        [Test]
        public async Task ExistsByIdAsyncProvinceExistsShouldReturnTrue()
        {

            // Act
            var provinceId = 1;
            var exists = await provinceService.ExistsByIdAsync(provinceId);

            // Assert
            Assert.IsTrue(exists);
        }

        [Test]
        public async Task ExistsByIdAsyncProvinceDoesNotExistShouldReturnFalse()
        {

            // Act
            var provinceId = 999; // Set an ID that doesn't exist
            var exists = await provinceService.ExistsByIdAsync(provinceId);

            // Assert
            Assert.IsFalse(exists);
        }

        [Test]
        public async Task GetAllProvincesOrderedAsyncShouldReturnProvincesOrdered()
        {
            //Arrange
            IEnumerable<StoreSelectProvinceFormModel> expectedProvinces = await dbContext.Provinces
                .AsNoTracking()
                .OrderBy(p => p.Title)
                .Select(p => new StoreSelectProvinceFormModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                })
                .ToArrayAsync();

            // Act
            var result = await provinceService.GetAllProvincesOrderedAsync();

            // Assert

            Assert.That(result.First().Title, Is.EqualTo(expectedProvinces.First().Title));
        }
    }
}
