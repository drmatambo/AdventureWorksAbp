using System;
using System.Linq;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.Permissions;
using VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents.Dtos;
using Volo.Abp.Application.Services;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents;


public class SubcontinentAppService : CrudAppService<Subcontinent, SubcontinentDto, Guid, SubcontinentGetListInput, CreateSubcontinentDto, UpdateSubcontinentDto>,
    ISubcontinentAppService
{
    protected override string GetPolicyName { get; set; } = AdventureWorksAbpPermissions.Subcontinent.Default;
    protected override string GetListPolicyName { get; set; } = AdventureWorksAbpPermissions.Subcontinent.Default;
    protected override string CreatePolicyName { get; set; } = AdventureWorksAbpPermissions.Subcontinent.Create;
    protected override string UpdatePolicyName { get; set; } = AdventureWorksAbpPermissions.Subcontinent.Update;
    protected override string DeletePolicyName { get; set; } = AdventureWorksAbpPermissions.Subcontinent.Delete;

    private readonly ISubcontinentRepository _repository;

    public SubcontinentAppService(ISubcontinentRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<IQueryable<Subcontinent>> CreateFilteredQueryAsync(SubcontinentGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(input.Name != null, x => x.Name.Contains(input.Name))
            .WhereIf(input.ContinentId != null, x => x.ContinentId == input.ContinentId)
            .WhereIf(input.Population != null, x => x.Population == input.Population)
            .WhereIf(input.Remarks != null, x => x.Remarks == input.Remarks)
            ;
    }
}
