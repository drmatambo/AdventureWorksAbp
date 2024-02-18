using System;
using System.Linq;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Threading;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore; /* OrderBy */

namespace VumbaSoft.AdventureWorksAbp.Demographics.Countries;

public class CountryRepository : EfCoreRepository<AdventureWorksAbpDbContext, Country, Guid>, ICountryRepository
{
    public CountryRepository(IDbContextProvider<AdventureWorksAbpDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<Country> FindByNameAsync(
        string name, 
        bool includeDetails = true, 
        CancellationToken cancellationToken = default)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet.FirstOrDefaultAsync(country => country.Name == name);
    }

    public async Task<List<Country>> GetListAsync(
        int skipCount, 
        int maxResultCount, 
        string sorting, 
        string filter = null, 
        bool includeDetails = false, 
        CancellationToken cancellationToken = default)
    {
        var dbSet = await GetDbSetAsync();

        return await dbSet.WhereIf(!filter.IsNullOrWhiteSpace(), country => country.Name.Contains(filter))
            .OrderBy(sorting)
            .Skip(skipCount)
            .Take(maxResultCount)
            .ToListAsync();
    }


    public override async Task<IQueryable<Country>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}