using StoreManagementSystem.Core.Interfaces;
using StoreManagementSystem.Core.Models.Store;
using StoreManagementSystem.Data.Contexts;
using StoreManagementSystem.Data.Entities.Models;

namespace StoreManagementSystem.Core.Services
{
    public class StoreService : IStoreService
    {
        private readonly StoreManagementDbContext dbContext;

        public StoreService(StoreManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateAsync(StoreFormModel storeModel, string ownerId)
        {
            Store store = new Store()
            {
                Title = storeModel.Title,
                Description = storeModel.Description,
                Address = storeModel.Address,
                ImageUrl = storeModel.ImageUrl,
                CityId = storeModel.CityId,
                ProvinceId = storeModel.ProvinceId,
                OwnerId = Guid.Parse(ownerId)
            };

            await dbContext.Stores.AddAsync(store);
            await dbContext.SaveChangesAsync();
        }
    }
}
