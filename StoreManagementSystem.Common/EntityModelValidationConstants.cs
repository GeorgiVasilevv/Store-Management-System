﻿
namespace StoreManagementSystem.Common
{
    public static class EntityModelValidationConstants
    {
        public static class Store
        {
            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 40;

            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 200;

            public const int AddressMinLength = 5;
            public const int AddressMaxLength = 100;

            public const int UrlMaxLength = 2048;
        }
        public static class Category
        {
            public const int TitleMinLength = 3;
            public const int TitleMaxLength = 30;

        }

        public static class Product
        {
            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 40;

            public const string PriceMinValue = "0";
            public const string PriceMaxValue = "5000";

            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 100;

            public const int UrlMaxLength = 2048;
        }

        public static class Condition
        {
            public const int TitleMinLength = 1;
            public const int TitleMaxLength = 35;
        }

        public static class User
        {
            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 100;

            public const int FirstNameMinLength = 1;
            public const int FirstNameMaxLength = 15;

            public const int LastNameMinLength = 1;
            public const int LastNameMaxLength = 15;

            public const int AddressMinLength = 5;
            public const int AddressMaxLength = 100;

            public const int CityMinLength = 3;
            public const int CityMaxLength = 50;
        }

        public static class Order
        {
            public const int FirstNameMinLength = 1;
            public const int FirstNameMaxLength = 15;

            public const int LastNameMinLength = 1;
            public const int LastNameMaxLength = 15;

            public const int AddressMinLength = 5;
            public const int AddressMaxLength = 100;

            public const int CityMinLength = 3;
            public const int CityMaxLength = 50;

        }
    }
}
