using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreManagementSystem.Core.Interfaces;
using StoreManagementSystem.Core.Models.Home;
using StoreManagementSystem.Core.ViewModels.Home;
using System.Diagnostics;

namespace StoreManagementSystem.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            StoreCombinedModel model = new StoreCombinedModel
            {
                RecentStores = await homeService.GetNineMostRecentStores(),
                TopRatedStores = await homeService.GetThreeHighestRatingStores()
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [AllowAnonymous]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400 || statusCode == 404)
            {
                return View("Error404");
            }
            return View();
        }
    }


}
