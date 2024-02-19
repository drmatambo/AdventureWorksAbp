using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Volo.Abp.Domain.Repositories;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Countries;

public interface ICountryRepository : IRepository<Country, Guid>
{
    Task<Country> FindByNameAsync(string name,
        bool includeDetails = true,
        CancellationToken cancellationToken = default);

    Task<List<Country>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null,
        bool includeDetails = false,
        CancellationToken cancellationToken = default
    );

    Task<int> GetTotalCountAsync(CountryFilter filter);
}
