using System;
using System.Linq;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Localities;

public class LocalityRepository : EfCoreRepository<AdventureWorksAbpDbContext, Locality, Guid>, ILocalityRepository
{
    public LocalityRepository(IDbContextProvider<AdventureWorksAbpDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Locality>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}