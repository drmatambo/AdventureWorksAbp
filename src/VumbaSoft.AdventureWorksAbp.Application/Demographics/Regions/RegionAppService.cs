using System;
using System.Linq;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.Permissions;
using VumbaSoft.AdventureWorksAbp.Demographics.Regions.Dtos;
using Volo.Abp.Application.Services;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Regions;


public class RegionAppService : CrudAppService<Region, RegionDto, Guid, RegionGetListInput, CreateRegionDto, UpdateRegionDto>,
    IRegionAppService
{
    protected override string GetPolicyName { get; set; } = AdventureWorksAbpPermissions.Region.Default;
    protected override string GetListPolicyName { get; set; } = AdventureWorksAbpPermissions.Region.Default;
    protected override string CreatePolicyName { get; set; } = AdventureWorksAbpPermissions.Region.Create;
    protected override string UpdatePolicyName { get; set; } = AdventureWorksAbpPermissions.Region.Update;
    protected override string DeletePolicyName { get; set; } = AdventureWorksAbpPermissions.Region.Delete;

    private readonly IRegionRepository _repository;

    public RegionAppService(IRegionRepository repository) : base(repository)
    {
        _repository = repository;
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
}
