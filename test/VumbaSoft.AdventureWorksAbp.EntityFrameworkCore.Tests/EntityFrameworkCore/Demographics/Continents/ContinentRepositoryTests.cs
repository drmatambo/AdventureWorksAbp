using System;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.Demographics.Continents;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace VumbaSoft.AdventureWorksAbp.EntityFrameworkCore.Demographics.Continents;

public class ContinentRepositoryTests : AdventureWorksAbpEntityFrameworkCoreTestBase
{
    private readonly IContinentRepository _continentRepository;

    public ContinentRepositoryTests()
    {
        _continentRepository = GetRequiredService<IContinentRepository>();
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
