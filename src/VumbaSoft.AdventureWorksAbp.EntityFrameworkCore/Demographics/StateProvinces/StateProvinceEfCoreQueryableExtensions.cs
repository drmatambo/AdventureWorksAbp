using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces;

public static class StateProvinceEfCoreQueryableExtensions
{
    public static IQueryable<StateProvince> IncludeDetails(this IQueryable<StateProvince> queryable, bool include = true)
    {
        if (!include)
        {
            return queryable;
        }

        return queryable
             //.Include(x => x.DistrictCities) // TODO: AbpHelper generated
            ;
    }
}
