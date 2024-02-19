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

    public async Task<int> GetTotalCountAsync(CountryFilter filter)
    {
        var dbSet = await GetDbSetAsync();
        return (await dbSet
                .WhereIf(filter.ContinentId != null, x => x.ContinentId.ToString().Contains(filter.ContinentId.ToString()))
                .WhereIf(filter.SubcontinentId != null, x => x.SubcontinentId.ToString().Contains(filter.SubcontinentId.ToString()))
                .WhereIf(filter.Name != null, x => x.Name.Contains(filter.Name))
                .WhereIf(filter.FormalName != null, x => x.FormalName.Contains(filter.FormalName))
                .WhereIf(filter.NativeName != null, x => x.NativeName.Contains(filter.NativeName))
                .WhereIf(filter.IsoTreeCode != null, x => x.IsoTreeCode.Contains(filter.IsoTreeCode))
                .WhereIf(filter.IsoTwoCode != null, x => x.IsoTwoCode.Contains(filter.IsoTwoCode))
                .WhereIf(filter.CcnTreeCode != null, x => x.CcnTreeCode.Contains(filter.CcnTreeCode))
                .WhereIf(filter.PhoneCode != null, x => x.PhoneCode.Contains(filter.PhoneCode))
                .WhereIf(filter.Capital != null, x => x.Capital.Contains(filter.Capital))
                .WhereIf(filter.Currency != null, x => x.Currency.Contains(filter.Currency))
                .WhereIf(filter.Population != null, x => x.Population.ToString().Contains(filter.Population.ToString()))
                .WhereIf(filter.Emoji != null, x => x.Emoji.Contains(filter.Emoji))
                .WhereIf(filter.EmojiU != null, x => x.EmojiU.Contains(filter.EmojiU))
                .WhereIf(filter.Remarks != null, x => x.Remarks.Contains(filter.Remarks)).ToListAsync()
            ).Count;

        throw new NotImplementedException();
    }

    public override async Task<IQueryable<Country>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}