using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreManagementSystem.Core.Models.ViewModels.User;
using StoreManagementSystem.Data.Entities.Models;

namespace StoreManagementSystem.Controllers
{
    public class UserController : BaseController
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IUserStore<User> userStore;

        public UserController(
            SignInManager<User> signInManager, 
            UserManager<User> userManager
            )
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                return View(formModel);
            }

            User user = new User()
            {
                FirstName = formModel.FirstName,
                LastName = formModel.LastName
            };

            await userManager.SetEmailAsync(user, formModel.Email);
            await userManager.SetUserNameAsync(user, formModel.Email);

            IdentityResult result = await userManager.CreateAsync(user, formModel.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors) 
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(formModel);
            }

                await signInManager.SignInAsync(user, false);

                return RedirectToAction("Index", "Home");

        }
    }
}
