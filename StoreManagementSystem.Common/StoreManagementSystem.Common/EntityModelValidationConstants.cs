using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            public const int UrlMaxLength = 2048;
        }
        public static class Category
        {
            public const int TitleMinLength = 3;
            public const int TitleMaxLength = 30;

        }
        public static class Shoes
        {
            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 40;

            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 100;

            public const int UrlMaxLength = 2048;
        }
        public static class Clothing
        {
            public const int TitleMinLength = 5;
            public const int TitleMaxLength = 40;

            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 100;

            public const int UrlMaxLength = 2048;
        }

    }
}
