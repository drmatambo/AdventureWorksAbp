using Shouldly;
using System;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.Demographics.Continents;
using Xunit;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Regions;

public class RegionAppServiceTests : AdventureWorksAbpApplicationTestBase
{
    private readonly IRegionAppService _regionAppService;

    public RegionAppServiceTests() => _regionAppService = GetRequiredService<IRegionAppService>();

    private T GetRequiredService<T>()
    {
        throw new NotImplementedException();
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

