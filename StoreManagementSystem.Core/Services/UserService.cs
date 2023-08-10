using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Core.Models.ViewModels.User;
using StoreManagementSystem.Core.Services.Interfaces;
using StoreManagementSystem.Data.Contexts;
using StoreManagementSystem.Data.Entities.Models;

namespace StoreManagementSystem.Core.Services
{
    public class UserService : IUserService
    {
        private readonly StoreManagementDbContext dbContext;

        public UserService(StoreManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<UserViewModel>> AllAsync()
        {
            ICollection<UserViewModel> allUsers = await dbContext
                .Users
                .Select(u => new UserViewModel()
                {
                    Id = u.Id.ToString(),
                    Email = u.Email,
                    FullName = u.FirstName + " " + u.LastName,
                    PhoneNumber = u.PhoneNumber,
                })
                .ToListAsync();

            return allUsers;
        }

        public async Task<string> GetFullNameByIdAsync(string userId)
        {
            User? user = await dbContext
                .Users
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }

        public async Task<string> GetUserFullName(string email)
        {
            User? user = await dbContext
                .Users
                .FirstOrDefaultAsync(u=> u.Email == email);

            if (user == null)
            {
                return string.Empty;
            }

            return $"{user.FirstName} {user.LastName}";
        }

        public async Task<bool> HasStoreWithIdAsync(string? userId, int storeId)
        {
            User? user = await dbContext
                .Users
                .Include(u=> u.Stores)
                .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

            if (user == null)
            {
                return false;
            }

            return user.Stores.Any(s=> s.Id == storeId);
        }

        public async Task<bool> IsUserOwnerOfAnyStoreAsync(string userId)
        {
                bool isOwner = await dbContext
                    .Users
                    .Where(u => u.Id.ToString() == userId)
                    .AnyAsync(u => u.Stores.Any());

                return isOwner;
        }
    }
}
