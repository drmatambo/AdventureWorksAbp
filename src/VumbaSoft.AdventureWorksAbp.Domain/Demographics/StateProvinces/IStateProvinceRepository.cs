using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Volo.Abp.Domain.Repositories;

namespace VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces;

public interface IStateProvinceRepository : IRepository<StateProvince, Guid>
{
    Task<StateProvince> FindByNameAsync(string name,
    bool includeDetails = true,
    CancellationToken cancellationToken = default);

    Task<List<StateProvince>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null,
        bool includeDetails = false,
        CancellationToken cancellationToken = default
    );

    Task<List<StateProvince>> GetListByRegionIdAsync(
        Guid regioId,
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null,
        bool includeDetails = false,
        CancellationToken cancellationToken = default
    );
}
