using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Volo.Abp.Domain.Repositories;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Localities;

public interface ILocalityRepository : IRepository<Locality, Guid>
{
    Task<Locality> FindByNameAsync(string name,
    bool includeDetails = true,
    CancellationToken cancellationToken = default);

    Task<List<Locality>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null,
        bool includeDetails = false,
        CancellationToken cancellationToken = default
    );

    Task<int> GetTotalCountAsync(LocalityFilter filter);
}
