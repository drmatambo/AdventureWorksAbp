using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities;

public static class DistrictCityEfCoreQueryableExtensions
{
    public static IQueryable<DistrictCity> IncludeDetails(this IQueryable<DistrictCity> queryable, bool include = true)
    {
        if (!include)
        {
            return queryable;
        }

        return queryable
             //.Include(x => x.Localities) // TODO: AbpHelper generated
            ;
    }
}
