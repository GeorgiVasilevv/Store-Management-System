using AutoMapper;
using StoreManagementSystem.Core.Mapping;
using StoreManagementSystem.Core.Models.ViewModels.Store.Interfaces;
using System.ComponentModel.DataAnnotations;
using static StoreManagementSystem.Common.EntityModelValidationConstants.Store;

namespace StoreManagementSystem.Core.Models.Store
{
    public class StoreAddFormModel: IStoreDetailsModel, IMapTo<Data.Entities.Models.Store>, IHaveCustomMappings
    {
        public StoreAddFormModel()
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
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
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

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<StoreAddFormModel, Data.Entities.Models.Store>()
                .ForMember(s => s.OwnerId, opt => opt.Ignore());
        }
    }
}
