using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents;

public static class SubcontinentEfCoreQueryableExtensions
{
    public static IQueryable<Subcontinent> IncludeDetails(this IQueryable<Subcontinent> queryable, bool include = true)
    {
        if (!include)
        {
            return queryable;
        }

        return queryable
             //.Include(x => x.Countries) // TODO: AbpHelper generated
            ;
    }
}
