using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents;

public class SubcontinentAppServiceTests : AdventureWorksAbpApplicationTestBase
{
    private readonly ISubcontinentAppService _subcontinentAppService;

    public SubcontinentAppServiceTests()
    {
        _subcontinentAppService = GetRequiredService<ISubcontinentAppService>();
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

