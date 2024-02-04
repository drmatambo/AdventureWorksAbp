using VumbaSoft.AdventureWorksAbp.Samples;
using Xunit;

namespace VumbaSoft.AdventureWorksAbp.EntityFrameworkCore.Applications;

[Collection(AdventureWorksAbpTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<AdventureWorksAbpEntityFrameworkCoreTestModule>
{

}
