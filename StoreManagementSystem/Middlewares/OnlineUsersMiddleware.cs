using Microsoft.Extensions.Caching.Memory;
using StoreManagementSystem.Extensions;
using System.Collections.Concurrent;
using static StoreManagementSystem.Common.GeneralApplicationConstants;


namespace StoreManagementSystem.Middlewares
{
    public class OnlineUsersMiddleware
    {
        private readonly RequestDelegate next;
        private readonly string cookieName;
        private readonly int lastActivityMinutes;

        private static readonly ConcurrentDictionary<string, bool> AllKeys = new ConcurrentDictionary<string, bool>();

        public OnlineUsersMiddleware(RequestDelegate next,
            int lastActivityMinutes = LastActivityBeforeOfflineMinutes,
            string cookieName = DefaultOnlineUserCookieName)
        {
            this.next = next;
            this.cookieName = cookieName;
            this.lastActivityMinutes = lastActivityMinutes;
        }

        public Task InvokeAsync(HttpContext context, IMemoryCache cache)
        {
            if (context.User.Identity?.IsAuthenticated ?? false)
            {
                if (!context.Request.Cookies.TryGetValue(cookieName, out string userId))
                {
                    userId = context.User.GetId()!;

                    context.Response.Cookies.Append(cookieName, userId, new CookieOptions()
                    {
                        HttpOnly = true,
                        MaxAge = TimeSpan.FromDays(30)
                    });
                }

                cache.GetOrCreate(userId, cacheEntry =>
                {
                    if (!AllKeys.TryAdd(userId!, true))
                    {
                        cacheEntry.AbsoluteExpiration = DateTimeOffset.MinValue;
                    }
                    else
                    {
                        cacheEntry.SlidingExpiration = TimeSpan.FromMinutes(lastActivityMinutes);

                        cacheEntry.RegisterPostEvictionCallback(RemoveKeyWhenExpired);
                    }

                    return string.Empty;
                });
            }
            else
            {
                if (context.Request.Cookies.TryGetValue(cookieName, out string userId))
                {
                    if (!AllKeys.TryRemove(userId, out _))
                    {
                        AllKeys.TryUpdate(userId, false, true);
                    }

                    context.Response.Cookies.Delete(cookieName);
                }
            }

            return next(context);
        }

        public static bool CheckIfUserIsOnline(string userId)
        {
            bool valueTaken = AllKeys.TryGetValue(userId.ToLower(), out bool success);

            return success && valueTaken;
        }

        private void RemoveKeyWhenExpired(object key, object value, EvictionReason reason, object state)
        {
            string userIdString= (string)key;

            if (!AllKeys.TryRemove(userIdString, out _))
            {
                AllKeys.TryUpdate(userIdString, false, true);
            }
        }
    }
}
