using System;
using VumbaSoft.AdventureWorksAbp.Demographics.Countries.Dtos;
using Volo.Abp.Application.Services;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents.Dtos;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Countries;


public interface ICountryAppService :
    ICrudAppService< 
        CountryDto, 
        Guid, 
        CountryGetListInput,
        CreateCountryDto,
        UpdateCountryDto>
{
    Task<ListResultDto<CountrySubcontinentLookUpDto>> GetSubContinentLookupAsync(CountryGetListInput input);
    Task<ListResultDto<CountrySubcontinentLookUpDto>> GetSubContinentLookupAsync();
    Task<ListResultDto<CountryContinentLookUpDto>> GetContinentLookupAsync();

    Task<CountryDto> GetAsync(Guid id);

    Task<PagedResultDto<CountryDto>> GetListAsync(CountryGetListInput input);
}