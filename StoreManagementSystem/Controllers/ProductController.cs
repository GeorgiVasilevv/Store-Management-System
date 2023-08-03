using Microsoft.AspNetCore.Mvc;

namespace StoreManagementSystem.Controllers
{
    public class ProductController : BaseController
    {
        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}
