using Microsoft.EntityFrameworkCore;
using StoreManagementSystem.Core.Interfaces;
using StoreManagementSystem.Data.Contexts;
using StoreManagementSystem.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagementSystem.Core.Services
{
    public class UserService : IUserService
    {
        private readonly StoreManagementDbContext dbContext;

        public UserService(StoreManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
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
    }
}
