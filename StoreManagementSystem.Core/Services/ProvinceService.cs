using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Core.Interfaces;
using StoreManagementSystem.Core.Models.Store;
using StoreManagementSystem.Data.Contexts;

namespace StoreManagementSystem.Core.Services
{
    public class ProvinceService : IProvinceService
    {
        private readonly StoreManagementDbContext dbContext;

        public ProvinceService(StoreManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<string>> AllProvincesNamesAsync()
        {
            IEnumerable<string> allNames = await dbContext
                .Provinces
                .Select(p => p.Title)
                .ToArrayAsync();

            return allNames;
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            bool result = await dbContext
                .Provinces
                .AnyAsync(p => p.Id == id);

            return result;
        }

        public async Task<IEnumerable<StoreSelectProvinceFormModel>> GetAllProvincesOrderedAsync()
        {
            IEnumerable<StoreSelectProvinceFormModel> allProvinces = await dbContext
                .Provinces
                .AsNoTracking()
                .Select(p => new StoreSelectProvinceFormModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                })
                .OrderBy(p => p.Title)
                .ToArrayAsync();

            return allProvinces;
        }
    }
}
