using System;
using System.Linq;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Threading;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;//*Link*
using System.Linq.Dynamic.Core;
using VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents;//* OrderBy*

namespace VumbaSoft.AdventureWorksAbp.Demographics.Continents;

public class ContinentRepository : EfCoreRepository<AdventureWorksAbpDbContext, Continent, Guid>, IContinentRepository
{
    public ContinentRepository(IDbContextProvider<AdventureWorksAbpDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<Continent> FindByNameAsync(string name, bool includeDetails = true, CancellationToken cancellationToken = default)
    {
        var dbSet = await GetDbSetAsync();

        return await dbSet.IncludeDetails(includeDetails)
            .OrderBy(x => x.Name)
            .FirstOrDefaultAsync(continent => continent.Name == name, GetCancellationToken(cancellationToken));
    }

    public async Task<List<Continent>> GetListAsync(
        int skipCount, 
        int maxResultCount, 
        string sorting, 
        string filter = null, 
        bool includeDetails = false, 
        CancellationToken cancellationToken = default)
    {
        var dbSet = await GetDbSetAsync();

        return await dbSet.IncludeDetails(includeDetails)
            .WhereIf(!filter.IsNullOrWhiteSpace(), continent => continent.Name.Contains(filter))
            .OrderBy(sorting)
            .Skip(skipCount)
            .Take(maxResultCount)
            .ToListAsync(GetCancellationToken(cancellationToken));
    }

    public override async Task<IQueryable<Continent>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }

    private async Task<IQueryable<ContinentWithDetails>> ApplyFilterAsync()
    {
        var dbContext = await GetDbContextAsync();
        var query = (await GetDbSetAsync()).Include(sc => dbContext.Set<Subcontinent>())
            .Join(dbContext.Set<Subcontinent>(), continent => continent.Id, subcontinent => subcontinent.ContinentId, 
            (continent, subcontinent) => new { continent, subcontinent })
            .Select(x => new ContinentWithDetails {
                //Id = .,
                Id = x.continent.Id,
                Name = x.continent.Name,
                Population = x.continent.Population,
                Remarks = x.continent.Remarks,
                //Subcontinents = GetListAsync(),
                //Subcontinents = dbContext.Set<Subcontinent>().Where(continent => continent.Id == x.continent.Id).ToList(),
                //Subcontinents = dbContext.Set<Subcontinent>().Where(subContinent => subContinent.Id == x.continent.Id).ToList(),



            });

        return query;

        //return (await GetDbSetAsync()).Include(x => x.Subcontinents)
        //    .Join(dbContext.Set<Continent>(), continent => continent.Id, subcontinent => subcontinent.)
    }

}