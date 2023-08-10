﻿using Griesoft.AspNetCore.ReCaptcha;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using StoreManagementSystem.Core.Models.ViewModels.User;
using StoreManagementSystem.Data.Entities.Models;

using static StoreManagementSystem.Common.ToastrNotificationConstants;
using static StoreManagementSystem.Common.GeneralApplicationConstants;

namespace StoreManagementSystem.Controllers
{
    public class UserController : BaseController
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IMemoryCache memoryCache;

        public UserController(
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IMemoryCache memoryCache
            )
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.memoryCache = memoryCache;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateRecaptcha(Action = nameof(Register), ValidationFailedAction = ValidationFailedAction.ContinueRequest)]
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

            memoryCache.Remove(UsersCacheKey);

            return RedirectToAction("Index", "Home");

        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string? returnUrl = null)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            LoginFormModel model = new LoginFormModel()
            {
                ReturnUrl = returnUrl
            };

            return this.View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var result =
                await this.signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

            if (!result.Succeeded)
            {
                this.TempData[ErrorMessage] =
                    "There was an error while logging you in! Please try again later or contact an administrator.";

                return this.View(model);
            }

            return this.Redirect(model.ReturnUrl ?? "/Home/Index");
        }
    }
}