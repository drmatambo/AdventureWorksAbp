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
using Volo.Abp.Domain.Entities;
using VumbaSoft.AdventureWorksAbp.Demographics.Countries;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents;

public class SubcontinentRepository : EfCoreRepository<AdventureWorksAbpDbContext, Subcontinent, Guid>, ISubcontinentRepository
{
    public SubcontinentRepository(IDbContextProvider<AdventureWorksAbpDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<Subcontinent> FindByNameAsync(
        string name, 
        bool includeDetails = true, 
        CancellationToken cancellationToken = default)
    {
        var dbSet = await GetDbSetAsync();

        return await dbSet.IncludeDetails(includeDetails)
            .OrderBy(x => x.Name)
            .FirstOrDefaultAsync(subContinent => subContinent.Name == name, GetCancellationToken(cancellationToken));
    }

    /* AbpHelper generated cod
     */

    //public async Task<List<Subcontinent>> GetListAsync(
    //    int skipCount,
    //    int maxResultCount,
    //    string sorting,
    //    string filter = null,
    //    bool includeDetails = false,
    //    CancellationToken cancellationToken = default)
    //{
    //    var dbSet = await GetDbSetAsync();

    //    return await dbSet.IncludeDetails(includeDetails)
    //        .WhereIf(!filter.IsNullOrWhiteSpace(), subContinent => subContinent.Name.Contains(filter))
    //        .OrderBy(sorting)
    //        .Skip(skipCount)
    //        .Take(maxResultCount)
    //        .ToListAsync(GetCancellationToken(cancellationToken));
    //}

    public async Task<List<Subcontinent>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting = "Name",
        SubcontinentFilter filter = null,
        bool includeDetails = false,
        CancellationToken cancellationToken = default)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet.IncludeDetails(includeDetails)
            .WhereIf(!filter.Name.IsNullOrWhiteSpace(), subContinent => subContinent.Name.Contains(filter.Name))
            .WhereIf(!filter.ContinentId.ToString().IsNullOrWhiteSpace(), subContinent => subContinent.ContinentId.ToString().Contains(filter.ContinentId.ToString()))
            .WhereIf(!filter.Population.ToString().IsNullOrWhiteSpace(), subContinent => subContinent.Population.ToString().Contains(filter.Population.ToString()))
            .WhereIf(!filter.Remarks.IsNullOrWhiteSpace(), subContinent => subContinent.Remarks.Contains(filter.Remarks))
            .OrderBy(sorting)
            .Skip(skipCount)
            .Take(maxResultCount)
            .ToListAsync(GetCancellationToken(cancellationToken));
    }

    public async Task<Subcontinent> GetSubContinentUpdateAsync(
        Guid id, 
        bool includeDetails = false, 
        CancellationToken cancellationToken = default)
    {
        var dbSet = await GetDbSetAsync();

        return await dbSet.IncludeDetails(includeDetails)
            .OrderBy(x => x.Name)
            .FirstOrDefaultAsync(subContinente => subContinente.Id == id, GetCancellationToken(cancellationToken));
    }

    public async Task<int> GetTotalCountAsync(SubcontinentFilter filter)
    {
        var dbSet = await GetDbSetAsync();

        return (await dbSet
            .WhereIf(!filter.Name.IsNullOrWhiteSpace(), subContinent => subContinent.Name.Contains(filter.Name))
            .WhereIf(!filter.ContinentId.ToString().IsNullOrWhiteSpace(), subContinent => subContinent.ContinentId.ToString().Contains(filter.ContinentId.ToString()))
            .WhereIf(!filter.Population.ToString().IsNullOrWhiteSpace(), subContinent => subContinent.Population.ToString().Contains(filter.Population.ToString()))
            .WhereIf(!filter.Remarks.IsNullOrWhiteSpace(), subContinent => subContinent.Remarks.Contains(filter.Remarks))
            .ToListAsync()).Count;
    }

    public async Task<Subcontinent> GetWithDetailsAsync(
        Guid id,
        CancellationToken cancelationToken = default)
    {
        var query = await ApplayFilterAsync();

        var result = await query.FirstOrDefaultAsync(c => c.Id == id, GetCancellationToken(cancelationToken));
        if (result == null)
            throw new EntityNotFoundException(typeof(Subcontinent), id);

        return result;
    }


    protected virtual async Task<IQueryable<Subcontinent>> ApplayFilterAsync()
    {
        var dbContext = await GetDbContextAsync();
        var subContinentDbSet = await GetDbSetAsync();
        var countriesDbSet = dbContext.Set<Country>();

        return (IQueryable<Subcontinent>)(from subContinent in subContinentDbSet
                                          join countries in countriesDbSet on subContinent.Id equals countries.SubcontinentId
                                          select new
                                          {
                                              Id = subContinent.Id,
                                              Nane = subContinent.Name,
                                              ContinentId = subContinent.ContinentId,
                                              Population = subContinent.Population,
                                              Remarks = subContinent.Remarks,
                                              Countries = subContinent.Countries

                                          });
    }


    public override async Task<IQueryable<Subcontinent>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}