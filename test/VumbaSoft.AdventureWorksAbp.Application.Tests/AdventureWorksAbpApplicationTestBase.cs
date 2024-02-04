using Volo.Abp.Modularity;

namespace VumbaSoft.AdventureWorksAbp;

public abstract class AdventureWorksAbpApplicationTestBase<TStartupModule> : AdventureWorksAbpTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
