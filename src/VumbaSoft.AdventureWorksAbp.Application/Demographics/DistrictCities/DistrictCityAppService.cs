using System;
using System.Linq;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.Permissions;
using VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities.Dtos;
using Volo.Abp.Application.Services;

namespace VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities;


public class DistrictCityAppService : CrudAppService<DistrictCity, DistrictCityDto, Guid, DistrictCityGetListInput, CreateDistrictCityDto, UpdateDistrictCityDto>,
    IDistrictCityAppService
{
    protected override string GetPolicyName { get; set; } = AdventureWorksAbpPermissions.DistrictCity.Default;
    protected override string GetListPolicyName { get; set; } = AdventureWorksAbpPermissions.DistrictCity.Default;
    protected override string CreatePolicyName { get; set; } = AdventureWorksAbpPermissions.DistrictCity.Create;
    protected override string UpdatePolicyName { get; set; } = AdventureWorksAbpPermissions.DistrictCity.Update;
    protected override string DeletePolicyName { get; set; } = AdventureWorksAbpPermissions.DistrictCity.Delete;

    private readonly IDistrictCityRepository _repository;

    public DistrictCityAppService(IDistrictCityRepository repository) : base(repository)
    {
        _repository = repository;
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
}
