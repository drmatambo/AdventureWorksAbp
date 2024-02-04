using VumbaSoft.AdventureWorksAbp.Demographics.Continents;
using VumbaSoft.AdventureWorksAbp.Demographics.Continents.Dtos;
using VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents;
using VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents.Dtos;
using VumbaSoft.AdventureWorksAbp.Demographics.Countries;
using VumbaSoft.AdventureWorksAbp.Demographics.Countries.Dtos;
using VumbaSoft.AdventureWorksAbp.Demographics.Regions;
using VumbaSoft.AdventureWorksAbp.Demographics.Regions.Dtos;
using VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces;
using VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces.Dtos;
using VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities;
using VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities.Dtos;
using VumbaSoft.AdventureWorksAbp.Demographics.Localities;
using VumbaSoft.AdventureWorksAbp.Demographics.Localities.Dtos;
using AutoMapper;

namespace VumbaSoft.AdventureWorksAbp;

public class AdventureWorksAbpApplicationAutoMapperProfile : Profile
{
    public AdventureWorksAbpApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Continent, ContinentDto>();
        CreateMap<CreateContinentDto, Continent>(MemberList.Source);
        CreateMap<UpdateContinentDto, Continent>(MemberList.Source);
        CreateMap<Subcontinent, SubcontinentDto>();
        CreateMap<CreateSubcontinentDto, Subcontinent>(MemberList.Source);
        CreateMap<UpdateSubcontinentDto, Subcontinent>(MemberList.Source);
        CreateMap<Country, CountryDto>();
        CreateMap<CreateCountryDto, Country>(MemberList.Source);
        CreateMap<UpdateCountryDto, Country>(MemberList.Source);
        CreateMap<Region, RegionDto>();
        CreateMap<CreateRegionDto, Region>(MemberList.Source);
        CreateMap<UpdateRegionDto, Region>(MemberList.Source);
        CreateMap<StateProvince, StateProvinceDto>();
        CreateMap<CreateStateProvinceDto, StateProvince>(MemberList.Source);
        CreateMap<UpdateStateProvinceDto, StateProvince>(MemberList.Source);
        CreateMap<DistrictCity, DistrictCityDto>();
        CreateMap<CreateDistrictCityDto, DistrictCity>(MemberList.Source);
        CreateMap<UpdateDistrictCityDto, DistrictCity>(MemberList.Source);
        CreateMap<Locality, LocalityDto>();
        CreateMap<CreateLocalityDto, Locality>(MemberList.Source);
        CreateMap<UpdateLocalityDto, Locality>(MemberList.Source);
    }
}
