using Xunit;

namespace VumbaSoft.AdventureWorksAbp.EntityFrameworkCore;

[CollectionDefinition(AdventureWorksAbpTestConsts.CollectionDefinitionName)]
public class AdventureWorksAbpEntityFrameworkCoreCollection : ICollectionFixture<AdventureWorksAbpEntityFrameworkCoreFixture>
{

}
