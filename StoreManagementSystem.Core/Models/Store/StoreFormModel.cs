using System.ComponentModel.DataAnnotations;
using static StoreManagementSystem.Common.EntityModelValidationConstants.Store;

namespace StoreManagementSystem.Core.Models.Store
{
    public class StoreFormModel
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;


        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        [Required]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(UrlMaxLength)]
        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; } = null!;
    }
}
