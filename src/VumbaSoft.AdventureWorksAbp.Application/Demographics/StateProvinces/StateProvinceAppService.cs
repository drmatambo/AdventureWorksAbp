using System;
using System.Linq;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.Permissions;
using VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces.Dtos;
using Volo.Abp.Application.Services;

namespace VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces;


public class StateProvinceAppService : CrudAppService<StateProvince, StateProvinceDto, Guid, StateProvinceGetListInput, CreateStateProvinceDto, UpdateStateProvinceDto>,
    IStateProvinceAppService
{
    protected override string GetPolicyName { get; set; } = AdventureWorksAbpPermissions.StateProvince.Default;
    protected override string GetListPolicyName { get; set; } = AdventureWorksAbpPermissions.StateProvince.Default;
    protected override string CreatePolicyName { get; set; } = AdventureWorksAbpPermissions.StateProvince.Create;
    protected override string UpdatePolicyName { get; set; } = AdventureWorksAbpPermissions.StateProvince.Update;
    protected override string DeletePolicyName { get; set; } = AdventureWorksAbpPermissions.StateProvince.Delete;

    private readonly IStateProvinceRepository _repository;

    public StateProvinceAppService(IStateProvinceRepository repository) : base(repository)
    {
        _repository = repository;
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
}
