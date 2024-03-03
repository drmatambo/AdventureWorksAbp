using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Volo.Abp.Domain.Repositories;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents;

public interface ISubcontinentRepository : IRepository<Subcontinent, Guid>
{
    Task<Subcontinent> FindByNameAsync(string name,
    bool includeDetails = true,
    CancellationToken cancellationToken = default);

    Task<Subcontinent> GetSubContinentUpdateAsync(Guid id,
    bool includeDetails = true,
    CancellationToken cancellationToken = default);

    Task<Subcontinent> GetWithDetailsAsync(Guid id, CancellationToken cancelationToken = default);

    //Task<List<Subcontinent>> GetListAsync(
    //    int skipCount,
    //    int maxResultCount,
    //    string sorting,
    //    string filter = null,
    //    bool includeDetails = false,
    //    CancellationToken cancellationToken = default
    //);

    //GetListAsync With Filter
    Task<List<Subcontinent>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting = "Name",
        SubcontinentFilter? filter = null,
        bool includeDetails = false,
        CancellationToken cancellationToken = default
    );

    Task<int> GetTotalCountAsync(SubcontinentFilter filter);
}
