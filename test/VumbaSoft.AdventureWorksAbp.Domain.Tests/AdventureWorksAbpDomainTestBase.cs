using Volo.Abp.Modularity;

namespace VumbaSoft.AdventureWorksAbp;

/* Inherit from this class for your domain layer tests. */
public abstract class AdventureWorksAbpDomainTestBase<TStartupModule> : AdventureWorksAbpTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
