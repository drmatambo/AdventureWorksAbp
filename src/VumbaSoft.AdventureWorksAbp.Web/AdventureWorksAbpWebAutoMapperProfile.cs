using VumbaSoft.AdventureWorksAbp.Demographics.Continents.Dtos;
using VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Continents.Continent.ViewModels;
using VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents.Dtos;
using VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Subcontinents.Subcontinent.ViewModels;
using VumbaSoft.AdventureWorksAbp.Demographics.Countries.Dtos;
using VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Countries.Country.ViewModels;
using VumbaSoft.AdventureWorksAbp.Demographics.Regions.Dtos;
using VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Regions.Region.ViewModels;
using VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces.Dtos;
using VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.StateProvinces.StateProvince.ViewModels;
using VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities.Dtos;
using VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.DistrictCities.DistrictCity.ViewModels;
using VumbaSoft.AdventureWorksAbp.Demographics.Localities.Dtos;
using VumbaSoft.AdventureWorksAbp.Web.Pages.Demographics.Localities.Locality.ViewModels;
using AutoMapper;

namespace VumbaSoft.AdventureWorksAbp.Web;

public class AdventureWorksAbpWebAutoMapperProfile : Profile
{
    public AdventureWorksAbpWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<ContinentDto, EditContinentViewModel>();
        CreateMap<CreateContinentViewModel, CreateContinentDto>();
        CreateMap<EditContinentViewModel, UpdateContinentDto>();
        CreateMap<SubcontinentDto, EditSubcontinentViewModel>();
        CreateMap<CreateSubcontinentViewModel, CreateSubcontinentDto>();
        CreateMap<EditSubcontinentViewModel, UpdateSubcontinentDto>();
        CreateMap<CountryDto, EditCountryViewModel>();
        CreateMap<CreateCountryViewModel, CreateCountryDto>();
        CreateMap<EditCountryViewModel, UpdateCountryDto>();
        CreateMap<RegionDto, EditRegionViewModel>();
        CreateMap<CreateRegionViewModel, CreateRegionDto>();
        CreateMap<EditRegionViewModel, UpdateRegionDto>();
        CreateMap<StateProvinceDto, EditStateProvinceViewModel>();
        CreateMap<CreateStateProvinceViewModel, CreateStateProvinceDto>();
        CreateMap<EditStateProvinceViewModel, UpdateStateProvinceDto>();
        CreateMap<DistrictCityDto, EditDistrictCityViewModel>();
        CreateMap<CreateDistrictCityViewModel, CreateDistrictCityDto>();
        CreateMap<EditDistrictCityViewModel, UpdateDistrictCityDto>();
        CreateMap<LocalityDto, EditLocalityViewModel>();
        CreateMap<CreateLocalityViewModel, CreateLocalityDto>();
        CreateMap<EditLocalityViewModel, UpdateLocalityDto>();
    }
}
