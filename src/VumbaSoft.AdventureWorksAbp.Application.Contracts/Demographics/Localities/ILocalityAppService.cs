using System;
using VumbaSoft.AdventureWorksAbp.Demographics.Localities.Dtos;
using Volo.Abp.Application.Services;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Localities;


public interface ILocalityAppService :
    ICrudAppService< 
        LocalityDto, 
        Guid, 
        LocalityGetListInput,
        CreateLocalityDto,
        UpdateLocalityDto>
{

}