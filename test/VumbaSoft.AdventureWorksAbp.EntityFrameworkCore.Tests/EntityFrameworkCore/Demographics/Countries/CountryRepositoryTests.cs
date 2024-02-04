using System;
using System.Threading.Tasks;
using VumbaSoft.AdventureWorksAbp.Demographics.Countries;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace VumbaSoft.AdventureWorksAbp.EntityFrameworkCore.Demographics.Countries;

public class CountryRepositoryTests : AdventureWorksAbpEntityFrameworkCoreTestBase
{
    private readonly ICountryRepository _countryRepository;

    public CountryRepositoryTests()
    {
        _countryRepository = GetRequiredService<ICountryRepository>();
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
