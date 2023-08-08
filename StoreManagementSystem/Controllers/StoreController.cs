using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using StoreManagementSystem.Core.Interfaces;
using StoreManagementSystem.Core.Models.ServiceModels;
using StoreManagementSystem.Core.Models.Store;
using StoreManagementSystem.Core.Models.ViewModels.Store;
using StoreManagementSystem.Extensions;
using static StoreManagementSystem.Common.ToastrNotificationConstants;

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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllStoresQueryModel model)
        {

            AllStoresFilteredAndPagedServiceModel serviceModel = await storeService.AllAsync(model);

            model.Stores = serviceModel.Stores;
            model.TotalStores = serviceModel.TotalStoresCount;
            model.Provinces = await provinceService.AllProvincesNamesAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            try
            {
                StoreAddFormModel storeModel = new StoreAddFormModel()
                {
                    Cities = await cityService.GetAllCitiesOrderedAsync(),
                    Provinces = await provinceService.GetAllProvincesOrderedAsync(),
                };

                return View(storeModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(StoreAddFormModel storeModel)
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
                int storeId = await storeService
                    .CreateAndReturnIdAsync(storeModel, ownerId!);

                this.TempData[SuccessMessage] = "Store was added successfully!";

                return RedirectToAction("Details", "Store", new { id = storeId });
            }
            catch (Exception)
            {

                this.ModelState.AddModelError(string.Empty, "An unexpected error occured while trying to add your new store! Please try again later or contact us!");

                storeModel.Cities = await cityService.GetAllCitiesOrderedAsync();
                storeModel.Provinces = await provinceService.GetAllProvincesOrderedAsync();

                return View(storeModel);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {

            List<StoreAllViewModel> myStores = new List<StoreAllViewModel>();
            string userId = User.GetId()!;

            try
            {
                myStores.AddRange(await storeService.AllByUserIdAsync(userId));

                return View(myStores);

            }
            catch (Exception)
            {
                return GeneralError();
            }


        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id, string information)
        {
            bool storeExists = await storeService.ExistsByIdAsync(id);

            if (!storeExists)
            {
                TempData[ErrorMessage] = "The Store with the provided id does not exist!";

                return RedirectToAction("All", "Store");
            }

            try
            {
                StoreDetailsViewModel storeDetailsViewModel = await storeService.DetailsAsync(id);

                if (storeDetailsViewModel.GetUrlInformation() != information)
                {
                    TempData[ErrorMessage] = "This store doesnt exist!";

                    return RedirectToAction("All", "Store");
                }

                return View(storeDetailsViewModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, StoreAddFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                //Optionally we can add ModelError to visualize on the screen.

                formModel.Cities = await cityService.GetAllCitiesOrderedAsync();
                formModel.Provinces = await provinceService.GetAllProvincesOrderedAsync();

                return View(formModel);
            }

            bool storeExists = await storeService.ExistsByIdAsync(id);
            if (!storeExists)
            {
                TempData[ErrorMessage] = "The Store with the provided id does not exist!";

                return RedirectToAction("All", "Store");
            }

            string userId = User.GetId()!;
            bool isUserOwner = await storeService.IsUserOwnerOfStoreAsync(id, userId);

            if (!isUserOwner)
            {
                TempData[ErrorMessage] = "You must be the owner of the store.";

                return RedirectToAction("Mine", "Store");
            }

            try
            {
                await storeService.EditAsync(id, formModel);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "An unexpected error occured while trying to edit your store! Please try again later or contact us!");

                formModel.Cities = await cityService.GetAllCitiesOrderedAsync();
                formModel.Provinces = await provinceService.GetAllProvincesOrderedAsync();


                return View(formModel);
            }

            this.TempData[SuccessMessage] = "Store was edited successfully!";

            return RedirectToAction("Details", "Store", new { id, information = formModel.GetUrlInformation() });

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            bool storeExists = await storeService.ExistsByIdAsync(id);
            if (!storeExists)
            {
                TempData[ErrorMessage] = "The Store with the provided id does not exist!";

                return RedirectToAction("All", "Store");
            }

            string userId = User.GetId()!;
            bool isUserOwner = await storeService.IsUserOwnerOfStoreAsync(id, userId);

            if (!isUserOwner)
            {
                TempData[ErrorMessage] = "You must be the owner of the store.";

                return RedirectToAction("Mine", "Store");
            }

            try
            {
                StoreAddFormModel formModel = await storeService.GetStoreForEditByIdAsync(id);
                formModel.Cities = await cityService.GetAllCitiesOrderedAsync();
                formModel.Provinces = await provinceService.GetAllProvincesOrderedAsync();

                return View(formModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            bool storeExists = await storeService.ExistsByIdAsync(id);
            if (!storeExists)
            {
                TempData[ErrorMessage] = "The Store with the provided id does not exist!";

                return RedirectToAction("All", "Store");
            }

            string userId = User.GetId()!;
            bool isUserOwner = await storeService.IsUserOwnerOfStoreAsync(id, userId);

            if (!isUserOwner)
            {
                TempData[ErrorMessage] = "You must be the owner of the store.";

                return RedirectToAction("Mine", "Store");
            }

            try
            {
                StoreDeleteDetailsViewModel storeModel =
                    await storeService.GetStoreForDeleteAsync(id);

                return View(storeModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id, StoreDeleteDetailsViewModel formModel)
        {

            bool storeExists = await storeService.ExistsByIdAsync(id);
            if (!storeExists)
            {
                TempData[ErrorMessage] = "The Store with the provided id does not exist!";

                return RedirectToAction("All", "Store");
            }

            string userId = User.GetId()!;
            bool isUserOwner = await storeService.IsUserOwnerOfStoreAsync(id, userId);

            if (!isUserOwner)
            {
                TempData[ErrorMessage] = "You must be the owner of the store.";

                return RedirectToAction("Mine", "Store");
            }

            try
            {
                await storeService.DeleteAsync(id);

                this.TempData[SuccessMessage] = "The store was successfully deleted!";

                return RedirectToAction("Mine", "Store");
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        private IActionResult GeneralError()
        {
            TempData[ErrorMessage] = "Unexpected error occured! Please try again later or contact us!";

            return RedirectToAction("Index", "Home");
        }
    }
}
