using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Localities;

public class LocalityAppServiceTests : AdventureWorksAbpApplicationTestBase
{
    private readonly ILocalityAppService _localityAppService;

    public LocalityAppServiceTests()
    {
        _localityAppService = GetRequiredService<ILocalityAppService>();
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

