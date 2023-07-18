using System.ComponentModel.DataAnnotations;
using static StoreManagementSystem.Common.EntityModelValidationConstants.Store;

namespace StoreManagementSystem.Core.Models.Store
{
    public class StoreFormModel
    {
        public StoreFormModel()
        {
            Cities = new List<StoreSelectCityFormModel>();
            Provinces = new List<StoreSelectProvinceFormModel>();
        }

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        [Display(Name = "Name")]
        public string Title { get; set; } = null!;


        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(UrlMaxLength)]
        [Display(Name = "Image Link")]
        [RegularExpression("(http)?s?:?(\\/\\/[^\"']*\\.(?:png|jpg|jpeg|gif|png|svg))", ErrorMessage ="Not a valid link.")]
        public string ImageUrl { get; set; } = null!;

        [Display(Name = "City")]
        public int CityId { get; set; }
        public IEnumerable<StoreSelectCityFormModel> Cities { get; set; }

        [Display(Name = "Province")]
        public int ProvinceId { get; set; }
        public IEnumerable<StoreSelectProvinceFormModel> Provinces { get; set; }
    }
}
