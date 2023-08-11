
using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Core.Services.Interfaces;
using StoreManagementSystem.Core.Services;
using StoreManagementSystem.Data.Contexts;
using static StoreManagementSystem.Tests.DatabaseSeeder;
using StoreManagementSystem.Core.ViewModels.Home;

namespace StoreManagementSystem.Tests.Services
{
    public class HomeServiceTests
    {
        private StoreManagementDbContext dbContext;
        private DbContextOptions<StoreManagementDbContext> dbOptions;

        private IHomeService homeService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            dbOptions = new DbContextOptionsBuilder<StoreManagementDbContext>()
                .UseInMemoryDatabase("StoreManagementInMemory" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new StoreManagementDbContext(dbOptions);

            SeedDatabase(dbContext);

            homeService = new HomeService(dbContext);
        }

        [Test]
        public async Task GetNineMostRecentStoresShouldReturnValidResult()
        {
            // Act
            var result = await homeService.GetNineMostRecentStores();

            // Assert

            var expectedStores = dbContext.Stores
               .Where(s => !s.IsDeleted)
               .OrderByDescending(s => s.DateCreated)
               .Take(9)
               .ToList();

            Assert.That(result.Count(), Is.EqualTo(9));
            for (int i = 0; i < expectedStores.Count; i++)
            {
                Assert.That(result.ElementAt(i).Id, Is.EqualTo(expectedStores[i].Id));
                Assert.That(result.ElementAt(i).Title, Is.EqualTo(expectedStores[i].Title));
                Assert.That(result.ElementAt(i).DateCreated, Is.EqualTo(expectedStores[i].DateCreated));
                Assert.That(result.ElementAt(i).ImageUrl, Is.EqualTo(expectedStores[i].ImageUrl));
            }
        }

        [Test]
        public async Task GetNineMostRecentStoresShouldReturnEmptyList()
        {

            DbContextOptions<StoreManagementDbContext> dbOptions = new DbContextOptionsBuilder<StoreManagementDbContext>()
                .UseInMemoryDatabase("StoreManagementInMemory2" + Guid.NewGuid().ToString())
                .Options;

            StoreManagementDbContext dbContext2 = new StoreManagementDbContext(dbOptions);

            IHomeService homeService2 = new HomeService(dbContext2);

            var result = await homeService2.GetNineMostRecentStores();

            Assert.IsEmpty(result);
        }

        [Test]
        public async Task GetThreeHighestRatingStoresShouldReturnValidResult()
        {
            var result = await homeService.GetThreeHighestRatingStores();

            // Assert
            var expectedStores = dbContext.Stores
                .Where(s => !s.IsDeleted)
                .OrderByDescending(s => s.Rating)
                .Take(3)
                .Select(s => new StoreIndexViewModel()
                {
                    Id = s.Id,
                    Title = s.Title,
                    Rating = s.Rating,
                    ImageUrl = s.ImageUrl,
                })
                .ToList();

            Assert.That(result.Count(), Is.EqualTo(expectedStores.Count));
            for (int i = 0; i < expectedStores.Count; i++)
            {
                Assert.That(result.ElementAt(i).Id, Is.EqualTo(expectedStores[i].Id));
                Assert.That(result.ElementAt(i).Title, Is.EqualTo(expectedStores[i].Title));
                Assert.That(result.ElementAt(i).Rating, Is.EqualTo(expectedStores[i].Rating));
                Assert.That(result.ElementAt(i).ImageUrl, Is.EqualTo(expectedStores[i].ImageUrl));
            }
        }
        [Test]
        public async Task GetThreeHighestRatingStoresShouldReturnEmptyList()
        {
            DbContextOptions<StoreManagementDbContext> dbOptions = new DbContextOptionsBuilder<StoreManagementDbContext>()
                .UseInMemoryDatabase("StoreManagementInMemory2" + Guid.NewGuid().ToString())
                .Options;

            StoreManagementDbContext dbContext2 = new StoreManagementDbContext(dbOptions);

            IHomeService homeService2 = new HomeService(dbContext2);

            var result = await homeService2.GetThreeHighestRatingStores();

            Assert.IsEmpty(result);
        }
    }
}
