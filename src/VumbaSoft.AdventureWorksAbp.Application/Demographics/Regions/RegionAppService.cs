using System;
using System.Linq;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.Permissions;
using VumbaSoft.AdventureWorksAbp.Demographics.Regions.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;
using VumbaSoft.AdventureWorksAbp.Demographics.Continents;
using VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents;
using VumbaSoft.AdventureWorksAbp.Demographics.Countries;
using Volo.Abp.Domain.Entities;
using System.Collections.ObjectModel;
using System.Linq.Dynamic.Core;
using VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces;
using System.Collections.Generic;//OrderBy

namespace VumbaSoft.AdventureWorksAbp.Demographics.Regions;


public class RegionAppService : CrudAppService<Region, RegionDto, Guid, RegionGetListInput, CreateRegionDto, UpdateRegionDto>,
    IRegionAppService
{
    protected override string GetPolicyName { get; set; } = AdventureWorksAbpPermissions.Region.Default;
    protected override string GetListPolicyName { get; set; } = AdventureWorksAbpPermissions.Region.Default;
    protected override string CreatePolicyName { get; set; } = AdventureWorksAbpPermissions.Region.Create;
    protected override string UpdatePolicyName { get; set; } = AdventureWorksAbpPermissions.Region.Update;
    protected override string DeletePolicyName { get; set; } = AdventureWorksAbpPermissions.Region.Delete;

    private readonly IContinentRepository _continentRepository;
    private readonly ISubcontinentRepository _subContinentRepository;
    private readonly ICountryRepository _countryRepository;
    private readonly IRegionRepository _regionRepository;
    private readonly IStateProvinceRepository _stateProvinceRepository;

    public RegionAppService(
            IRegionRepository regionRepository,
            IContinentRepository continentRepository,
            ISubcontinentRepository subcontinentRepository,
            ICountryRepository countryRepository,
            IStateProvinceRepository stateProvinceRepository) : base(regionRepository)
    {
        _regionRepository = regionRepository;
        _continentRepository = continentRepository;
        _subContinentRepository = subcontinentRepository;
        _countryRepository = countryRepository;
        _stateProvinceRepository = stateProvinceRepository;
    }

    protected override async Task<IQueryable<Region>> CreateFilteredQueryAsync(RegionGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(input.Name != null, x => x.Name.Contains(input.Name))
            .WhereIf(input.Population != null, x => x.Population == input.Population)
            .WhereIf(input.CountryId != null, x => x.CountryId == input.CountryId)
            .WhereIf(input.CountryCode != null, x => x.CountryCode == input.CountryCode)
            .WhereIf(input.RegionCode != null, x => x.RegionCode == input.RegionCode)
            .WhereIf(input.Remarks != null, x => x.Remarks == input.Remarks)
            ;
    }

    public override async Task<RegionDto> GetAsync(Guid id)
    {
        //Get the IQueryable<Continent> from the base Continent repository
        var queryable = await Repository.GetQueryableAsync();

        //Prepare a query to join Subcontinents and Continents
        var query = from region in queryable
                    join country in await _countryRepository.GetQueryableAsync() on region.CountryId equals country.Id
                    //join stateProvince in await _stateProvinceRepository.GetQueryableAsync() on country.Id equals stateProvince.CountryId 
                    where region.Id == id
                    select new {region, country};

        //Execute the query and get the continents with subcontinents
        var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);

        if (queryResult == null) 
        {
            throw new EntityNotFoundException(typeof(Region), id);
        }

        var regionDto = ObjectMapper.Map<Region, RegionDto>(queryResult.region);
        regionDto.RegionCountryName = queryResult.country.Name;
        //regionDto.StateProvinces = [];
        //regionDto.StateProvinces = (Collection<StateProvinces.Dtos.CreateStateProvinceDto>)queryResult.region.StateProvinces;

        //TODO: Pending master detail implementacion
        //regionDto.StateProvinces = new Collection<StateProvinces.Dtos.CreateStateProvinceDto>();

        return regionDto;
    }

    public override async Task<PagedResultDto<RegionDto>> GetListAsync(RegionGetListInput input)
    {
        //Get the IQueryable<Continent> from the base Continent repository
        var queryable = await Repository.GetQueryableAsync();

        var filter = ObjectMapper.Map<RegionGetListInput, RegionFilter>(input);

        //Prepare a query to join Subcontinents and Continents
        var query = from region in queryable
                    join country in await _countryRepository.GetQueryableAsync() on region.CountryId equals country.Id
                    select new {region, country};

        query = query
            .WhereIf(input.Name != null, x => x.region.Name.Contains(input.Name))
            .WhereIf(input.Population != null, x => x.region.Population.ToString().Contains(input.Population.ToString()))
            .WhereIf(input.CountryId != null, x => x.region.CountryId.ToString().Contains(input.CountryId.ToString()))
            .WhereIf(input.CountryCode != null, x => x.region.CountryCode.Contains(input.CountryCode))
            .WhereIf(input.RegionCode != null, x => x.region.RegionCode.Contains(input.RegionCode))
            .WhereIf(input.Remarks != null, x => x.region.Remarks.Contains(input.Remarks))
            .OrderBy(NormalizeSorting(input.Sorting))
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount);

        //Execute the query and get the ountry with continents, subcontinents
        var queryResult = await AsyncExecuter.ToListAsync(query);

        //if (queryResult == null)
        //{
        //    throw new EntityNotFoundException(typeof(Region));
        //}

        //Convert the query result to a list of subcontinentDto objects
        var regionDtos = queryResult.Select(x =>
        {
            var regionDto = ObjectMapper.Map<Region, RegionDto>(x.region);
            regionDto.RegionCountryName = x.country.Name;
            //regionDto.StateProvinces = [];
            //regionDto.StateProvinces = (Collection<StateProvinces.Dtos.CreateStateProvinceDto>)queryResult.region.StateProvinces;
            return regionDto;
        }).ToList();


        //Get the total count with another query
        //var totalCount = await Repository.GetCountAsync();

        var totalCount = await _regionRepository.GetTotalCountAsync(filter);

        return new PagedResultDto<RegionDto>(totalCount, regionDtos);
    }

    public async Task<ListResultDto<RegionContinentLookUpDto>> GetRegionContinentLookupAsync()
    {
        var continents = await _continentRepository.GetListAsync();
        return new ListResultDto<RegionContinentLookUpDto>(ObjectMapper.Map<List<Continent>, List<RegionContinentLookUpDto>>(continents));
    }

    public async Task<ListResultDto<RegionSubcontinentLookUpDto>> GetRegionSubContinentLookupAsync()
    {
        var subContinents = await _subContinentRepository.GetListAsync();
        return new ListResultDto<RegionSubcontinentLookUpDto>(ObjectMapper.Map<List<Subcontinent>, List<RegionSubcontinentLookUpDto>>(subContinents));
    }

    public async Task<ListResultDto<RegionCountryLookUpDto>> GetRegionCountryLookupAsync()
    {
        var countries = await _countryRepository.GetListAsync();
        return new ListResultDto<RegionCountryLookUpDto>(ObjectMapper.Map<List<Country>, List<RegionCountryLookUpDto>>(countries));
    }

    private static string NormalizeSorting(string sorting)
    {
        if (sorting.IsNullOrEmpty())
        {
            return $"region.{nameof(Region.Name)}";
        }

        if (sorting.Contains("regionCountryName", StringComparison.OrdinalIgnoreCase))
        {
            return sorting.Replace(
                "regionCountryName",
                "country.Name",
                StringComparison.OrdinalIgnoreCase
            );
        }

        return $"region.{sorting}";
    }
}
