using Volo.Abp.Modularity;

namespace VumbaSoft.AdventureWorksAbp;

[DependsOn(
    typeof(AdventureWorksAbpApplicationModule),
    typeof(AdventureWorksAbpDomainTestModule)
)]
public class AdventureWorksAbpApplicationTestModule : AbpModule
{

}
