using System;
using System.Linq;
using System.Linq.Dynamic.Core;//OrderBy
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Threading;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces;

public class StateProvinceRepository : EfCoreRepository<AdventureWorksAbpDbContext, StateProvince, Guid>, IStateProvinceRepository
{
    public StateProvinceRepository(IDbContextProvider<AdventureWorksAbpDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<StateProvince> FindByNameAsync(
        string name, 
        bool includeDetails = true, 
        CancellationToken cancellationToken = default)
    {
        var dbSet = (await GetDbSetAsync()).IncludeDetails(includeDetails);
        return await dbSet.FirstOrDefaultAsync(stateProvince => stateProvince.Name == name, GetCancellationToken(cancellationToken));
    }

    public async Task<List<StateProvince>> GetListAsync(
        int skipCount, 
        int maxResultCount, 
        string sorting, 
        string filter = null, 
        bool includeDetails = false, 
        CancellationToken cancellationToken = default)
    {
        var dbSet = (await GetDbSetAsync()).IncludeDetails(includeDetails);

        return await dbSet.WhereIf(!filter.IsNullOrWhiteSpace(), stateProvince => stateProvince.Name.Contains(filter))
            .OrderBy(sorting)
            .Skip(skipCount)
            .Take(maxResultCount)
            .ToListAsync(GetCancellationToken(cancellationToken));
    }

    public async Task<List<StateProvince>> GetListByRegionIdAsync(
        Guid regioId, 
        int skipCount, 
        int maxResultCount, 
        string sorting, 
        string filter = null, 
        bool includeDetails = false, 
        CancellationToken cancellationToken = default)
    {
        var dbSet = (await GetDbSetAsync()).IncludeDetails(includeDetails);

        return await dbSet.WhereIf(!filter.IsNullOrWhiteSpace(), stateProvince => stateProvince.RegionId == regioId)
            .OrderBy(sorting)
            .Skip(skipCount)
            .Take(maxResultCount)
            .ToListAsync(GetCancellationToken(cancellationToken));
    }

    public async Task<int> GetTotalCountAsync(StateProvinceFilter filter)
    {
        var dbSet = await GetDbSetAsync();

        return (await dbSet
                    .WhereIf(filter.CountryId != null, x => x.CountryId.ToString().Contains(filter.CountryId.ToString()))
                    .WhereIf(filter.RegionId != null, x => x.RegionId.ToString().Contains(filter.RegionId.ToString()))
                    .WhereIf(filter.Name != null, x => x.Name.Contains(filter.Name))
                    .WhereIf(filter.Population != null, x => x.Population.ToString().Contains(filter.Population.ToString()))
                    .WhereIf(filter.RegionCode != null, x => x.RegionCode.Contains(filter.RegionCode))
                    .WhereIf(filter.StateProvinceCode != null, x => x.StateProvinceCode.Contains(filter.StateProvinceCode))
                    .WhereIf(filter.Remarks != null, x => x.Remarks.Contains(filter.Remarks)).ToListAsync()
                ).Count;
    }

    public override async Task<IQueryable<StateProvince>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}