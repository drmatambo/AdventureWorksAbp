using System;
using VumbaSoft.AdventureWorksAbp.Demographics.Localities.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Localities;


public interface ILocalityAppService :
    ICrudAppService< 
        LocalityDto, 
        Guid, 
        LocalityGetListInput,
        CreateLocalityDto,
        UpdateLocalityDto>
{
    Task<LocalityDto> GetAsync(Guid id);

    Task<PagedResultDto<LocalityDto>> GetListAsync(LocalityGetListInput input);

    Task<ListResultDto<LocalityContinentLookUpDto>> GetLocalityContinenteLookUpAsync();

    Task<ListResultDto<LocalitySubContinenteLookUpDto>> GetLocalitySubContinenteLookUpAsync();

    Task<ListResultDto<LocalityCountryLookUpDto>> GetLocalityCountryLookUpAsync();

    Task<ListResultDto<LocalityRegionLookUpDto>> GetLocalityRegionLookUpAsync();

    Task<ListResultDto<LocalityStateProvinceLookUpDto>> GetLocalityStateProvinceLookUpAsync();

    Task<ListResultDto<LocalityDistrictCityLookUpDto>> GetLocalityDistrictCityLookUpAsync();
}