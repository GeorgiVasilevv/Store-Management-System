using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StoreManagementSystem.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
    }
}
