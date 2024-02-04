using System;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.Demographics.Localities;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace VumbaSoft.AdventureWorksAbp.EntityFrameworkCore.Demographics.Localities;

public class LocalityRepositoryTests : AdventureWorksAbpEntityFrameworkCoreTestBase
{
    private readonly ILocalityRepository _localityRepository;

    public LocalityRepositoryTests()
    {
        _localityRepository = GetRequiredService<ILocalityRepository>();
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
