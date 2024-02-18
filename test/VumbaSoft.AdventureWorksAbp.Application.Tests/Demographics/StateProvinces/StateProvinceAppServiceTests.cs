using Shouldly;
using System;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.Demographics.Continents;
using Xunit;

namespace VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces;

public class StateProvinceAppServiceTests : AdventureWorksAbpApplicationTestBase
{
    private readonly IStateProvinceAppService _stateProvinceAppService;

    public StateProvinceAppServiceTests()
    {
        _stateProvinceAppService = GetRequiredService<IStateProvinceAppService>();
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

