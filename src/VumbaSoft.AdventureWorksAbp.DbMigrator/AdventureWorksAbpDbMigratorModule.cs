using VumbaSoft.AdventureWorksAbp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace VumbaSoft.AdventureWorksAbp.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AdventureWorksAbpEntityFrameworkCoreModule),
    typeof(AdventureWorksAbpApplicationContractsModule)
    )]
public class AdventureWorksAbpDbMigratorModule : AbpModule
{
}
