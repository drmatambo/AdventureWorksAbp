using System;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace VumbaSoft.AdventureWorksAbp.EntityFrameworkCore.Demographics.Subcontinents;

public class SubcontinentRepositoryTests : AdventureWorksAbpEntityFrameworkCoreTestBase
{
    private readonly ISubcontinentRepository _subcontinentRepository;

    public SubcontinentRepositoryTests()
    {
        _subcontinentRepository = GetRequiredService<ISubcontinentRepository>();
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
