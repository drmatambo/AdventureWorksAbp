using System;
using System.Linq;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces;

public class StateProvinceRepository : EfCoreRepository<AdventureWorksAbpDbContext, StateProvince, Guid>, IStateProvinceRepository
{
    public StateProvinceRepository(IDbContextProvider<AdventureWorksAbpDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<StateProvince>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}