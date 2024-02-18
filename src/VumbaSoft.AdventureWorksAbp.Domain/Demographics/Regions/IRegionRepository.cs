using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Volo.Abp.Domain.Repositories;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Regions;

public interface IRegionRepository : IRepository<Region, Guid>
{
    Task<Region> FindByNameAsync(string name,
    bool includeDetails = true,
    CancellationToken cancellationToken = default);

    Task<List<Region>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null,
        bool includeDetails = false,
        CancellationToken cancellationToken = default
    );
}
