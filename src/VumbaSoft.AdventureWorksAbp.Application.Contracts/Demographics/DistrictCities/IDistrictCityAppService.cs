using System;
using VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities.Dtos;
using Volo.Abp.Application.Services;

namespace VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities;


public interface IDistrictCityAppService :
    ICrudAppService< 
        DistrictCityDto, 
        Guid, 
        DistrictCityGetListInput,
        CreateDistrictCityDto,
        UpdateDistrictCityDto>
{

}