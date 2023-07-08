using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreManagementSystem.Models;
using System.Diagnostics;

namespace StoreManagementSystem.Controllers
{
    public class HomeController : BaseController
    {

        public HomeController()
        {

        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [AllowAnonymous]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}