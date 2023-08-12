using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using StoreManagementSystem.Core.Models.Store;
using StoreManagementSystem.Core.Models.ViewModels.Order;
using StoreManagementSystem.Core.Models.ViewModels.Products;
using StoreManagementSystem.Core.Models.ViewModels.Store;
using StoreManagementSystem.Core.Services;
using StoreManagementSystem.Core.Services.Interfaces;
using StoreManagementSystem.Extensions;
using System.Configuration;
using static StoreManagementSystem.Common.ToastrNotificationConstants;

namespace StoreManagementSystem.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService productService;
        private readonly IStoreService storeService;
        private readonly IUserService userService;

        public ProductController(IProductService productService, IStoreService storeService, IUserService userService)
        {
            this.productService = productService;
            this.storeService = storeService;
            this.userService = userService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Order(int id, int storeId)
        {
            bool productExists = await productService.ExistsByIdAsync(id);

            if (!productExists)
            {
                TempData[ErrorMessage] = "The Product with the provided id does not exist!";

                return RedirectToAction("All", "Store");
            }

            bool storeExists = await storeService.ExistsByIdAsync(storeId);

            if (!storeExists)
            {
                TempData[ErrorMessage] = "The Store with the provided id does not exist!";

                return RedirectToAction("All", "Store");
            }

            OrderFormModel model = new OrderFormModel();

            string? userId = User?.GetId();
            bool userExists = false;
            if (userId != null)
            {
                userExists = await userService.UserExists(userId);
            }

            if (userExists)
            {
                model = await productService.FillOrderFormModel(model, userId);
            }

            model.StoreId = storeId;

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Order(int id, int storeId, OrderFormModel model)
        {
            bool productExists = await productService.ExistsByIdAsync(id);

            if (!productExists)
            {
                TempData[ErrorMessage] = "The Product with the provided id does not exist!";

                return RedirectToAction("All", "Store");
            }

            bool storeExists = await storeService.ExistsByIdAsync(storeId);

            if (!storeExists)
            {
                TempData[ErrorMessage] = "The Store with the provided id does not exist!";

                return RedirectToAction("All", "Store");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }


            try
            {
                string? userId = User?.GetId();

                await productService
                    .OrderAsync(model,id,storeId,userId);
                this.TempData[SuccessMessage] = "Product was ordered successfully!";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                return GeneralError();
            }
            
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id, int storeId, string information)
        {
            bool productExists = await productService.ExistsByIdAsync(id);

            if (!productExists)
            {
                TempData[ErrorMessage] = "The Product with the provided id does not exist!";

                return RedirectToAction("Details", "Store", new { id = storeId, information });
            }

            bool storeExists = await storeService.ExistsByIdAsync(storeId);

            if (!storeExists)
            {
                TempData[ErrorMessage] = "The Store with the provided id does not exist!";

                return RedirectToAction("All", "Store");
            }

            try
            {
                ProductDetailsViewModel productDetails = await productService.DetailsAsync(id);

                productDetails.StoreId = storeId;
                productDetails.Information = information;

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


                return RedirectToAction("All", "Store");
            }
            catch (Exception)
            {

                this.ModelState.AddModelError(string.Empty, "An unexpected error occured while trying to add your new product! Please try again later or contact us!");

                productModel.Categories = await productService.GetAllCategoriesAsync();
                productModel.Conditions = await productService.GetAllConditionsAsync();

                return View(productModel);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id, int storeId, string information)
        {
            bool storeExists = await storeService.ExistsByIdAsync(storeId);
            if (!storeExists)
            {
                TempData[ErrorMessage] = "The Store with the provided id does not exist!";

                return RedirectToAction("All", "Store");
            }

            string userId = User.GetId()!;
            bool isUserOwner = await storeService.IsUserOwnerOfStoreAsync(storeId, userId);

            if (!isUserOwner && !User.IsUserAdmin())
            {
                TempData[ErrorMessage] = "You must be the owner of the store.";

                return RedirectToAction("Mine", "Store");
            }

            bool productExists = await productService.ExistsByIdAsync(id);

            if (!productExists)
            {
                TempData[ErrorMessage] = "The Product with the provided id does not exist!";

                return RedirectToAction("Details", "Store", new { id = storeId, information });
            }

            try
            {
                ProductAddFormModel formModel = await productService.GetProductForEditByIdAsync(id);

                formModel.Categories = await productService.GetAllCategoriesAsync();
                formModel.Conditions = await productService.GetAllConditionsAsync();

                return View(formModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, int storeId, string information, ProductAddFormModel formModel)
        {
            if (!ModelState.IsValid)
            {
                formModel.Categories = await productService.GetAllCategoriesAsync();
                formModel.Conditions = await productService.GetAllConditionsAsync();

                return View(formModel);
            }

            bool storeExists = await storeService.ExistsByIdAsync(storeId);
            if (!storeExists)
            {
                TempData[ErrorMessage] = "The Store with the provided id does not exist!";

                return RedirectToAction("All", "Store");
            }

            string userId = User.GetId()!;
            bool isUserOwner = await storeService.IsUserOwnerOfStoreAsync(storeId, userId);

            if (!isUserOwner && !User.IsUserAdmin())
            {
                TempData[ErrorMessage] = "You must be the owner of the store.";

                return RedirectToAction("Mine", "Store");
            }

            bool productExists = await productService.ExistsByIdAsync(id);

            if (!productExists)
            {
                TempData[ErrorMessage] = "The Product with the provided id does not exist!";

                return RedirectToAction("Details", "Store", new { id = storeId, information });
            }

            try
            {
                await productService.EditAsync(id, formModel);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "An unexpected error occured while trying to edit your product! Please try again later or contact us!");

                formModel.Categories = await productService.GetAllCategoriesAsync();
                formModel.Conditions = await productService.GetAllConditionsAsync();


                return View(formModel);
            }

            this.TempData[SuccessMessage] = "Product was edited successfully!";

            return RedirectToAction("Details", "Store", new { id = storeId, information });

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id, int storeId, string information)
        {
            bool storeExists = await storeService.ExistsByIdAsync(storeId);
            if (!storeExists)
            {
                TempData[ErrorMessage] = "The Store with the provided id does not exist!";

                return RedirectToAction("All", "Store");
            }

            string userId = User.GetId()!;
            bool isUserOwner = await storeService.IsUserOwnerOfStoreAsync(storeId, userId);

            if (!isUserOwner && !User.IsUserAdmin())
            {
                TempData[ErrorMessage] = "You must be the owner of the store.";

                return RedirectToAction("Mine", "Store");
            }

            bool productExists = await productService.ExistsByIdAsync(id);

            if (!productExists)
            {
                TempData[ErrorMessage] = "The Product with the provided id does not exist!";

                return RedirectToAction("Details", "Store", new { id = storeId, information });
            }

            try
            {
                ProductDeleteDetailsViewModel productModel =
                    await productService.GetProductForDeleteAsync(id);

                productModel.StoreId = storeId;

                return View(productModel);
            }
            catch (Exception)
            {
                return GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, int storeId, string information, ProductDeleteDetailsViewModel formModel)
        {


            bool storeExists = await storeService.ExistsByIdAsync(storeId);
            if (!storeExists)
            {
                TempData[ErrorMessage] = "The Store with the provided id does not exist!";

                return RedirectToAction("All", "Store");
            }

            string userId = User.GetId()!;
            bool isUserOwner = await storeService.IsUserOwnerOfStoreAsync(storeId, userId);

            if (!isUserOwner && !User.IsUserAdmin())
            {
                TempData[ErrorMessage] = "You must be the owner of the store.";

                return RedirectToAction("Mine", "Store");
            }

            bool productExists = await productService.ExistsByIdAsync(id);

            if (!productExists)
            {
                TempData[ErrorMessage] = "The Product with the provided id does not exist!";

                return RedirectToAction("Details", "Store", new { id = storeId, information });
            }

            try
            {
                await productService.DeleteAsync(id);

                this.TempData[SuccessMessage] = "The product was successfully deleted!";

                return RedirectToAction("Details", "Store", new { id = storeId, information });
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
