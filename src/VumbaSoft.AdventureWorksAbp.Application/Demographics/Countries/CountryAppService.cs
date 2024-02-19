using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.Permissions;
using VumbaSoft.AdventureWorksAbp.Demographics.Countries.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;
using VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents.Dtos;
using VumbaSoft.AdventureWorksAbp.Demographics.Continents;
using VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents;
using System.Collections.Generic;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Countries;


public class CountryAppService : CrudAppService<Country, CountryDto, Guid, CountryGetListInput, CreateCountryDto, UpdateCountryDto>,
    ICountryAppService
{
    protected override string GetPolicyName { get; set; } = AdventureWorksAbpPermissions.Country.Default;
    protected override string GetListPolicyName { get; set; } = AdventureWorksAbpPermissions.Country.Default;
    protected override string CreatePolicyName { get; set; } = AdventureWorksAbpPermissions.Country.Create;
    protected override string UpdatePolicyName { get; set; } = AdventureWorksAbpPermissions.Country.Update;
    protected override string DeletePolicyName { get; set; } = AdventureWorksAbpPermissions.Country.Delete;

    private readonly ICountryRepository _countryRepository;
    private readonly ISubcontinentRepository _subContinentRepository;
    private readonly IContinentRepository _continentRepository;


    public CountryAppService(ICountryRepository countryRepository, ISubcontinentRepository subContinentRepository, IContinentRepository continentRepository) : base(countryRepository)
    {
        _countryRepository = countryRepository;
        _subContinentRepository = subContinentRepository;
        _continentRepository = continentRepository;
    }

    protected override async Task<IQueryable<Country>> CreateFilteredQueryAsync(CountryGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(input.ContinentId != null, x => x.ContinentId == input.ContinentId)
            .WhereIf(input.SubcontinentId != null, x => x.SubcontinentId == input.SubcontinentId)
            .WhereIf(input.Name != null, x => x.Name.Contains(input.Name))
            .WhereIf(input.FormalName != null, x => x.FormalName == input.FormalName)
            .WhereIf(input.NativeName != null, x => x.NativeName == input.NativeName)
            .WhereIf(input.IsoTreeCode != null, x => x.IsoTreeCode == input.IsoTreeCode)
            .WhereIf(input.IsoTwoCode != null, x => x.IsoTwoCode == input.IsoTwoCode)
            .WhereIf(input.CcnTreeCode != null, x => x.CcnTreeCode == input.CcnTreeCode)
            .WhereIf(input.PhoneCode != null, x => x.PhoneCode == input.PhoneCode)
            .WhereIf(input.Capital != null, x => x.Capital == input.Capital)
            .WhereIf(input.Currency != null, x => x.Currency == input.Currency)
            .WhereIf(input.Population != null, x => x.Population == input.Population)
            .WhereIf(input.Emoji != null, x => x.Emoji == input.Emoji)
            .WhereIf(input.EmojiU != null, x => x.EmojiU == input.EmojiU)
            .WhereIf(input.Remarks != null, x => x.Remarks == input.Remarks)
            ;
    }


    public override async Task<CountryDto> GetAsync(Guid id)
    {
        //Get the IQueryable<Continent> from the base Continent repository
        var queryable = await Repository.GetQueryableAsync();

        //Prepare a query to join Subcontinents and Continents
        var query = from country in queryable
                    join subcontinent in await _subContinentRepository.GetQueryableAsync() on country.SubcontinentId equals subcontinent.Id
                    join continent in await _continentRepository.GetQueryableAsync() on country.ContinentId equals continent.Id
                    where country.Id == id
                    select new { country, subcontinent, continent };

        //Execute the query and get the continents with subcontinents
        var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);

        if (queryResult == null)
        {
            throw new EntityNotFoundException(typeof(Country), id);
        }

        var countryDto = ObjectMapper.Map<Country, CountryDto>(queryResult.country);

        countryDto.ContinentName = queryResult.continent.Name;
        countryDto.SubcontinentName = queryResult.subcontinent.Name;
        //TODO: Pending implementacion of master details
        countryDto.Regions = new();

        return countryDto;
    }

    public override async Task<PagedResultDto<CountryDto>> GetListAsync(CountryGetListInput input)
    {


        //Get the IQueryable<Continent> from the base Continent repository
        var queryable = await Repository.GetQueryableAsync();

        //Create Mapping for Filter
        var filter = ObjectMapper.Map<CountryGetListInput, CountryFilter>(input);

        //Prepare a query to join Subcontinents and Continents
        var query = from country in queryable
                    join subcontinent in await _subContinentRepository.GetQueryableAsync() on country.SubcontinentId equals subcontinent.Id
                    join continent in await _continentRepository.GetQueryableAsync() on country.ContinentId equals continent.Id
                    select new { country, subcontinent, continent };

        //
        query = query
            .WhereIf(input.ContinentId != null, x => x.country.ContinentId.ToString().Contains(input.ContinentId.ToString()))
            .WhereIf(input.SubcontinentId != null, x => x.country.SubcontinentId.ToString().Contains(input.SubcontinentId.ToString()))
            .WhereIf(input.Name != null, x => x.country.Name.Contains(input.Name))
            .WhereIf(input.FormalName != null, x => x.country.FormalName.Contains(input.FormalName))
            .WhereIf(input.NativeName != null, x => x.country.NativeName.Contains(input.NativeName))
            .WhereIf(input.IsoTreeCode != null, x => x.country.IsoTreeCode.Contains(input.IsoTreeCode))
            .WhereIf(input.IsoTwoCode != null, x => x.country.IsoTwoCode.Contains(input.IsoTwoCode))
            .WhereIf(input.CcnTreeCode != null, x => x.country.CcnTreeCode.Contains(input.CcnTreeCode))
            .WhereIf(input.PhoneCode != null, x => x.country.PhoneCode.Contains(input.PhoneCode))
            .WhereIf(input.Capital != null, x => x.country.Capital.Contains(input.Capital))
            .WhereIf(input.Currency != null, x => x.country.Currency.Contains(input.Currency))
            .WhereIf(input.Population != null, x => x.country.Population.ToString().Contains(input.Population.ToString()))
            .WhereIf(input.Emoji != null, x => x.country.Emoji.Contains(input.Emoji))
            .WhereIf(input.EmojiU != null, x => x.country.EmojiU.Contains(input.EmojiU))
            .WhereIf(input.Remarks != null, x => x.country.Remarks.Contains(input.Remarks))
            .OrderBy(NormalizeSorting(input.Sorting))
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount);


        //Execute the query and get the ountry with continents, subcontinents
        var queryResult = await AsyncExecuter.ToListAsync(query);

        //Convert the query result to a list of subcontinentDto objects
        var countryDtos = queryResult.Select(x =>
        {
            var countryDto = ObjectMapper.Map<Country, CountryDto>(x.country);
            countryDto.ContinentName = x.continent.Name;
            countryDto.SubcontinentName = x.subcontinent.Name;
            return countryDto;
        }).ToList();


        //Get the total count with another query
        //var totalCount = await Repository.GetCountAsync();

        var totalCount = await _countryRepository.GetTotalCountAsync(filter);

        //var totalCount = await Repository.CountAsync(x => x.Name.Contains(input.Name));

        return new PagedResultDto<CountryDto>(totalCount, countryDtos);
    }

    public async Task<ListResultDto<CountrySubcontinentLookUpDto>> GetSubContinentLookupAsync()
    {
        var subContinents = await _subContinentRepository.GetListAsync();
        return new ListResultDto<CountrySubcontinentLookUpDto>(ObjectMapper.Map<List<Subcontinent>, List<CountrySubcontinentLookUpDto>>(subContinents));
    }

    public async Task<ListResultDto<CountryContinentLookUpDto>> GetContinentLookupAsync()
    {
        var continents = await _continentRepository.GetListAsync();
        return new ListResultDto<CountryContinentLookUpDto>(ObjectMapper.Map<List<Continent>, List<CountryContinentLookUpDto>>(continents));
    }

    private static string NormalizeSorting(string sorting)
    {
        if (sorting.IsNullOrEmpty())
        {
            return $"country.{nameof(Country.Name)}";
        }

        if (sorting.Contains("continentName", StringComparison.OrdinalIgnoreCase))
        {
            return sorting.Replace(
                "continentName",
                "continent.Name",
                StringComparison.OrdinalIgnoreCase
            );
        }

        if (sorting.Contains("subcontinentName", StringComparison.OrdinalIgnoreCase))
        {
            return sorting.Replace(
                "subcontinentName",
                "subcontinent.Name",
                StringComparison.OrdinalIgnoreCase
            );
        }

        return $"country.{sorting}";
    }
}
