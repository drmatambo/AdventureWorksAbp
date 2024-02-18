using System;
using VumbaSoft.AdventureWorksAbp.Demographics.Continents.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using System.Threading;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Continents;


public interface IContinentAppService :
    ICrudAppService< 
        ContinentDto, 
        Guid, 
        ContinentGetListInput,
        CreateContinentDto,
        UpdateContinentDto>
{
    Task<ContinentDto> GetAsync(Guid id);

    Task<PagedResultDto<ContinentDto>> GetListAsync(ContinentGetListInput input);

    Task<ContinentDto> CreateAsync(CreateContinentDto input);

    Task UpdateContinentAsync(Guid id, UpdateContinentDto input);

    Task DeleteAsync(Guid id);
}