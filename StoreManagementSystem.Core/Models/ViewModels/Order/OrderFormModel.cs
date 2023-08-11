
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

using static StoreManagementSystem.Common.EntityModelValidationConstants.Order;

namespace StoreManagementSystem.Core.Models.ViewModels.Order
{
    public class OrderFormModel
    {
        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        [Display(Name = "First name")]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        [Display(Name = "Last name")]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        [Display(Name = "Address")]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(CityMaxLength, MinimumLength = CityMinLength)]
        [Display(Name = "City Name")]
        public string CityName { get; set; } = null!;
    }
}
