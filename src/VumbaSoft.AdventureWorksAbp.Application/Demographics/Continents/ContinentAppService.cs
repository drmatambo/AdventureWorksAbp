using System;
using System.Linq;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.Permissions;
using VumbaSoft.AdventureWorksAbp.Demographics.Continents.Dtos;
using Volo.Abp.Application.Services;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Continents;


public class ContinentAppService : CrudAppService<Continent, ContinentDto, Guid, ContinentGetListInput, CreateContinentDto, UpdateContinentDto>,
    IContinentAppService
{
    protected override string GetPolicyName { get; set; } = AdventureWorksAbpPermissions.Continent.Default;
    protected override string GetListPolicyName { get; set; } = AdventureWorksAbpPermissions.Continent.Default;
    protected override string CreatePolicyName { get; set; } = AdventureWorksAbpPermissions.Continent.Create;
    protected override string UpdatePolicyName { get; set; } = AdventureWorksAbpPermissions.Continent.Update;
    protected override string DeletePolicyName { get; set; } = AdventureWorksAbpPermissions.Continent.Delete;

    private readonly IContinentRepository _repository;

    public ContinentAppService(IContinentRepository repository) : base(repository)
    {
        _repository = repository;
    }

    protected override async Task<IQueryable<Continent>> CreateFilteredQueryAsync(ContinentGetListInput input)
    {
        // TODO: AbpHelper generated
        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(input.Name != null, x => x.Name.Contains(input.Name))
            .WhereIf(input.Population != null, x => x.Population == input.Population)
            .WhereIf(input.Remarks != null, x => x.Remarks == input.Remarks)
            ;
    }
}
