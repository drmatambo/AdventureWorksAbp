using System;
using VumbaSoft.AdventureWorksAbp.Demographics.Regions.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Regions;


public interface IRegionAppService :
    ICrudAppService< 
        RegionDto, 
        Guid, 
        RegionGetListInput,
        CreateRegionDto,
        UpdateRegionDto>
{
    Task<RegionDto> GetAsync(Guid id);

    Task<PagedResultDto<RegionDto>> GetListAsync(RegionGetListInput input);

    Task<ListResultDto<RegionContinentLookUpDto>> GetRegionContinentLookupAsync();

    Task<ListResultDto<RegionSubcontinentLookUpDto>> GetRegionSubContinentLookupAsync();

    Task<ListResultDto<RegionCountryLookUpDto>> GetRegionCountryLookupAsync();
}