using System;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace VumbaSoft.AdventureWorksAbp.EntityFrameworkCore.Demographics.StateProvinces;

public class StateProvinceRepositoryTests : AdventureWorksAbpEntityFrameworkCoreTestBase
{
    private readonly IStateProvinceRepository _stateProvinceRepository;

    public StateProvinceRepositoryTests()
    {
        _stateProvinceRepository = GetRequiredService<IStateProvinceRepository>();
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
