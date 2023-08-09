using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Core.Interfaces;
using StoreManagementSystem.Core.Mapping;
using StoreManagementSystem.Core.ViewModels.Home;
using StoreManagementSystem.Data.Contexts;


namespace StoreManagementSystem.Core.Services
{
    public class HomeService : IHomeService
    {
        private readonly StoreManagementDbContext dbContext;

        public HomeService(StoreManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<StoreIndexViewModel>> GetNineMostRecentStores()
        {
            return await dbContext
                .Stores
                .Where(s=> s.IsDeleted == false)
                .OrderByDescending(s=> s.DateCreated)
                .Take(9)
                .To<StoreIndexViewModel>()
                .ToArrayAsync();
        }

        public async Task<IEnumerable<StoreIndexViewModel>> GetThreeHighestRatingStores()
        {
            return await dbContext
                .Stores
                .Where(s => s.IsDeleted == false)
                .OrderByDescending(s => s.Rating)
                .Take(3)
                .To<StoreIndexViewModel>()
                .ToArrayAsync();
        }
    }
}
