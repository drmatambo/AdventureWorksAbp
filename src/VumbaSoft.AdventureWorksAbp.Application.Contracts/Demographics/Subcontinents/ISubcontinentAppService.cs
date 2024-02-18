using System;
using VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents;


public interface ISubcontinentAppService :
    ICrudAppService< 
        SubcontinentDto, 
        Guid, 
        SubcontinentGetListInput,
        CreateSubcontinentDto,
        UpdateSubcontinentDto>
{
    Task<SubcontinentDto> GetAsync(Guid id);
    Task<PagedResultDto<SubcontinentDto>> GetListAsync(SubcontinentGetListInput input);

    Task<ListResultDto<ContinentLookUpDto>> GetContinentLookupAsync();
    Task<ListResultDto<SubcontinentLookUpDto>> GetSubContinentLookupAsync();

}