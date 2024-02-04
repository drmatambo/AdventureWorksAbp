using System;
using VumbaSoft.AdventureWorksAbp.Demographics.Countries.Dtos;
using Volo.Abp.Application.Services;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Countries;


public interface ICountryAppService :
    ICrudAppService< 
        CountryDto, 
        Guid, 
        CountryGetListInput,
        CreateCountryDto,
        UpdateCountryDto>
{

}