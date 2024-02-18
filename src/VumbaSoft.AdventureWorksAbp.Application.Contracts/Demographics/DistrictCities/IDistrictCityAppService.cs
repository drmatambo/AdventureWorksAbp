using System;
using VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities;


public interface IDistrictCityAppService :
    ICrudAppService< 
        DistrictCityDto, 
        Guid, 
        DistrictCityGetListInput,
        CreateDistrictCityDto,
        UpdateDistrictCityDto>
{
    Task<DistrictCityDto> GetAsync(Guid id);

    Task<PagedResultDto<DistrictCityDto>> GetListAsync(DistrictCityGetListInput input);

    Task<ListResultDto<DistrictCityStateProvinceLookUpDto>> GetDistrictCityStateProvinceLookupAsync();

    Task<ListResultDto<DistrictCityCountryLookUpDto>> GetDistrictCityCountryLookupAsync();
}