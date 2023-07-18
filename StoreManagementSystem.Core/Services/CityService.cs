using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Core.Interfaces;
using StoreManagementSystem.Core.Models.Store;
using StoreManagementSystem.Data.Contexts;
using System.Collections.Generic;

namespace StoreManagementSystem.Core.Services
{
    public class CityService : ICityService
    {
        private readonly StoreManagementDbContext dbContext;

        public CityService(StoreManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            bool result =  await dbContext.Cities.AnyAsync(c=> c.Id == id);

            return result;
        }

        public async Task<IEnumerable<StoreSelectCityFormModel>> GetAllCitiesOrderedAsync()
        {
            IEnumerable<StoreSelectCityFormModel> allCities = await dbContext
                .Cities
                .AsNoTracking()
                .Select(c => new StoreSelectCityFormModel()
                {
                    Id = c.Id,
                    Title = c.Title,
                })
                .OrderBy(p => p.Title)
                .ToArrayAsync();

            return allCities;
        }
    }
}
