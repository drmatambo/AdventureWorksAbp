using System;
using VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents.Dtos;
using Volo.Abp.Application.Services;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents;


public interface ISubcontinentAppService :
    ICrudAppService< 
        SubcontinentDto, 
        Guid, 
        SubcontinentGetListInput,
        CreateSubcontinentDto,
        UpdateSubcontinentDto>
{

}