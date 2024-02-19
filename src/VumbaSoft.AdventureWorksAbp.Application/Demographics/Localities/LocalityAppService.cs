using System;
using System.Linq;
using System.Linq.Dynamic.Core;//OrderBy
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.Permissions;
using VumbaSoft.AdventureWorksAbp.Demographics.Localities.Dtos;
using Volo.Abp.Application.Services;
using VumbaSoft.AdventureWorksAbp.Demographics.Countries;
using VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities;
using VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces;
using VumbaSoft.AdventureWorksAbp.Demographics.Regions;
using System.Numerics;
using VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents;
using VumbaSoft.AdventureWorksAbp.Demographics.Continents;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;
using System.Collections.Generic;
using Volo.Abp.ObjectMapping;
using Volo.Abp.TextTemplating.VirtualFiles;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Localities;


public class LocalityAppService : CrudAppService<Locality, LocalityDto, Guid, LocalityGetListInput, CreateLocalityDto, UpdateLocalityDto>,
    ILocalityAppService
{
    protected override string GetPolicyName { get; set; } = AdventureWorksAbpPermissions.Locality.Default;
    protected override string GetListPolicyName { get; set; } = AdventureWorksAbpPermissions.Locality.Default;
    protected override string CreatePolicyName { get; set; } = AdventureWorksAbpPermissions.Locality.Create;
    protected override string UpdatePolicyName { get; set; } = AdventureWorksAbpPermissions.Locality.Update;
    protected override string DeletePolicyName { get; set; } = AdventureWorksAbpPermissions.Locality.Delete;

    private readonly ILocalityRepository _localityRepository;
    private readonly IDistrictCityRepository _districtCityRepository;
    private readonly IStateProvinceRepository _stateProvinceRepository;
    private readonly IRegionRepository _regionRepository;
    private readonly ICountryRepository _countryRepository;
    private readonly ISubcontinentRepository _subContinentRepository;
    private readonly IContinentRepository _continentRepository;

    public LocalityAppService(
        ILocalityRepository LocalityRepository, 
        IDistrictCityRepository districtCityRepository, 
        IStateProvinceRepository stateProvinceRepository, 
        IRegionRepository regionRepository, 
        ICountryRepository countryRepository, 
        ISubcontinentRepository subContinenteRepository, 
        IContinentRepository continentRepository) : base(LocalityRepository)
    {
        _localityRepository = LocalityRepository;
        _districtCityRepository = districtCityRepository;
        _stateProvinceRepository = stateProvinceRepository;
        _regionRepository = regionRepository;
        _countryRepository = countryRepository;
        _subContinentRepository = subContinenteRepository;
        _continentRepository = continentRepository;
    }

    protected override async Task<IQueryable<Locality>> CreateFilteredQueryAsync(LocalityGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(input.ContinentId != null, x => x.ContinentId == input.ContinentId)
            .WhereIf(input.SubcontinentId != null, x => x.SubcontinentId == input.SubcontinentId)
            .WhereIf(input.CountryId != null, x => x.CountryId == input.CountryId)
            .WhereIf(input.RegionId != null, x => x.RegionId == input.RegionId)
            .WhereIf(input.StateProvinceId != null, x => x.StateProvinceId == input.StateProvinceId)
            .WhereIf(input.DistrictCityId != null, x => x.DistrictCityId == input.DistrictCityId)
            .WhereIf(input.Name != null, x => x.Name.Contains(input.Name))
            .WhereIf(input.Population != null, x => x.Population == input.Population)
            .WhereIf(input.DistrictCityCode != null, x => x.DistrictCityCode == input.DistrictCityCode)
            .WhereIf(input.LocalityCode != null, x => x.LocalityCode == input.LocalityCode)
            .WhereIf(input.Latitude != null, x => x.Latitude == input.Latitude)
            .WhereIf(input.Longitude != null, x => x.Longitude == input.Longitude)
            .WhereIf(input.Remarks != null, x => x.Remarks == input.Remarks)
            ;
    }

    public override async Task<LocalityDto> GetAsync(Guid id)
    {
        //Get the IQueryable<Continent> from the base Continent repository
        var queryable = await Repository.GetQueryableAsync();

        //Prepare a query to join Subcontinents and Continents
        var query = from locality in queryable
                    join districtCity in await _districtCityRepository.GetQueryableAsync() on locality.DistrictCityId equals districtCity.Id
                    join stateProvince in await _stateProvinceRepository.GetQueryableAsync() on locality.StateProvinceId equals stateProvince.Id
                    join region in await _regionRepository.GetQueryableAsync() on locality.RegionId equals region.Id
                    join country in await _countryRepository.GetQueryableAsync() on locality.CountryId equals country.Id
                    join subContinent in await _subContinentRepository.GetQueryableAsync() on locality.SubcontinentId equals subContinent.Id
                    join continent in await _continentRepository.GetQueryableAsync() on locality.ContinentId equals continent.Id
                    where locality.Id == id
                    select new { locality, districtCity, stateProvince, region, country, subContinent, continent };

        //Execute the query and get the continents with subcontinents
        var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);

        if (queryResult == null)
        {
            throw new EntityNotFoundException(typeof(Locality), id);
        }

        var localityDto = ObjectMapper.Map<Locality, LocalityDto>(queryResult.locality);

        localityDto.ContinentName = queryResult.continent.Name;
        localityDto.SubcontinentName = queryResult.subContinent.Name;
        localityDto.CountryName = queryResult.country.Name;
        localityDto.RegionName = queryResult.region.Name;
        localityDto.StateProvinceName = queryResult.stateProvince.Name;
        localityDto.DistrictCityName = queryResult.districtCity.Name;

        return localityDto;
    }

    public override async Task<PagedResultDto<LocalityDto>> GetListAsync(LocalityGetListInput input)
    {
        //Get the IQueryable<Continent> from the base Continent repository
        var queryable = await Repository.GetQueryableAsync();

        //Map the filter Dtos
        var filter = ObjectMapper.Map<LocalityGetListInput, LocalityFilter>(input);

        //Prepare a query to join all table involved in locality table
        var query = from locality in queryable
                    join districtCity in await _districtCityRepository.GetQueryableAsync() on locality.DistrictCityId equals districtCity.Id
                    join stateProvince in await _stateProvinceRepository.GetQueryableAsync() on locality.StateProvinceId equals stateProvince.Id
                    join region in await _regionRepository.GetQueryableAsync() on locality.RegionId equals region.Id
                    join country in await _countryRepository.GetQueryableAsync() on locality.CountryId equals country.Id
                    join subContinent in await _subContinentRepository.GetQueryableAsync() on locality.SubcontinentId equals subContinent.Id
                    join continent in await _continentRepository.GetQueryableAsync() on locality.ContinentId equals continent.Id
                    select new { locality, districtCity, stateProvince, region, country, subContinent, continent };

        //Aplay filter and OrderBy new selected fields of joined tables 
        query = query
            .WhereIf(input.ContinentId != null, x => x.locality.ContinentId.ToString().Contains(input.ContinentId.ToString()))
            .WhereIf(input.SubcontinentId != null, x => x.locality.SubcontinentId.ToString().Contains(input.SubcontinentId.ToString()))
            .WhereIf(input.CountryId != null, x => x.locality.CountryId.ToString().Contains(input.CountryId.ToString()))
            .WhereIf(input.RegionId != null, x => x.locality.RegionId.ToString().Contains(input.RegionId.ToString()))
            .WhereIf(input.StateProvinceId != null, x => x.locality.StateProvinceId.ToString().Contains(input.StateProvinceId.ToString()))
            .WhereIf(input.DistrictCityId != null, x => x.locality.DistrictCityId.ToString().Contains(input.DistrictCityId.ToString()))
            .WhereIf(input.Name != null, x => x.locality.Name.Contains(input.Name))
            .WhereIf(input.Population != null, x => x.locality.Population.ToString().Contains(input.Population.ToString()))
            .WhereIf(input.DistrictCityCode != null, x => x.locality.DistrictCityCode.Contains(input.DistrictCityCode))
            .WhereIf(input.LocalityCode != null, x => x.locality.LocalityCode == input.LocalityCode)
            .WhereIf(input.Latitude != null, x => x.locality.Latitude.ToString().Contains(input.Latitude.ToString()))
            .WhereIf(input.Longitude != null, x => x.locality.Longitude.ToString().Contains(input.Longitude.ToString()))
            .WhereIf(input.Remarks != null, x => x.locality.Remarks.Contains(input.Remarks))
            .OrderBy(NormalizeSorting(input.Sorting))
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount);


        //Execute the query and get the continents with subcontinents
        var queryResult = await AsyncExecuter.ToListAsync(query);

        //Replace The Dto name with corresponding field names
        var localityDtos = queryResult.Select(x =>
        {
            var localityDto = ObjectMapper.Map<Locality, LocalityDto>(x.locality);

            localityDto.ContinentName = x.continent.Name;
            localityDto.SubcontinentName = x.subContinent.Name;
            localityDto.CountryName = x.country.Name;
            localityDto.RegionName = x.region.Name;
            localityDto.StateProvinceName = x.stateProvince.Name;
            localityDto.DistrictCityName = x.districtCity.Name;

            return localityDto;
        }).ToList();

        //Get the total count with another query from Repository
        var totalCount = await _localityRepository.GetTotalCountAsync(filter);

        return new PagedResultDto<LocalityDto>(totalCount, localityDtos);

    }

    public async Task<ListResultDto<LocalityContinentLookUpDto>> GetLocalityContinenteLookUpAsync()
    {
        var continents = await _continentRepository.GetListAsync();
        return new ListResultDto<LocalityContinentLookUpDto>(ObjectMapper.Map<List<Continent>, List<LocalityContinentLookUpDto>>(continents));

    }

    public async Task<ListResultDto<LocalitySubContinenteLookUpDto>> GetLocalitySubContinenteLookUpAsync()
    {
        var subContinents = await _subContinentRepository.GetListAsync();
        return new ListResultDto<LocalitySubContinenteLookUpDto>(ObjectMapper.Map<List<Subcontinent>, List<LocalitySubContinenteLookUpDto>>(subContinents));
    }

    public async Task<ListResultDto<LocalityCountryLookUpDto>> GetLocalityCountryLookUpAsync()
    {
        var countries = await _countryRepository.GetListAsync();
        return new ListResultDto<LocalityCountryLookUpDto>(ObjectMapper.Map<List<Country>, List<LocalityCountryLookUpDto>>(countries));
    }

    public async Task<ListResultDto<LocalityRegionLookUpDto>> GetLocalityRegionLookUpAsync()
    {
        var regions = await _regionRepository.GetListAsync();
        return new ListResultDto<LocalityRegionLookUpDto>(ObjectMapper.Map<List<Region>, List<LocalityRegionLookUpDto>>(regions));
    }

    public async Task<ListResultDto<LocalityStateProvinceLookUpDto>> GetLocalityStateProvinceLookUpAsync()
    {
        var stateProvinces = await _stateProvinceRepository.GetListAsync();
        return new ListResultDto<LocalityStateProvinceLookUpDto>(ObjectMapper.Map<List<StateProvince>, List<LocalityStateProvinceLookUpDto>>(stateProvinces));
    }

    public async Task<ListResultDto<LocalityDistrictCityLookUpDto>> GetLocalityDistrictCityLookUpAsync()
    {
        var districtCities = await _districtCityRepository.GetListAsync();
        return new ListResultDto<LocalityDistrictCityLookUpDto>(ObjectMapper.Map<List<DistrictCity>, List<LocalityDistrictCityLookUpDto>>(districtCities));
    }

    private static string NormalizeSorting(string sorting)
    {
        if (sorting.IsNullOrEmpty())
        {
            return $"locality.{nameof(Locality.Name)}";
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

        if (sorting.Contains("CountryName", StringComparison.OrdinalIgnoreCase))
        {
            return sorting.Replace(
                "CountryName",
                "Country.Name",
                StringComparison.OrdinalIgnoreCase
            );
        }

        if (sorting.Contains("RegionName", StringComparison.OrdinalIgnoreCase))
        {
            return sorting.Replace(
                "RegionName",
                "Region.Name",
                StringComparison.OrdinalIgnoreCase
            );
        }


        if (sorting.Contains("StateProvinceName", StringComparison.OrdinalIgnoreCase))
        {
            return sorting.Replace(
                "StateProvinceName",
                "StateProvince.Name",
                StringComparison.OrdinalIgnoreCase
            );
        }


        if (sorting.Contains("DistrictCityName", StringComparison.OrdinalIgnoreCase))
        {
            return sorting.Replace(
                "DistrictCityName",
                "DistrictCity.Name",
                StringComparison.OrdinalIgnoreCase
            );
        }

        return $"locality.{sorting}";
    }
}
