using System;
using System.Linq;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.Permissions;
using VumbaSoft.AdventureWorksAbp.Demographics.Localities.Dtos;
using Volo.Abp.Application.Services;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Localities;


public class LocalityAppService : CrudAppService<Locality, LocalityDto, Guid, LocalityGetListInput, CreateLocalityDto, UpdateLocalityDto>,
    ILocalityAppService
{
    protected override string GetPolicyName { get; set; } = AdventureWorksAbpPermissions.Locality.Default;
    protected override string GetListPolicyName { get; set; } = AdventureWorksAbpPermissions.Locality.Default;
    protected override string CreatePolicyName { get; set; } = AdventureWorksAbpPermissions.Locality.Create;
    protected override string UpdatePolicyName { get; set; } = AdventureWorksAbpPermissions.Locality.Update;
    protected override string DeletePolicyName { get; set; } = AdventureWorksAbpPermissions.Locality.Delete;

    private readonly ILocalityRepository _repository;

    public LocalityAppService(ILocalityRepository repository) : base(repository)
    {
        _repository = repository;
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
}
