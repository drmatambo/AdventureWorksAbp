using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Regions;

public static class RegionEfCoreQueryableExtensions
{
    public static IQueryable<Region> IncludeDetails(this IQueryable<Region> queryable, bool include = true)
    {
        if (!include)
        {
            return queryable;
        }

        return queryable
             //.Include(x => x.StateProvinces) // TODO: AbpHelper generated
            ;
    }
}
