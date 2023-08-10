using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static StoreManagementSystem.Common.GeneralApplicationConstants;

namespace StoreManagementSystem.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = AdminRoleName)]
    public class BaseAdminController : Controller
    {
       
    }
}
