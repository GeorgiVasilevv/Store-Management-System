using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreManagementSystem.Core.Models.Store;

namespace StoreManagementSystem.Controllers
{
    public class StoreController : BaseController
    {
        [AllowAnonymous]
        public IActionResult All()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            StoreFormModel storeModel = new StoreFormModel();
            return View(storeModel);
        }
    }
}
