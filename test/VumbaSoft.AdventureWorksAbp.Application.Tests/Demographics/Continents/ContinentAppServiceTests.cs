using Shouldly;
using System;
using System.Threading.Tasks;
using Xunit;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Continents;

public class ContinentAppServiceTests : AdventureWorksAbpApplicationTestBase
{
    private readonly IContinentAppService _continentAppService;

    public ContinentAppServiceTests()
    {
        _continentAppService = GetRequiredService<IContinentAppService>();
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

