using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Core.Models.Store;
using StoreManagementSystem.Core.Services;
using StoreManagementSystem.Core.Services.Interfaces;
using StoreManagementSystem.Data.Contexts;
using static StoreManagementSystem.Tests.DatabaseSeeder;

namespace StoreManagementSystem.Tests.Services
{
    public class CityServiceTests
    {
        private StoreManagementDbContext dbContext;
        private DbContextOptions<StoreManagementDbContext> dbOptions;

        private ICityService cityService;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            dbOptions = new DbContextOptionsBuilder<StoreManagementDbContext>()
                .UseInMemoryDatabase("StoreManagementInMemory" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new StoreManagementDbContext(dbOptions);

            SeedDatabase(dbContext);

            cityService = new CityService(dbContext);
        }


        [Test]
        public async Task ExistsByIdAsyncShoudReturnTrueWhenExits()
        {
            int CityId = City.Id;

            bool result = await cityService.ExistsByIdAsync(CityId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistsByIdAsyncShoudReturnFalseWhenExits()
        {
            int wrongCityId = 123123;

            bool result = await cityService.ExistsByIdAsync(wrongCityId);

            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetAllCitiesOrderedAsyncShoudReturnOneModelWhenExits()
        {

            var result = await cityService.GetAllCitiesOrderedAsync();
            var orderedCities = result.ToList();

            Assert.That(orderedCities.Count, Is.EqualTo(2));
            Assert.That(orderedCities[0].Title, Is.EqualTo(City.Title));
            Assert.That(orderedCities[1].Title, Is.EqualTo(City2.Title));
        }
        
    }
}