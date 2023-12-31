﻿using System.ComponentModel.DataAnnotations;
using static StoreManagementSystem.Common.EntityModelValidationConstants.Category;

namespace StoreManagementSystem.Data.Entities.Models
{
    public class Category
    {
        //TODO Add Comments
        public Category()
        {
            Products = new List<Product>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        public ICollection<Product> Products { get; set; }
    }
}
