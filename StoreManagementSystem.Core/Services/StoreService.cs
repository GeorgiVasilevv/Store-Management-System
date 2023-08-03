using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Core.Interfaces;
using StoreManagementSystem.Core.Models.ServiceModels;
using StoreManagementSystem.Core.Models.Store;
using StoreManagementSystem.Core.Models.ViewModels.Products;
using StoreManagementSystem.Core.Models.ViewModels.Store;
using StoreManagementSystem.Core.Models.ViewModels.Store.Enums;
using StoreManagementSystem.Data.Contexts;
using StoreManagementSystem.Data.Entities.Models;
using System.Linq;

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
            if (queryModel.CurrentPage < 1)
            {
                queryModel.CurrentPage = 1;
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

                _ => storesQuery.OrderByDescending(s => s.OwnerId)
                                .ThenBy(s => s.DateCreated)
            };

            IEnumerable<StoreAllViewModel> allStores = await storesQuery
                .Where(s => !s.IsDeleted)
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

        public async Task<IEnumerable<StoreAllViewModel>> AllByUserIdAsync(string userId)
        {
            IEnumerable<StoreAllViewModel> allUserStores = await dbContext.Stores
                .Where(s => s.OwnerId.ToString() == userId && !s.IsDeleted)
                .Select(s => new StoreAllViewModel()
                {
                    Id = s.Id,
                    Title = s.Title,
                    Address = s.Address,
                    ImageUrl = s.ImageUrl,
                    Rating = s.Rating,
                })
                .ToArrayAsync();

            return allUserStores;
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

        public async Task<StoreDetailsViewModel> DetailsAsync(int storeId)
        {
            ProductStoreDetailsViewModel[] allProducts = await dbContext.Clothes
                .Where(c => !c.IsDeleted && c.StoreId == storeId)
                .Select(c => new ProductStoreDetailsViewModel
                {
                    Title = c.Title,
                    ImageUrl = c.ImageUrl,
                    Price = c.Price,
                })
                .Union(dbContext.Shoes
                .Where(s => !s.IsDeleted && s.StoreId == storeId)
                .Select(s => new ProductStoreDetailsViewModel
                {
                    Title = s.Title,
                    ImageUrl = s.ImageUrl,
                    Price = s.Price,
                }))
                .ToArrayAsync();

            var currentStore = await dbContext.Stores
               .Where(s => !s.IsDeleted && s.Id == storeId)
               .Select(s => new StoreDetailsViewModel
               {
                   Id = s.Id,
                   Title = s.Title,
                   Address = s.Address,
                   ImageUrl = s.ImageUrl,
                   Rating = s.Rating,
                   Description = s.Description,
                   DateCreated = s.DateCreated,
                   CityName = s.City.Title,
                   Products = allProducts,
               })
               .FirstAsync();

            return currentStore;

        }
    }
}
