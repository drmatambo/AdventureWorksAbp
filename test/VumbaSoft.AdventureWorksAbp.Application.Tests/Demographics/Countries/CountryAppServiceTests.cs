using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Countries;

public class CountryAppServiceTests : AdventureWorksAbpApplicationTestBase
{
    private readonly ICountryAppService _countryAppService;

    public CountryAppServiceTests()
    {
        _countryAppService = GetRequiredService<ICountryAppService>();
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

