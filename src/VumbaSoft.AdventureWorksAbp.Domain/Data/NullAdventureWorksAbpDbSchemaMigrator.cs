using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace VumbaSoft.AdventureWorksAbp.Data;

/* This is used if database provider does't define
 * IAdventureWorksAbpDbSchemaMigrator implementation.
 */
public class NullAdventureWorksAbpDbSchemaMigrator : IAdventureWorksAbpDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
