using System;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.Demographics.Regions;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace VumbaSoft.AdventureWorksAbp.EntityFrameworkCore.Demographics.Regions;

public class RegionRepositoryTests : AdventureWorksAbpEntityFrameworkCoreTestBase
{
    private readonly IRegionRepository _regionRepository;

    public RegionRepositoryTests()
    {
        _regionRepository = GetRequiredService<IRegionRepository>();
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
