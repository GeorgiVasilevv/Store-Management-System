using Microsoft.AspNetCore.Mvc;

namespace StoreManagementSystem.Areas.Admin.Controllers
{
    public class HomeController : BaseAdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
