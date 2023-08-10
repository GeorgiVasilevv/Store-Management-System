using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using StoreManagementSystem.Core.Models.Store;
using StoreManagementSystem.Core.Models.ViewModels.Products;
using StoreManagementSystem.Core.Models.ViewModels.Store;
using StoreManagementSystem.Core.Services;
using StoreManagementSystem.Core.Services.Interfaces;
using StoreManagementSystem.Extensions;
using static StoreManagementSystem.Common.ToastrNotificationConstants;

namespace StoreManagementSystem.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService productService;
        private readonly IStoreService storeService;

        public ProductController(IProductService productService, IStoreService storeService)
        {
            this.productService = productService;
            this.storeService = storeService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id, int storeId, string information)
        {
            bool productExists = await productService.ExistsByIdAsync(id);

            if (!productExists)
            {
                TempData[ErrorMessage] = "The Product with the provided id does not exist!";

                return RedirectToAction("Details", "Store" , new { id = storeId , information});
            }

            try
            {
                ProductDetailsViewModel productDetails = await productService.DetailsAsync(id);

                return View(productDetails);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }


        [HttpGet]
        public async Task<IActionResult> Add(int id)
        {
            bool storeExists = await storeService.ExistsByIdAsync(id);
            if (!storeExists)
            {
                TempData[ErrorMessage] = "The Store with the provided id does not exist!";

                return RedirectToAction("All", "Store");
            }

            string userId = User.GetId()!;
            bool isUserOwner = await storeService.IsUserOwnerOfStoreAsync(id, userId);

            if (!isUserOwner && !User.IsUserAdmin())
            {
                TempData[ErrorMessage] = "You must be the owner of the store to add items.";

                return RedirectToAction("Mine", "Store");
            }

            try
            {
                ProductAddFormModel productModel = new ProductAddFormModel()
                {
                    Categories = await productService.GetAllCategoriesAsync(),
                    Conditions = await productService.GetAllConditionsAsync(),
                };

                return View(productModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(int id, ProductAddFormModel productModel)
        {

            bool storeExists = await storeService.ExistsByIdAsync(id);
            if (!storeExists)
            {
                TempData[ErrorMessage] = "The Store with the provided id does not exist!";

                return RedirectToAction("All", "Store");
            }

            string userId = User.GetId()!;
            bool isUserOwner = await storeService.IsUserOwnerOfStoreAsync(id, userId);

            if (!isUserOwner && !User.IsUserAdmin())
            {
                TempData[ErrorMessage] = "You must be the owner of the store.";

                return RedirectToAction("Mine", "Store");
            }

            bool categoryExists = await productService.CategoryExistsByIdAsync(productModel.CategoryId);
            bool conditionExists = await productService.ConditionExistsByIdAsync(productModel.ConditionId);

            if (!categoryExists)
            {
                ModelState.AddModelError(nameof(productModel.CategoryId), "Selected category does not exist!");
            }
            if (!conditionExists)
            {
                ModelState.AddModelError(nameof(productModel.ConditionId), "Selected condition does not exist!");
            }

            if (!ModelState.IsValid)
            {
                productModel.Categories = await productService.GetAllCategoriesAsync();
                productModel.Conditions = await productService.GetAllConditionsAsync();

                return View(productModel);
            }

            try
            {
                int productId = await productService
                    .CreateAndReturnIdAsync(productModel, id);

                this.TempData[SuccessMessage] = "Product was added successfully!";

                return RedirectToAction("Details", "Product", new { id = productId });
            }
            catch (Exception)
            {

                this.ModelState.AddModelError(string.Empty, "An unexpected error occured while trying to add your new product! Please try again later or contact us!");

                productModel.Categories = await productService.GetAllCategoriesAsync();
                productModel.Conditions = await productService.GetAllConditionsAsync();

                return View(productModel);
            }

        }

        //[HttpGet]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    bool storeExists = await storeService.ExistsByIdAsync(id);
        //    if (!storeExists)
        //    {
        //        TempData[ErrorMessage] = "The Store with the provided id does not exist!";

        //        return RedirectToAction("All", "Store");
        //    }

        //    string userId = User.GetId()!;
        //    bool isUserOwner = await storeService.IsUserOwnerOfStoreAsync(id, userId);

        //    if (!isUserOwner && !User.IsUserAdmin())
        //    {
        //        TempData[ErrorMessage] = "You must be the owner of the store.";

        //        return RedirectToAction("Mine", "Store");
        //    }

        //    try
        //    {
        //        StoreAddFormModel formModel = await storeService.GetStoreForEditByIdAsync(id);
        //        formModel.Cities = await cityService.GetAllCitiesOrderedAsync();
        //        formModel.Provinces = await provinceService.GetAllProvincesOrderedAsync();

        //        return View(formModel);
        //    }
        //    catch (Exception)
        //    {
        //        return GeneralError();
        //    }

        //}

        private IActionResult GeneralError()
        {
            TempData[ErrorMessage] = "Unexpected error occured! Please try again later or contact us!";

            return RedirectToAction("Index", "Home");
        }
    }
}
