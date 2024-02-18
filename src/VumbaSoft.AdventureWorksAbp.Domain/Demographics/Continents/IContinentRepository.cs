using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Continents;

public interface IContinentRepository : IRepository<Continent, Guid>
{
    Task<Continent> FindByNameAsync(string name,
        bool includeDetails = true,
        CancellationToken cancellationToken = default);

    Task<List<Continent>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null,
        bool includeDetails = false,
        CancellationToken cancellationToken = default
    );
}
