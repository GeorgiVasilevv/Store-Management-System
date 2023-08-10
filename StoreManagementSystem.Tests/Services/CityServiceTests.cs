using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Data.Contexts;

namespace StoreManagementSystem.Tests.Services
{
    public class CityServiceTests
    {
        private StoreManagementDbContext dbContext;
        private DbContextOptions<StoreManagementDbContext> dbOptions;

        public CityServiceTests()
        {
            
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            dbOptions = new DbContextOptionsBuilder<StoreManagementDbContext>()
                .UseInMemoryDatabase("StoreManagementInMemory" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new StoreManagementDbContext(dbOptions);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}