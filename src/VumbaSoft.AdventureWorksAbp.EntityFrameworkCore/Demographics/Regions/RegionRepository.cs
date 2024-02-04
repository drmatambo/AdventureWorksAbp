using System;
using System.Linq;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Regions;

public class RegionRepository : EfCoreRepository<AdventureWorksAbpDbContext, Region, Guid>, IRegionRepository
{
    public RegionRepository(IDbContextProvider<AdventureWorksAbpDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Region>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}