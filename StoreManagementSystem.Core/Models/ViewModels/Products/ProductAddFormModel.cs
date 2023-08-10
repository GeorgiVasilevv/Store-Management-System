using System.ComponentModel.DataAnnotations;
using static StoreManagementSystem.Common.EntityModelValidationConstants.Product;

namespace StoreManagementSystem.Core.Models.ViewModels.Products
{
    public class ProductAddFormModel
    {
        [Required]
        [StringLength(TitleMaxLength , MinimumLength = TitleMinLength)]
        [Display(Name = "Name")]
        public string Title { get; set; } = null!;

        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        [Required]
        public string Description { get; set; } = null!;

        [Range(typeof(decimal), PriceMinValue, PriceMaxValue)]
        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Condition { get; set; }

        [Required]
        [StringLength(UrlMaxLength)]
        [Display(Name = "Image Link")]
        [RegularExpression("(http)?s?:?(\\/\\/[^\"']*\\.(?:png|jpg|jpeg|gif|png|svg))", ErrorMessage = "Not a valid link.")]
        public string ImageUrl { get; set; } = null!;

        public int CategoryId { get; set; }
        public IEnumerable<ProductSelectCategoryFormModel> Categories { get; set; } = null!;
    }
}
