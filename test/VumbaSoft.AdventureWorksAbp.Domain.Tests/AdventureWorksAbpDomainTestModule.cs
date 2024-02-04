using Volo.Abp.Modularity;

namespace VumbaSoft.AdventureWorksAbp;

[DependsOn(
    typeof(AdventureWorksAbpDomainModule),
    typeof(AdventureWorksAbpTestBaseModule)
)]
public class AdventureWorksAbpDomainTestModule : AbpModule
{

}
