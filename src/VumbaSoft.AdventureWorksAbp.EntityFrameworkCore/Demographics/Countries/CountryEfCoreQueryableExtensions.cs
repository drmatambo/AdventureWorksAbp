using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Countries;

public static class CountryEfCoreQueryableExtensions
{
    public static IQueryable<Country> IncludeDetails(this IQueryable<Country> queryable, bool include = true)
    {
        if (!include)
        {
            return queryable;
        }

        return queryable
             //.Include(x => x.Regions) // TODO: AbpHelper generated
            ;
    }
}
