using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities;

public class DistrictCityAppServiceTests : AdventureWorksAbpApplicationTestBase
{
    private readonly IDistrictCityAppService _districtCityAppService;

    public DistrictCityAppServiceTests()
    {
        _districtCityAppService = GetRequiredService<IDistrictCityAppService>();
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

