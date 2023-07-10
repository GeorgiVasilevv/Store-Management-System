using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StoreManagementSystem.Controllers
{
    public class StoreController : BaseController
    {
        [AllowAnonymous]
        public IActionResult All()
        {
            return View();
        }
    }
}
