using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Localities;

public static class LocalityEfCoreQueryableExtensions
{
    public static IQueryable<Locality> IncludeDetails(this IQueryable<Locality> queryable, bool include = true)
    {
        if (!include)
        {
            return queryable;
        }

        return queryable
            // .Include(x => x.xxx) // TODO: AbpHelper generated
            ;
    }
}
