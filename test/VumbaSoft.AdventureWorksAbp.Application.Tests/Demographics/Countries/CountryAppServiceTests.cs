using Shouldly;
using System;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.Demographics.Continents;
using Xunit;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Countries;

public class CountryAppServiceTests : AdventureWorksAbpApplicationTestBase
{
    private readonly ICountryAppService _countryAppService;

    public CountryAppServiceTests()
    {
        _countryAppService = GetRequiredService<ICountryAppService>();
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

