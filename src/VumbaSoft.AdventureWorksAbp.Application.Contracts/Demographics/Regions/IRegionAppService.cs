using System;
using VumbaSoft.AdventureWorksAbp.Demographics.Regions.Dtos;
using Volo.Abp.Application.Services;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Regions;


public interface IRegionAppService :
    ICrudAppService< 
        RegionDto, 
        Guid, 
        RegionGetListInput,
        CreateRegionDto,
        UpdateRegionDto>
{

}