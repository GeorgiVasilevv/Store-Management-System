namespace StoreManagementSystem.Common
{
    public static class GeneralApplicationConstants
    {
        public const int ReleaseYear = 2023;

        public const int DefaultPage = 1;
        public const int EntitiesPerPage = 3;

        public const string AdminRoleName = "Administrator";
        public const string AdminAreaName = "Admin";
        public const string AdminEmail = "admin@moderator.com";

        public const string DefaultOnlineUserCookieName = "IsOnline";
        public const int LastActivityBeforeOfflineMinutes = 10;

        public const string UsersCacheKey = "UsersCache";
        public const int UsersCacheDuration = 5;
    }
}