using System.Security.Claims;
using static StoreManagementSystem.Common.GeneralApplicationConstants;

namespace StoreManagementSystem.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string? GetId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        
        public static bool IsUserAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(AdminRoleName);
        }
    }
}
