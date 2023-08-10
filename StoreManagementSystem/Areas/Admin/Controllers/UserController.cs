using Microsoft.AspNetCore.Mvc;
using StoreManagementSystem.Core.Interfaces;
using StoreManagementSystem.Core.Models.ViewModels.User;

namespace StoreManagementSystem.Areas.Admin.Controllers
{
    public class UserController : BaseAdminController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [Route("User/All")]
        public async  Task<IActionResult> All()
        {
            IEnumerable<UserViewModel> viewModels = await userService.AllAsync();

            return View(viewModels);
        }
    }
}
