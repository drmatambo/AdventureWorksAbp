using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Threading;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents;

public class SubcontinentRepository : EfCoreRepository<AdventureWorksAbpDbContext, Subcontinent, Guid>, ISubcontinentRepository
{
    public SubcontinentRepository(IDbContextProvider<AdventureWorksAbpDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<Subcontinent> FindByNameAsync(string name, bool includeDetails = true, CancellationToken cancellationToken = default)
    {
        var dbSet = await GetDbSetAsync();

        return await dbSet.IncludeDetails(includeDetails)
            .OrderBy(x => x.Name)
            .FirstOrDefaultAsync(subContinent => subContinent.Name == name, GetCancellationToken(cancellationToken));
    }

    public async Task<List<Subcontinent>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null, bool includeDetails = false, CancellationToken cancellationToken = default)
    {
        var dbSet = await GetDbSetAsync();

        return await dbSet.IncludeDetails(includeDetails)
            .WhereIf(!filter.IsNullOrWhiteSpace(), subContinent => subContinent.Name.Contains(filter))
            .OrderBy(sorting)
            .Skip(skipCount)
            .Take(maxResultCount)
            .ToListAsync(GetCancellationToken(cancellationToken));
    }

    public override async Task<IQueryable<Subcontinent>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}