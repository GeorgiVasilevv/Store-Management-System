using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using StoreManagementSystem.Core.Models.ViewModels.User;
using StoreManagementSystem.Core.Services.Interfaces;
using static StoreManagementSystem.Common.GeneralApplicationConstants;

namespace StoreManagementSystem.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController
    {
        private readonly IUserService userService;
        private readonly IMemoryCache memoryCache;

        public UserController(IUserService userService, IMemoryCache memoryCache)
        {
            this.userService = userService;
            this.memoryCache = memoryCache;
        }

        [Route("User/All")]
        public async Task<IActionResult> All()
        {
            IEnumerable<UserViewModel> viewModels = memoryCache.Get<IEnumerable<UserViewModel>>(UsersCacheKey);
            

            if (viewModels == null)
            {
                viewModels = await userService.AllAsync();

                MemoryCacheEntryOptions options = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(UsersCacheDuration));

                memoryCache.Set(UsersCacheKey, viewModels, options);
            }

            return View(viewModels);
        }
    }
}
