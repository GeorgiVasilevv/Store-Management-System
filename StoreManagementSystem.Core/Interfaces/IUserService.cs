using StoreManagementSystem.Core.Models.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagementSystem.Core.Interfaces
{
    public interface IUserService
    {
        Task<bool> HasStoreWithIdAsync(string? userId, int storeId);
        Task<string> GetUserFullName(string email);

        Task<string> GetFullNameByIdAsync(string userId);
        Task<IEnumerable<UserViewModel>> AllAsync();
        Task<bool> IsUserOwnerOfAnyStoreAsync(string userId);
    }
}
