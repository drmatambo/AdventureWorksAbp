using System;
using System.Linq;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Countries;

public class CountryRepository : EfCoreRepository<AdventureWorksAbpDbContext, Country, Guid>, ICountryRepository
{
    public CountryRepository(IDbContextProvider<AdventureWorksAbpDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public override async Task<IQueryable<Country>> WithDetailsAsync()
    {
        return (await GetQueryableAsync()).IncludeDetails();
    }
}