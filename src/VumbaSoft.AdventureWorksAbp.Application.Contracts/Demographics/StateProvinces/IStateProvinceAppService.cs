using System;
using VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces.Dtos;
using Volo.Abp.Application.Services;

namespace VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces;


public interface IStateProvinceAppService :
    ICrudAppService< 
        StateProvinceDto, 
        Guid, 
        StateProvinceGetListInput,
        CreateStateProvinceDto,
        UpdateStateProvinceDto>
{

}