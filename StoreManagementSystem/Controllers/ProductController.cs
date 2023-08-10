using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreManagementSystem.Core.Models.Store;
using StoreManagementSystem.Core.Services;

using static StoreManagementSystem.Common.ToastrNotificationConstants;

namespace StoreManagementSystem.Controllers
{
    public class ProductController : BaseController
    {
        [AllowAnonymous]
        public IActionResult Details()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        private IActionResult GeneralError()
        {
            TempData[ErrorMessage] = "Unexpected error occured! Please try again later or contact us!";

            return RedirectToAction("Index", "Home");
        }
    }
}
