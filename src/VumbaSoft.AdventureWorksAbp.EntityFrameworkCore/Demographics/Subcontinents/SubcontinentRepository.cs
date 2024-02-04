using System;
using System.Linq;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents;

public class SubcontinentRepository : EfCoreRepository<AdventureWorksAbpDbContext, Subcontinent, Guid>, ISubcontinentRepository
{
    public SubcontinentRepository(IDbContextProvider<AdventureWorksAbpDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Subcontinent>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}