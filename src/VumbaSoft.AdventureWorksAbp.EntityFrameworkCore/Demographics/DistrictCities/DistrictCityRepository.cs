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

namespace VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities;

public class DistrictCityRepository : EfCoreRepository<AdventureWorksAbpDbContext, DistrictCity, Guid>, IDistrictCityRepository
{
    public DistrictCityRepository(IDbContextProvider<AdventureWorksAbpDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<DistrictCity> FindByNameAsync(
        string name, 
        bool includeDetails = true, 
        CancellationToken cancellationToken = default)
    {
        var dbSet = (await GetDbSetAsync()).IncludeDetails(includeDetails);
        return await dbSet.FirstOrDefaultAsync(districtCity => districtCity.Name == name, GetCancellationToken(cancellationToken));

    }

    public async Task<List<DistrictCity>> GetListAsync(
        int skipCount, 
        int maxResultCount, 
        string sorting, 
        string filter = null, 
        bool includeDetails = false, 
        CancellationToken cancellationToken = default)
    {
        var dbSet = (await GetDbSetAsync()).IncludeDetails(includeDetails);

        return await dbSet.WhereIf(!filter.IsNullOrWhiteSpace(), districtCity => districtCity.Name.Contains(filter))
            .OrderBy(sorting)
            .Skip(skipCount)
            .Take(maxResultCount)
            .ToListAsync(GetCancellationToken(cancellationToken));
    }

    public async Task<List<DistrictCity>> GetProvinceListByIdAsync(
        Guid stateProvinceId, 
        int skipCount, 
        int maxResultCount, 
        string sorting, 
        string filter = null, 
        bool includeDetails = false, 
        CancellationToken cancellationToken = default)
    {
        var dbSet = (await GetDbSetAsync()).IncludeDetails(includeDetails);

        return await dbSet.WhereIf(!filter.IsNullOrWhiteSpace(), districtCity => districtCity.StateProvinceId == stateProvinceId)
            .OrderBy(sorting)
            .Skip(skipCount)
            .Take(maxResultCount)
            .ToListAsync(GetCancellationToken(cancellationToken));
    }

    public async Task<int> GetTotalCountAsync(DistrictCityFilter filter)
    {
        var dbSet = await GetDbSetAsync();

        return (await dbSet
                    .WhereIf(filter.CountryId != null, x => x.CountryId.ToString().Contains(filter.CountryId.ToString()))
                    .WhereIf(filter.StateProvinceId != null, x => x.StateProvinceId.ToString().Contains(filter.StateProvinceId.ToString()))
                    .WhereIf(filter.Name != null, x => x.Name.Contains(filter.Name))
                    .WhereIf(filter.Population != null, x => x.Population.ToString().Contains(filter.Population.ToString()))
                    .WhereIf(filter.StateProvinceCode != null, x => x.StateProvinceCode == filter.StateProvinceCode)
                    .WhereIf(filter.CountryCode != null, x => x.CountryCode.Contains(filter.CountryCode))
                    .WhereIf(filter.Latitude != null, x => x.Latitude.ToString().Contains(filter.Latitude.ToString()))
                    .WhereIf(filter.Longitude != null, x => x.Longitude.ToString().Contains(filter.Longitude.ToString()))
                    .WhereIf(filter.Remarks != null, x => x.Remarks.Contains(filter.Remarks)).ToListAsync()
               ).Count;
    }

    public override async Task<IQueryable<DistrictCity>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}