using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Continents;

public static class ContinentEfCoreQueryableExtensions
{
    public static IQueryable<Continent> IncludeDetails(this IQueryable<Continent> queryable, bool include = true)
    {
        if (!include)
        {
            return queryable;
        }

        return queryable
             //.Include(x => x.Subcontinents) // TODO: AbpHelper generated
            ;
    }
}
