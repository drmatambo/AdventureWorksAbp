using VumbaSoft.AdventureWorksAbp.Samples;
using Xunit;

namespace VumbaSoft.AdventureWorksAbp.EntityFrameworkCore.Domains;

[Collection(AdventureWorksAbpTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AdventureWorksAbpEntityFrameworkCoreTestModule>
{

}
