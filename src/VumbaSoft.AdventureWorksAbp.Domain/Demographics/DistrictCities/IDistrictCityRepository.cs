using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Volo.Abp.Domain.Repositories;

namespace VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities;

public interface IDistrictCityRepository : IRepository<DistrictCity, Guid>
{
    Task<DistrictCity> FindByNameAsync(string name,
        bool includeDetails = true,
        CancellationToken cancellationToken = default);

    Task<List<DistrictCity>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null,
        bool includeDetails = false,
        CancellationToken cancellationToken = default
    );

    Task<List<DistrictCity>> GetProvinceListByIdAsync(
        Guid stateProvinceId,
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null,
        bool includeDetails = false,
        CancellationToken cancellationToken = default
    );
}
