using System;
using VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using System.Collections;

namespace VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces;


public interface IStateProvinceAppService :
    ICrudAppService< 
        StateProvinceDto, 
        Guid, 
        StateProvinceGetListInput,
        CreateStateProvinceDto,
        UpdateStateProvinceDto>
{
    Task<StateProvinceDto> GetAsync(Guid id);

    Task<PagedResultDto<StateProvinceDto>> GetListAsync(StateProvinceGetListInput input);

    Task<ListResultDto<StateProvinceRegionLookUpDto>> GetStateProvinceRegionLookupAsync();

    Task<ListResultDto<StateProvinceCountryLookUpDto>> GetStateProvinceCountryLookupAsync();
}