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

namespace VumbaSoft.AdventureWorksAbp.Demographics.Localities;

public class LocalityRepository : EfCoreRepository<AdventureWorksAbpDbContext, Locality, Guid>, ILocalityRepository
{
    public LocalityRepository(IDbContextProvider<AdventureWorksAbpDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<Locality> FindByNameAsync(
        string name, 
        bool includeDetails = false, 
        CancellationToken cancellationToken = default)
    {
        var dbSet = (await GetDbSetAsync()).IncludeDetails(includeDetails);
        return await dbSet.FirstOrDefaultAsync(locality => locality.Name == name, GetCancellationToken(cancellationToken));
    }

    public async Task<List<Locality>> GetListAsync(
        int skipCount, 
        int maxResultCount, 
        string sorting, 
        string filter = null, 
        bool includeDetails = false, 
        CancellationToken cancellationToken = default)
    {
        var dbSet = (await GetDbSetAsync()).IncludeDetails(includeDetails);

        return await dbSet.WhereIf(!filter.IsNullOrWhiteSpace(), locality => locality.Name.Contains(filter))
            .OrderBy(sorting)
            .Skip(skipCount)
            .Take(maxResultCount)
            .ToListAsync(GetCancellationToken(cancellationToken));
    }

    public async Task<int> GetTotalCountAsync(LocalityFilter filter)
    {
        var dbSet = await GetDbSetAsync();

        return (await dbSet
                    .WhereIf(filter.ContinentId != null, x => x.ContinentId.ToString().Contains(filter.ContinentId.ToString()))
                    .WhereIf(filter.SubcontinentId != null, x => x.SubcontinentId.ToString().Contains(filter.SubcontinentId.ToString()))
                    .WhereIf(filter.CountryId != null, x => x.CountryId.ToString().Contains(filter.CountryId.ToString()))
                    .WhereIf(filter.RegionId != null, x => x.RegionId.ToString().Contains(filter.RegionId.ToString()))
                    .WhereIf(filter.StateProvinceId != null, x => x.StateProvinceId.ToString().Contains(filter.StateProvinceId.ToString()))
                    .WhereIf(filter.DistrictCityId != null, x => x.DistrictCityId.ToString().Contains(filter.DistrictCityId.ToString()))
                    .WhereIf(filter.Name != null, x => x.Name.Contains(filter.Name))
                    .WhereIf(filter.Population != null, x => x.Population.ToString().Contains(filter.Population.ToString()))
                    .WhereIf(filter.DistrictCityCode != null, x => x.DistrictCityCode.Contains(filter.DistrictCityCode))
                    .WhereIf(filter.LocalityCode != null, x => x.LocalityCode == filter.LocalityCode)
                    .WhereIf(filter.Latitude != null, x => x.Latitude.ToString().Contains(filter.Latitude.ToString()))
                    .WhereIf(filter.Longitude != null, x => x.Longitude.ToString().Contains(filter.Longitude.ToString()))
                    .WhereIf(filter.Remarks != null, x => x.Remarks.Contains(filter.Remarks)).ToListAsync()
               ).Count;
    }

    public override async Task<IQueryable<Locality>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}