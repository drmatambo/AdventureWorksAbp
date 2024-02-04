using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace VumbaSoft.AdventureWorksAbp.Pages;

public class Index_Tests : AdventureWorksAbpWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
