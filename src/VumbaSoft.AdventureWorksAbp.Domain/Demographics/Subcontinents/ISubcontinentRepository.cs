using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Volo.Abp.Domain.Repositories;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents;

public interface ISubcontinentRepository : IRepository<Subcontinent, Guid>
{
    Task<Subcontinent> FindByNameAsync(string name,
    bool includeDetails = false,
    CancellationToken cancellationToken = default);

    Task<List<Subcontinent>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null,
        bool includeDetails = false,
        CancellationToken cancellationToken = default
    );

    //Task<List<Subcontinent>> GetListAsync(
    //    int skipCount,
    //    int maxResultCount,
    //    string sorting = "Name",
    //    SubcontinentFilter? filter = null
    //);

    Task<int> GetTotalCountAsync(SubcontinentFilter filter);
}
