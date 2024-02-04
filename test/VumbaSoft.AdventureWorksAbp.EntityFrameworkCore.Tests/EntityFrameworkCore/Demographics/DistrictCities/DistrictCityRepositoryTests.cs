using System;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace VumbaSoft.AdventureWorksAbp.EntityFrameworkCore.Demographics.DistrictCities;

public class DistrictCityRepositoryTests : AdventureWorksAbpEntityFrameworkCoreTestBase
{
    private readonly IDistrictCityRepository _districtCityRepository;

    public DistrictCityRepositoryTests()
    {
        _districtCityRepository = GetRequiredService<IDistrictCityRepository>();
    }

    /*
    [Fact]
    public async Task Test1()
    {
        await WithUnitOfWorkAsync(async () =>
        {
            // Arrange

            // Act

            //Assert
        });
    }
    */
}
