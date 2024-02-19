using System;
using System.Linq;
using System.Linq.Dynamic.Core;//OrderBy
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.Permissions;
using VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;
using VumbaSoft.AdventureWorksAbp.Demographics.Countries;
using VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces;
using Volo.Abp.Domain.Entities;
using System.Collections.Generic;

namespace VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities;


public class DistrictCityAppService : CrudAppService<DistrictCity, DistrictCityDto, Guid, DistrictCityGetListInput, CreateDistrictCityDto, UpdateDistrictCityDto>,
    IDistrictCityAppService
{
    protected override string GetPolicyName { get; set; } = AdventureWorksAbpPermissions.DistrictCity.Default;
    protected override string GetListPolicyName { get; set; } = AdventureWorksAbpPermissions.DistrictCity.Default;
    protected override string CreatePolicyName { get; set; } = AdventureWorksAbpPermissions.DistrictCity.Create;
    protected override string UpdatePolicyName { get; set; } = AdventureWorksAbpPermissions.DistrictCity.Update;
    protected override string DeletePolicyName { get; set; } = AdventureWorksAbpPermissions.DistrictCity.Delete;

    private readonly IDistrictCityRepository _districtCityRepository;
    private readonly IStateProvinceRepository _stateProvinceRepository;
    private readonly ICountryRepository _countryRepository;

    public DistrictCityAppService(
        IDistrictCityRepository districtCityRepository, 
        ICountryRepository countryRepository, 
        IStateProvinceRepository stateProvinceRepository) : base(districtCityRepository)
    {
        _districtCityRepository = districtCityRepository;
        _countryRepository = countryRepository;
        _stateProvinceRepository = stateProvinceRepository;
    }

    protected override async Task<IQueryable<DistrictCity>> CreateFilteredQueryAsync(DistrictCityGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(input.CountryId != null, x => x.CountryId == input.CountryId)
            .WhereIf(input.StateProvinceId != null, x => x.StateProvinceId == input.StateProvinceId)
            .WhereIf(input.Name != null, x => x.Name.Contains(input.Name))
            .WhereIf(input.Population != null, x => x.Population == input.Population)
            .WhereIf(input.StateProvinceCode != null, x => x.StateProvinceCode == input.StateProvinceCode)
            .WhereIf(input.CountryCode != null, x => x.CountryCode == input.CountryCode)
            .WhereIf(input.Latitude != null, x => x.Latitude == input.Latitude)
            .WhereIf(input.Longitude != null, x => x.Longitude == input.Longitude)
            .WhereIf(input.Remarks != null, x => x.Remarks == input.Remarks)
            ;
    }

    public override async Task<DistrictCityDto> GetAsync(Guid id)
    {
        //Get the IQueryable<Continent> from the base Continent repository
        var queryable = await Repository.GetQueryableAsync();

        //Prepare a query to join Subcontinents and Continents
        var query = from districtCity in queryable
                    join stateProvince in await _stateProvinceRepository.GetQueryableAsync() on districtCity.StateProvinceId equals stateProvince.Id
                    join country in await _countryRepository.GetQueryableAsync() on districtCity.CountryId equals country.Id
                    where districtCity.Id == id
                    select new { districtCity, stateProvince, country };

        //Execute the query and get the continents with subcontinents
        var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);

        if (queryResult == null)
        {
            throw new EntityNotFoundException(typeof(DistrictCity), id);
        }

        var districtCityDto = ObjectMapper.Map<DistrictCity, DistrictCityDto>(queryResult.districtCity);
        districtCityDto.StateProvinceName = queryResult.stateProvince.Name;
        districtCityDto.CountryName = queryResult.country.Name;

        return districtCityDto;
    }

    public override async Task<PagedResultDto<DistrictCityDto>> GetListAsync(DistrictCityGetListInput input)
    {
        //Get the IQueryable<Continent> from the base Continent repository
        var queryable = await Repository.GetQueryableAsync();

        var filter = ObjectMapper.Map<DistrictCityGetListInput, DistrictCityFilter>(input);

        //Prepare a query to join Subcontinents and Continents
        var query = from districtCity in queryable
                    join stateProvince in await _stateProvinceRepository.GetQueryableAsync() on districtCity.StateProvinceId equals stateProvince.Id
                    join country in await _countryRepository.GetQueryableAsync() on districtCity.CountryId equals country.Id
                    select new { districtCity, stateProvince, country };

        query = query
            .WhereIf(input.CountryId != null, x => x.districtCity.CountryId.ToString().Contains(input.CountryId.ToString()))
            .WhereIf(input.StateProvinceId != null, x => x.districtCity.StateProvinceId.ToString().Contains(input.StateProvinceId.ToString()))
            .WhereIf(input.Name != null, x => x.districtCity.Name.Contains(input.Name))
            .WhereIf(input.Population != null, x => x.districtCity.Population.ToString().Contains(input.Population.ToString()))
            .WhereIf(input.StateProvinceCode != null, x => x.districtCity.StateProvinceCode == input.StateProvinceCode)
            .WhereIf(input.CountryCode != null, x => x.districtCity.CountryCode.Contains(input.CountryCode))
            .WhereIf(input.Latitude != null, x => x.districtCity.Latitude.ToString().Contains(input.Latitude.ToString()))
            .WhereIf(input.Longitude != null, x => x.districtCity.Longitude.ToString().Contains(input.Longitude.ToString()))
            .WhereIf(input.Remarks != null, x => x.districtCity.Remarks.Contains(input.Remarks))
            .OrderBy(NormalizeSorting(input.Sorting))
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount);

        //Execute the query and get the continents with subcontinents
        var queryResult = await AsyncExecuter.ToListAsync(query);

        //var queryResult = await _districtCityRepository.GetTotalCountAsync(filter);

        var districtCityDtos = queryResult.Select(x =>
        {
            var districtCityDto = ObjectMapper.Map<DistrictCity, DistrictCityDto>(x.districtCity);
            districtCityDto.StateProvinceName = x.stateProvince.Name;
            districtCityDto.CountryName = x.country.Name;

            return districtCityDto;
        }).ToList();

        var totalCount = await _districtCityRepository.GetTotalCountAsync(filter);

        return new PagedResultDto<DistrictCityDto>(totalCount, districtCityDtos);
    }

    public async Task<ListResultDto<DistrictCityStateProvinceLookUpDto>> GetDistrictCityStateProvinceLookupAsync()
    {
        var stateProvinces = await _stateProvinceRepository.GetListAsync();
        return new ListResultDto<DistrictCityStateProvinceLookUpDto>(
            ObjectMapper.Map<List<StateProvince>, List<DistrictCityStateProvinceLookUpDto>>(stateProvinces));
    }

    public async Task<ListResultDto<DistrictCityCountryLookUpDto>> GetDistrictCityCountryLookupAsync()
    {
        var countries = await _countryRepository.GetListAsync();
        return new ListResultDto<DistrictCityCountryLookUpDto>(ObjectMapper.Map<List<Country>, List<DistrictCityCountryLookUpDto>>(countries));
    }

    private static string NormalizeSorting(string sorting)
    {
        if (sorting.IsNullOrEmpty())
        {
            return $"districtCity.{nameof(DistrictCity.Name)}";
        }

        if (sorting.Contains("countryName", StringComparison.OrdinalIgnoreCase))
        {
            return sorting.Replace(
                "countryName",
                "country.Name",
                StringComparison.OrdinalIgnoreCase
            );
        }

        if (sorting.Contains("stateProvinceName", StringComparison.OrdinalIgnoreCase))
        {
            return sorting.Replace(
                "stateProvinceName",
                "stateProvince.Name",
                StringComparison.OrdinalIgnoreCase
            );
        }

        return $"districtCity.{sorting}";
    }
}
