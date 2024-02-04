using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces;

public class StateProvinceAppServiceTests : AdventureWorksAbpApplicationTestBase
{
    private readonly IStateProvinceAppService _stateProvinceAppService;

    public StateProvinceAppServiceTests()
    {
        _stateProvinceAppService = GetRequiredService<IStateProvinceAppService>();
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

