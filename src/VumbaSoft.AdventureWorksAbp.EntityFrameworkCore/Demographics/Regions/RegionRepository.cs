using System;
using System.Linq;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Threading;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;//OrderBy
using Microsoft.EntityFrameworkCore;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Regions;

public class RegionRepository : EfCoreRepository<AdventureWorksAbpDbContext, Region, Guid>, IRegionRepository
{
    public RegionRepository(IDbContextProvider<AdventureWorksAbpDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<Region> FindByNameAsync(
        string name, 
        bool includeDetails = true, 
        CancellationToken cancellationToken = default)
    {
        var dbSet = (await GetDbSetAsync()).IncludeDetails(includeDetails);
        return await dbSet.FirstOrDefaultAsync(region => region.Name == name, GetCancellationToken(cancellationToken));
    }

    public async Task<List<Region>> GetListAsync(
        int skipCount, 
        int maxResultCount, 
        string sorting, 
        string filter = null, 
        bool includeDetails = false, 
        CancellationToken cancellationToken = default)
    {
        var dbSet = (await GetDbSetAsync()).IncludeDetails(includeDetails);

        return await dbSet.WhereIf(!filter.IsNullOrWhiteSpace(), region => region.Name.Contains(filter))
            .OrderBy(sorting)
            .Skip(skipCount)
            .Take(maxResultCount)
            .ToListAsync(GetCancellationToken(cancellationToken));
    }

    public async Task<int> GetTotalCountAsync(RegionFilter filter)
    {
        var dbSet = await GetDbSetAsync();

        return (await dbSet
                    .WhereIf(filter.Name != null, x => x.Name.Contains(filter.Name))
                    .WhereIf(filter.Population != null, x => x.Population.ToString().Contains(filter.Population.ToString()))
                    .WhereIf(filter.CountryId != null, x => x.CountryId.ToString().Contains(filter.CountryId.ToString()))
                    .WhereIf(filter.CountryCode != null, x => x.CountryCode.Contains(filter.CountryCode))
                    .WhereIf(filter.RegionCode != null, x => x.RegionCode.Contains(filter.RegionCode))
                    .WhereIf(filter.Remarks != null, x => x.Remarks.Contains(filter.Remarks)).ToListAsync()
               ).Count;
        throw new NotImplementedException();
    }

    public override async Task<IQueryable<Region>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}