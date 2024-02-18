using Shouldly;
using System;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.Demographics.Continents;
using Xunit;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Localities;

public class LocalityAppServiceTests : AdventureWorksAbpApplicationTestBase
{
    private readonly ILocalityAppService _localityAppService;

    public LocalityAppServiceTests()
    {
        _localityAppService = GetRequiredService<ILocalityAppService>();
    }

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

