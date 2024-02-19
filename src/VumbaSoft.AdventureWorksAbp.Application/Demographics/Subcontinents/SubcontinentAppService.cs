using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.Permissions;
using VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;
using VumbaSoft.AdventureWorksAbp.Demographics.Continents;
using Volo.Abp.Domain.Entities;
using System.Collections.Generic;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;


namespace VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents;


public class SubcontinentAppService : CrudAppService<
        Subcontinent, 
        SubcontinentDto, 
        Guid, 
        SubcontinentGetListInput, 
        CreateSubcontinentDto, 
        UpdateSubcontinentDto>,
    ISubcontinentAppService
{
    protected override string GetPolicyName { get; set; } = AdventureWorksAbpPermissions.Subcontinent.Default;
    protected override string GetListPolicyName { get; set; } = AdventureWorksAbpPermissions.Subcontinent.Default;
    protected override string CreatePolicyName { get; set; } = AdventureWorksAbpPermissions.Subcontinent.Create;
    protected override string UpdatePolicyName { get; set; } = AdventureWorksAbpPermissions.Subcontinent.Update;
    protected override string DeletePolicyName { get; set; } = AdventureWorksAbpPermissions.Subcontinent.Delete;

    private readonly ISubcontinentRepository _subContinentRepository;
    //private readonly ISubcontinentRepository _subContinentRepository;
    private readonly IContinentRepository _continentRepository;

    public SubcontinentAppService(
        ISubcontinentRepository SubcontinentRepository, 
        IContinentRepository continentRepository) : base(SubcontinentRepository)
    {
        _subContinentRepository = SubcontinentRepository;
        _continentRepository = continentRepository;
    }

    protected override async Task<IQueryable<Subcontinent>> CreateFilteredQueryAsync(SubcontinentGetListInput input)
    {
        // TODO: AbpHelper generated
        //return (await base.CreateFilteredQueryAsync(input))
        //    .WhereIf(input.Name != null, x => x.Name.Contains(input.Name))
        //    .WhereIf(input.ContinentId != null, x => x.ContinentId = input.ContinentId)
        //    .WhereIf(input.Population != null, x => x.Population == input.Population)
        //    .WhereIf(input.Remarks != null, x => x.Remarks == input.Remarks)
            //;

        return (await base.CreateFilteredQueryAsync(input))
            .WhereIf(input.Name != null, x => x.Name.Contains(input.Name))
            .WhereIf(input.ContinentId != null, x => x.ContinentId.ToString().Contains(input.ContinentId.ToString()))
            .WhereIf(input.Population != null, x => x.Population.ToString().Contains(input.Population.ToString()))
            .WhereIf(input.Remarks != null, x => x.Remarks.Contains(input.Remarks))
            ;
    }

    public override async Task<SubcontinentDto> GetAsync(Guid id)
    {
        //Get the IQueryable<Subcontinent> from the repository
        var queryable = await Repository.GetQueryableAsync();

        //Get continent and the colection of subcontinents
        //var continentsAndSubcontinents = await _continentRepository.WithDetailsAsync(s => s.Subcontinents);

        //Prepare a query to join Subcontinents and Continents
        var query = from subcontinent in queryable
                    join continent in await _continentRepository.GetQueryableAsync() on subcontinent.ContinentId equals continent.Id
                    where subcontinent.Id == id
                    select new { subcontinent, continent };

        //Execute the query and get the continents with subcontinents
        var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);

        if (queryResult == null)
        {
            throw new EntityNotFoundException(typeof(Subcontinent), id);
        }

        var subcontinentDto = ObjectMapper.Map<Subcontinent, SubcontinentDto>(queryResult.subcontinent);

        subcontinentDto.ContinentName = queryResult.continent.Name;
        subcontinentDto.Countries = new();

        return subcontinentDto;
    }

    public override async Task<PagedResultDto<SubcontinentDto>> GetListAsync(SubcontinentGetListInput input)
    {
        //Get the IQueryable<Continent> from the base Continent repository
        var queryable = await Repository.GetQueryableAsync();

        //Create a filter for GetTotalCountAsync
        var filter = ObjectMapper.Map<SubcontinentGetListInput, SubcontinentFilter>(input);

        //Prepare a query to join Subcontinents and Continents
        var query = from Subcontinent in queryable
                    join Continent in await _continentRepository.GetQueryableAsync() on Subcontinent.ContinentId equals Continent.Id
                    select new { Subcontinent, Continent };

        //Paging
        query = query
            .WhereIf(input.Name != null, x => x.Subcontinent.Name.Contains(input.Name))
            .WhereIf(input.ContinentId != null, x => x.Subcontinent.ContinentId.ToString().Contains(input.ContinentId.ToString()))
            .WhereIf(input.Population != null, x => x.Subcontinent.Population.ToString().Contains(input.Population.ToString()))
            .WhereIf(input.Remarks != null, x => x.Subcontinent.Remarks.Contains(input.Remarks))
            .OrderBy(NormalizeSorting(input.Sorting))
            .Skip(input.SkipCount)
            .Take(input.MaxResultCount);

        //Execute the query and get a list
        var queryResult = await AsyncExecuter.ToListAsync(
            query);

        //var queryResult1 = await AsyncExecuter.ToListAsync(
        //    query);

        //Convert the query result to a list of subcontinentDto objects
        var subcontinentDtos = queryResult.Select(x =>
        {
            var subcontinentDto = ObjectMapper.Map<Subcontinent, SubcontinentDto>(x.Subcontinent);
            subcontinentDto.ContinentName = x.Continent.Name;
            //TODO: Pending masterdetail implementation
            subcontinentDto.Countries = new();
            return subcontinentDto;
        }).ToList();

        //Get the total count with another query
        //var totalCount = await Repository.GetCountAsync();

        var totalCount = await _subContinentRepository.GetTotalCountAsync(filter);

        //var totalCount = await _subContinentRepository.GetTotalCountAsync(query);

        //var totalCount = await _subContinentRepository.CountAsync(
        //    x => 
        //        x.Name.Contains(input.Name) || 
        //        x.ContinentId.ToString().Contains(input.ContinentId.ToString()) || 
        //        x.Population.ToString().Contains(input.Population.ToString()) || 
        //        x.Remarks.Contains(input.Remarks)
        //);


        return new PagedResultDto<SubcontinentDto>(totalCount, subcontinentDtos);
    }

    public async Task<ListResultDto<ContinentLookUpDto>> GetContinentLookupAsync()
    {
        var continents = await _continentRepository.GetListAsync();
        return new ListResultDto<ContinentLookUpDto>(ObjectMapper.Map<List<Continent>, List<ContinentLookUpDto>>(continents));
    }

    public async Task<ListResultDto<SubcontinentLookUpDto>> GetSubContinentLookupAsync()
    {
        var subContinents = await _subContinentRepository.GetListAsync();
        return new ListResultDto<SubcontinentLookUpDto>(ObjectMapper.Map<List<Subcontinent>, List<SubcontinentLookUpDto>>(subContinents));
    }

    private static string NormalizeSorting(string sorting)
    {
        if (sorting.IsNullOrEmpty())
        {
            return $"subcontinent.{nameof(Subcontinent.Name)}";
        }

        if (sorting.Contains("continentName", StringComparison.OrdinalIgnoreCase))
        {
            return sorting.Replace(
                "continentName",
                "continent.Name",
                StringComparison.OrdinalIgnoreCase
            );
        }

        return $"subcontinent.{sorting}";
    }
}
