using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Core.Mapping;
using StoreManagementSystem.Core.Models.ServiceModels;
using StoreManagementSystem.Core.Models.ServiceModels.Statistics;
using StoreManagementSystem.Core.Models.Store;
using StoreManagementSystem.Core.Models.ViewModels.Products;
using StoreManagementSystem.Core.Models.ViewModels.Store;
using StoreManagementSystem.Core.Models.ViewModels.Store.Enums;
using StoreManagementSystem.Core.Services.Interfaces;
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
                .Where(s => !s.IsDeleted)
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
                    .Where(s => EF.Functions.Like(s.Title, wildCard) ||
                                EF.Functions.Like(s.Address, wildCard));
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

        public async Task<int> CreateAndReturnIdAsync(StoreAddFormModel storeModel, string ownerId)
        {
            //Store store = new Store()
            //{
            //    Title = storeModel.Title,
            //    Description = storeModel.Description,
            //    Address = storeModel.Address,
            //    ImageUrl = storeModel.ImageUrl,
            //    CityId = storeModel.CityId,
            //    ProvinceId = storeModel.ProvinceId,
            //    OwnerId = Guid.Parse(ownerId)
            //};

            Store store = AutoMapperConfig.MapperInstance.Map<Store>(storeModel);
            store.OwnerId = Guid.Parse(ownerId);

            await dbContext.Stores.AddAsync(store);
            await dbContext.SaveChangesAsync();

            return store.Id;
        }

        public async Task DeleteAsync(int storeId)
        {
            Store storeToDelete = await dbContext
                .Stores
                .Where(s => !s.IsDeleted)
                .FirstAsync(s => s.Id == storeId);

            storeToDelete.IsDeleted = true;

            await dbContext.SaveChangesAsync();
        }

        public async Task<StoreDetailsViewModel> DetailsAsync(int storeId)
        {
            ProductStoreDetailsViewModel[] allProducts = await dbContext.Products
                .Where(p => !p.IsDeleted && p.StoreId == storeId)
                .Select(p => new ProductStoreDetailsViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                })
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

        public async Task EditAsync(int storeId, StoreAddFormModel model)
        {
            Store store = await dbContext
                .Stores
                .Where(s => !s.IsDeleted)
                .FirstAsync(s => s.Id == storeId);


            store.Address = model.Address;
            store.Description = model.Description;
            store.ImageUrl = model.ImageUrl;
            store.ProvinceId = model.ProvinceId;
            store.CityId = model.CityId;
            store.Title = model.Title;

            await dbContext.SaveChangesAsync();

        }

        public async Task<bool> ExistsByIdAsync(int storeId)
        {
            bool result = await dbContext
               .Stores
               .Where(s => !s.IsDeleted)
               .AnyAsync(s => s.Id == storeId);

            return result;
        }

        public async Task<StatisticsServiceModel> GetStatisticsAsync()
        {
            return new StatisticsServiceModel()
            {
                TotalStores = await dbContext.Stores.CountAsync(),
                TotalProducts = await dbContext.Products.CountAsync()
            };
        }

        public async Task<StoreDeleteDetailsViewModel> GetStoreForDeleteAsync(int storeId)
        {
            StoreDeleteDetailsViewModel store = await dbContext
                .Stores
                .Where(s => !s.IsDeleted && s.Id == storeId)
                .Select(s => new StoreDeleteDetailsViewModel()
                {
                    Title = s.Title,
                    Description = s.Description,
                    DateCreated = s.DateCreated,
                    ImageUrl = s.ImageUrl
                })
                .FirstAsync();


            return store;
        }

        public async Task<StoreAddFormModel> GetStoreForEditByIdAsync(int storeId)
        {
            StoreAddFormModel storeModel = await dbContext
                .Stores
                .Where(s => !s.IsDeleted && s.Id == storeId)
                .Select(s => new StoreAddFormModel()
                {
                    Address = s.Address,
                    CityId = s.CityId,
                    Description = s.Description,
                    ImageUrl = s.ImageUrl,
                    ProvinceId = s.ProvinceId,
                    Title = s.Title
                })
                .FirstAsync();

            return storeModel;
        }

        public async Task<bool> IsUserOwnerOfStoreAsync(int storeId, string userId)
        {
            bool isOwner = await dbContext
                .Stores
                .Where(s => !s.IsDeleted && s.Id == storeId)
                .AnyAsync(s => s.OwnerId.ToString() == userId);

            return isOwner;
        }
    }
}
