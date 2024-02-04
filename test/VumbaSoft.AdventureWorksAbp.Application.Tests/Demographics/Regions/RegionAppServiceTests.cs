using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Regions;

public class RegionAppServiceTests : AdventureWorksAbpApplicationTestBase
{
    private readonly IRegionAppService _regionAppService;

    public RegionAppServiceTests()
    {
        _regionAppService = GetRequiredService<IRegionAppService>();
    }

    /*
    [Fact]
    public async Task Test1()
    {
        // Arrange

        // Act

        // Assert
    }
    */
}

