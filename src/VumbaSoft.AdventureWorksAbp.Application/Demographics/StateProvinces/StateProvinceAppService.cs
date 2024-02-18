using System;
using System.Linq;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.Permissions;
using VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;
using VumbaSoft.AdventureWorksAbp.Demographics.Regions;
using VumbaSoft.AdventureWorksAbp.Demographics.Countries;
using System.Collections.Generic;//OrderBy
using System.Linq.Dynamic.Core;
using Volo.Abp.Domain.Entities;
using Volo.Abp.ObjectMapping;

namespace VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces;


public class StateProvinceAppService : CrudAppService<StateProvince, StateProvinceDto, Guid, StateProvinceGetListInput, CreateStateProvinceDto, UpdateStateProvinceDto>,
    IStateProvinceAppService
{
    protected override string GetPolicyName { get; set; } = AdventureWorksAbpPermissions.StateProvince.Default;
    protected override string GetListPolicyName { get; set; } = AdventureWorksAbpPermissions.StateProvince.Default;
    protected override string CreatePolicyName { get; set; } = AdventureWorksAbpPermissions.StateProvince.Create;
    protected override string UpdatePolicyName { get; set; } = AdventureWorksAbpPermissions.StateProvince.Update;
    protected override string DeletePolicyName { get; set; } = AdventureWorksAbpPermissions.StateProvince.Delete;

    private readonly IStateProvinceRepository _stateProvinceRepository;
    private readonly ICountryRepository _countryRepository;
    private readonly IRegionRepository _rerionRepository;

    public StateProvinceAppService(IStateProvinceRepository stateProvinceRepository, ICountryRepository countryRepository, IRegionRepository rerionRepository) : base(stateProvinceRepository)
    {
        _stateProvinceRepository = stateProvinceRepository;
        _countryRepository = countryRepository;
        _rerionRepository = rerionRepository;
    }

    protected override async Task<IQueryable<StateProvince>> CreateFilteredQueryAsync(StateProvinceGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(input.CountryId != null, x => x.CountryId == input.CountryId)
            .WhereIf(input.RegionId != null, x => x.RegionId == input.RegionId)
            .WhereIf(input.Name != null, x => x.Name.Contains(input.Name))
            .WhereIf(input.Population != null, x => x.Population == input.Population)
            .WhereIf(input.RegionCode != null, x => x.RegionCode == input.RegionCode)
            .WhereIf(input.StateProvinceCode != null, x => x.StateProvinceCode == input.StateProvinceCode)
            .WhereIf(input.Remarks != null, x => x.Remarks == input.Remarks)
            ;
    }

    public override async Task<StateProvinceDto> GetAsync(Guid id)
    {
        //Get the IQueryable<Continent> from the base Continent repository
        var queryable = await Repository.GetQueryableAsync();

        //Prepare a query to join Subcontinents and Continents
        var query = from stateProvince in queryable
                    join region in await _rerionRepository.GetQueryableAsync() on stateProvince.RegionId equals region.Id
                    join country in await _countryRepository.GetQueryableAsync() on stateProvince.CountryId equals country.Id
                    where stateProvince.Id == id
                    select new { stateProvince, region, country };
        
        //Execute the query and get the continents with subcontinents
        var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);

        if (queryResult == null)
        {
            throw new EntityNotFoundException(typeof(StateProvince), id);
        }

        var stateProvinceDto = ObjectMapper.Map<StateProvince, StateProvinceDto>(queryResult.stateProvince);
        stateProvinceDto.RegionName = queryResult.region.Name;
        stateProvinceDto.CountryName = queryResult.country.Name;

        return stateProvinceDto;
    }

    public override async Task<PagedResultDto<StateProvinceDto>> GetListAsync(StateProvinceGetListInput input)
    {
        //Get the IQueryable<Continent> from the base Continent repository
        var queryable = await Repository.GetQueryableAsync();

        //Prepare a query to join Subcontinents and Continents
        var query = from stateProvince in queryable
                    join region in await _rerionRepository.GetQueryableAsync() on stateProvince.RegionId equals region.Id
                    join country in await _countryRepository.GetQueryableAsync() on stateProvince.CountryId equals country.Id
                    //where stateProvince.Id == id
                    select new { stateProvince, region, country };

        query = query.OrderBy(NormalizeSorting(input.Sorting))
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount);

        //Execute the query and get the continents with subcontinents
        var queryResult = await AsyncExecuter.ToListAsync(query);

        var stateProvinceDtos = queryResult.Select(x =>
        {
            var stateProvinceDto = ObjectMapper.Map<StateProvince, StateProvinceDto>(x.stateProvince);
            stateProvinceDto.RegionName = x.region.Name;
            stateProvinceDto.CountryName = x.country.Name;

            return stateProvinceDto;
        }).ToList();

        var totalCount = await Repository.GetCountAsync();

        return new PagedResultDto<StateProvinceDto>(totalCount, stateProvinceDtos);
    }

    public async Task<ListResultDto<StateProvinceRegionLookUpDto>> GetStateProvinceRegionLookupAsync()
    {
        var regions = await _rerionRepository.GetListAsync();
        return new ListResultDto<StateProvinceRegionLookUpDto>(ObjectMapper.Map<List<Region>, List<StateProvinceRegionLookUpDto>>(regions));
    }

    public async Task<ListResultDto<StateProvinceCountryLookUpDto>> GetStateProvinceCountryLookupAsync()
    {
        var countries = await _countryRepository.GetListAsync();
        return new ListResultDto<StateProvinceCountryLookUpDto>(ObjectMapper.Map<List<Country>, List<StateProvinceCountryLookUpDto>>(countries));
    }

    private static string NormalizeSorting(string sorting)
    {
        if (sorting.IsNullOrEmpty())
        {
            return $"stateProvince.{nameof(StateProvince.Name)}";
        }

        if (sorting.Contains("countryName", StringComparison.OrdinalIgnoreCase))
        {
            return sorting.Replace(
                "countryName",
                "country.Name",
                StringComparison.OrdinalIgnoreCase
            );
        }

        if (sorting.Contains("regionName", StringComparison.OrdinalIgnoreCase))
        {
            return sorting.Replace(
                "regionName",
                "region.Name",
                StringComparison.OrdinalIgnoreCase
            );
        }

        return $"stateProvince.{sorting}";
    }
}
