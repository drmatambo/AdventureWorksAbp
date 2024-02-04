using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VumbaSoft.AdventureWorksAbp.Data;
using Volo.Abp.DependencyInjection;

namespace VumbaSoft.AdventureWorksAbp.EntityFrameworkCore;

public class EntityFrameworkCoreAdventureWorksAbpDbSchemaMigrator
    : IAdventureWorksAbpDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreAdventureWorksAbpDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the AdventureWorksAbpDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AdventureWorksAbpDbContext>()
            .Database
            .MigrateAsync();
    }
}
