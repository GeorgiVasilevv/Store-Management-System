using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreManagementSystem.Core.Interfaces;
using StoreManagementSystem.Core.Models.Store;
using StoreManagementSystem.Extensions;

namespace StoreManagementSystem.Controllers
{
    public class StoreController : BaseController
    {
        private readonly ICityService cityService;
        private readonly IProvinceService provinceService;
        private readonly IStoreService storeService;

        public StoreController(ICityService cityService, IProvinceService provinceService, IStoreService storeService)
        {
            this.cityService = cityService;
            this.provinceService = provinceService;
            this.storeService = storeService;
        }

        [AllowAnonymous]
        public IActionResult All()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            StoreFormModel storeModel = new StoreFormModel()
            {
                Cities = await cityService.GetAllCitiesOrderedAsync(),
                Provinces = await provinceService.GetAllProvincesOrderedAsync(),
            };

            return View(storeModel);

        }

        [HttpPost]
        public async Task<IActionResult> Add(StoreFormModel storeModel)
        {
            bool cityExists = await cityService.ExistsByIdAsync(storeModel.CityId);
            bool provinceExists = await provinceService.ExistsByIdAsync(storeModel.ProvinceId);
            if (!cityExists)
            {
                ModelState.AddModelError(nameof(storeModel.CityId), "Selected city does not exist!");
            }
            if (!provinceExists)
            {
                ModelState.AddModelError(nameof(storeModel.ProvinceId), "Selected province does not exist!");
            }

            if (!ModelState.IsValid)
            {
                storeModel.Cities = await cityService.GetAllCitiesOrderedAsync();
                storeModel.Provinces = await provinceService.GetAllProvincesOrderedAsync();

                return View(storeModel);
            }

            try
            {
                string ownerId = this.User.GetId()!;
                await storeService.CreateAsync(storeModel, ownerId!);
            }
            catch (Exception)
            {

                this.ModelState.AddModelError(string.Empty, "An unexpected error occured while trying to add your new store! Please try again later or contact us!");

                storeModel.Cities = await cityService.GetAllCitiesOrderedAsync();
                storeModel.Provinces = await provinceService.GetAllProvincesOrderedAsync();

                return View(storeModel);
            }

            return RedirectToAction("All", "Store");
        }
    }
}
