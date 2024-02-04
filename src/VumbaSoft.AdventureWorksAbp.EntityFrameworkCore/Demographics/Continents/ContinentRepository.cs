using System;
using System.Linq;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Continents;

public class ContinentRepository : EfCoreRepository<AdventureWorksAbpDbContext, Continent, Guid>, IContinentRepository
{
    public ContinentRepository(IDbContextProvider<AdventureWorksAbpDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Continent>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}