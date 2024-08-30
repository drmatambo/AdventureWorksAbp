using Shouldly;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Xunit;
using VumbaSoft.AdventureWorksAbp.Demographics.Continents.Dtos;

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

    [Fact]
    public async Task Should_Get_List_Of_Continents()
    {
        //Act
        var result = await _continentAppService.GetListAsync(new ContinentGetListInput());

        //Assert
        result.TotalCount.ShouldBeGreaterThan(0);
        result.TotalCount.ShouldBe(6);
        result.Items.ShouldContain(b => b.Name == "Oceania");
    }
}

