using System;
using System.Linq;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities;

public class DistrictCityRepository : EfCoreRepository<AdventureWorksAbpDbContext, DistrictCity, Guid>, IDistrictCityRepository
{
    public DistrictCityRepository(IDbContextProvider<AdventureWorksAbpDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<DistrictCity>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}