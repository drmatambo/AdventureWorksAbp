using Shouldly;
using System;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.Demographics.Continents;
using Xunit;

namespace VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities;

public class DistrictCityAppServiceTests : AdventureWorksAbpApplicationTestBase
{
    private readonly IDistrictCityAppService _districtCityAppService;

    public DistrictCityAppServiceTests()
    {
        _districtCityAppService = GetRequiredService<IDistrictCityAppService>();
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

