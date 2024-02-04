using System;
using VumbaSoft.AdventureWorksAbp.Demographics.Continents.Dtos;
using Volo.Abp.Application.Services;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Continents;


public interface IContinentAppService :
    ICrudAppService< 
        ContinentDto, 
        Guid, 
        ContinentGetListInput,
        CreateContinentDto,
        UpdateContinentDto>
{

}