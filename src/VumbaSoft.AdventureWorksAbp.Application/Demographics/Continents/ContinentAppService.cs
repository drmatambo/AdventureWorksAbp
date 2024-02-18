using System;
using System.Linq;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.Permissions;
using VumbaSoft.AdventureWorksAbp.Demographics.Continents.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;
using System.Collections.Generic;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Microsoft.AspNetCore.Authorization;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Continents;


public class ContinentAppService : CrudAppService<Continent, ContinentDto, Guid, ContinentGetListInput, CreateContinentDto, UpdateContinentDto>,
    IContinentAppService
{
    protected override string GetPolicyName { get; set; } = AdventureWorksAbpPermissions.Continent.Default;
    protected override string GetListPolicyName { get; set; } = AdventureWorksAbpPermissions.Continent.Default;
    protected override string CreatePolicyName { get; set; } = AdventureWorksAbpPermissions.Continent.Create;
    protected override string UpdatePolicyName { get; set; } = AdventureWorksAbpPermissions.Continent.Update;
    protected override string DeletePolicyName { get; set; } = AdventureWorksAbpPermissions.Continent.Delete;

    //private readonly IContinentRepository _repository;
    private readonly IContinentRepository _continentRepository;
    private readonly ContinentManager _continentManager;

    public ContinentAppService(IContinentRepository continentRepository, ContinentManager continentManager) : base(continentRepository)
    {
        _continentManager = continentManager;
        _continentRepository = continentRepository;
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

    public override async Task<ContinentDto> GetAsync(Guid id)
    {
        var continent = await _continentRepository.GetAsync(id);
        return ObjectMapper.Map<Continent, ContinentDto>(continent);
    }

    public override async Task<PagedResultDto<ContinentDto>> GetListAsync(ContinentGetListInput input)
    {
        if (input.Sorting.IsNullOrWhiteSpace())
        {
            input.Sorting = nameof(Continent.Name);
        }

        var continents = await _continentRepository.GetListAsync(
            input.SkipCount,
            input.MaxResultCount,
            input.Sorting,
            input.Name
            );

        var totalCount = input.Name == null
            ? await _continentRepository.CountAsync()
            : await _continentRepository.CountAsync(
                author => author.Name.Contains(input.Name));

        return new PagedResultDto<ContinentDto>(
            totalCount,
            ObjectMapper.Map<List<Continent>, List<ContinentDto>>(continents)
        );
    }

    [Authorize(AdventureWorksAbpPermissions.Continent.Create)]
    public override async Task<ContinentDto> CreateAsync(CreateContinentDto input)
    {
        var continent = await _continentManager.CreateAsync(
             input.Name,
             input.Population,
             input.Remarks
         );

        await _continentRepository.InsertAsync(continent);

        return ObjectMapper.Map<Continent, ContinentDto>(continent);
    }
    
    [Authorize(AdventureWorksAbpPermissions.Continent.Update)]
    public async Task UpdateContinentAsync(Guid id, UpdateContinentDto input)
    {
        var continent = await _continentRepository.GetAsync(id);

        if (continent.Name != input.Name)
        {
            await _continentManager.ChangeNameAsync(continent, input.Name);
        }
        continent.Name = input.Name;
        //await _continentRepository.UpdateAsync(ObjectMapper.Map<ContinentDto, CreateUpdateContinentDto>(continent));
        await _continentRepository.UpdateAsync(continent);
    }

    [Authorize(AdventureWorksAbpPermissions.Continent.Delete)]
    public override async Task DeleteAsync(Guid id)
    {
        await _continentRepository.DeleteAsync(id);
    }
}
