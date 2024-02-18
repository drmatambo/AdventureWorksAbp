using Shouldly;
using System;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.Demographics.Continents;
using Xunit;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents;

public class SubcontinentAppServiceTests : AdventureWorksAbpApplicationTestBase
{
    private readonly ISubcontinentAppService _subcontinentAppService;

    public SubcontinentAppServiceTests()
    {
        _subcontinentAppService = GetRequiredService<ISubcontinentAppService>();
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

