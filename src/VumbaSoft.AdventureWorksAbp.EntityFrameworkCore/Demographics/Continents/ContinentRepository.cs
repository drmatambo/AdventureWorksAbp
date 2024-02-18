using System;
using System.Linq;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Threading;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;//*Link*
using System.Linq.Dynamic.Core;//* OrderBy*

namespace VumbaSoft.AdventureWorksAbp.Demographics.Continents;

public class ContinentRepository : EfCoreRepository<AdventureWorksAbpDbContext, Continent, Guid>, IContinentRepository
{
    public ContinentRepository(IDbContextProvider<AdventureWorksAbpDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<Continent> FindByNameAsync(string name, bool includeDetails = true, CancellationToken cancellationToken = default)
    {
        var dbSet = await GetDbSetAsync();
        //return await dbSet. IncludeDetails(includeDetails)
        //    .Where(continent => continent.Name == name)
        //    .OrderBy( x => x.Name)
        //    .FirstOrDefaultAsync(GetCancellationToken(cancellationToken));

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
            .OrderBy(sorting /*x => x.Name*/)
            .Skip(skipCount)
            .Take(maxResultCount)
            .ToListAsync(GetCancellationToken(cancellationToken));
    }

    public override async Task<IQueryable<Continent>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}