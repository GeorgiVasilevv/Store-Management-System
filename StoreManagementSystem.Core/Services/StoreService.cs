using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Core.Interfaces;
using StoreManagementSystem.Core.Models.ServiceModels;
using StoreManagementSystem.Core.Models.Store;
using StoreManagementSystem.Core.Models.ViewModels.Store;
using StoreManagementSystem.Core.Models.ViewModels.Store.Enums;
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

        public async Task<AllStoresFilteredAndPagedServiceModel> AllAsync(AllStoresQueryModel queryModel)
        {
            IQueryable<Store> storesQuery = dbContext
                .Stores
                .AsQueryable();


            if (!string.IsNullOrWhiteSpace(queryModel.Province))
            {
                storesQuery = storesQuery
                    .Where(s => s.Province.Title == queryModel.Province);
            }
            if (!string.IsNullOrWhiteSpace(queryModel.SearchString))
            {
                string wildCard = $"%{queryModel.SearchString.ToLower()}%";

                storesQuery = storesQuery
                    .Where(h => EF.Functions.Like(h.Title, wildCard) ||
                                EF.Functions.Like(h.Address, wildCard));
            }

            storesQuery = queryModel.StoreSorting switch
            {
                StoreSorting.Oldest => storesQuery
                    .OrderBy(s => s.DateCreated),

                StoreSorting.Newest => storesQuery
                    .OrderByDescending(s => s.DateCreated),

                StoreSorting.RatingDescending => storesQuery
                    .OrderByDescending(s => s.Rating),

                StoreSorting.RatingAscending => storesQuery
                    .OrderBy(s => s.Rating),

                _ => storesQuery.OrderByDescending(s=> s.Id)
                                .ThenBy(s=> s.DateCreated)
            };

            IEnumerable<StoreAllViewModel> allStores = await storesQuery
                .Skip((queryModel.CurrentPage - 1) * queryModel.StoresPerPage)
                .Take(queryModel.StoresPerPage)
                .Select(s => new StoreAllViewModel()
                {
                    Id = s.Id,
                    Title = s.Title,
                    Address = s.Address,
                    ImageUrl = s.ImageUrl,
                    Rating = s.Rating,
                })
                .ToArrayAsync();

            int totalStores = storesQuery.Count();

            return new AllStoresFilteredAndPagedServiceModel()
            {
                TotalStoresCount = totalStores,
                Stores = allStores
            };
        }

        public async Task CreateAsync(StoreAddFormModel storeModel, string ownerId)
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
